using System;
using System.Drawing;
using System.Threading.Tasks;
using MichangerAPIControl.ApiClients;
using MichangerAPIControl.Core;
using MichangerAPIControl.Models;

namespace MichangerAPIControl.Automation
{
    /// <summary>
    /// Defines automated multi-step flows representing complex business logic.
    /// Định nghĩa các kịch bản tự động hóa gồm nhiều bước đại diện cho logic nghiệp vụ.
    /// </summary>
    public static class GeminiProFlow
    {
        /// <summary>
        /// Executes the GeminiPro sequence on a specific device using the chosen API Tool.
        /// Thực thi quy trình GeminiPro trên thiết bị bằng API Tool đã chọn.
        /// </summary>
        /// <param name="apiClient">MichangerApiClient or OnechangerApiClient / Client API đang dùng</param>
        /// <param name="serial">Target device serial / Số serial thiết bị</param>
        /// <param name="logAction">Callback to print logs / Hàm gọi lại để in log</param>
        /// <param name="updateStatus">Callback to update UI status label and color / Cập nhật UI</param>
        public static async Task ExecuteAsync(BaseApiClient apiClient, string serial, Action<string> logAction, Action<string, Color> updateStatus)
        {
            try
            {
                logAction($"[GeminiPro] Starting flow for device / Bắt đầu luồng cho thiết bị: {serial}");

                var config = DeviceConfigManager.GetConfig(serial);
                string targetApp = string.IsNullOrWhiteSpace(config.AppWipe) ? "com.google.android.youtube" : config.AppWipe;
                targetApp = targetApp.Replace("package:", "").Trim(); // Fix user input if they copied "package:" from ADB

                // Step 0: Xử lý App Wipe TRƯỚC khi đổi thông tin máy
                if (config.Wipe == "True")
                {
                    string msgStep0 = $"Step 0: Wiping data for app: {targetApp}...";
                    updateStatus(msgStep0, Color.Orange);
                    logAction($"[GeminiPro] {msgStep0}");
                    
                    await AdbClient.ClearAppAsync(serial, targetApp);
                    await Task.Delay(1000);
                    logAction($"[GeminiPro] Step 0 Success.");
                }

                // Step 1: Change Device to Google Pixel 10 Pro
                string msgStep1 = "Step 1: Changing Device Info (Google Pixel 10 Pro)...";
                updateStatus(msgStep1, Color.Orange);
                logAction($"[GeminiPro] {msgStep1}");
                
                if (apiClient is MichangerApiClient mc)
                {
                    await mc.ChangeDeviceAsync(serial, filterBrand: "google", filterModel: "Pixel 10 Pro");
                }
                else if (apiClient is OnechangerApiClient oc)
                {
                    await oc.ChangeDeviceAsync(serial, filterBrand: "google", filterModel: "Pixel 10 Pro");
                }
                await Task.Delay(1500); // Give Michanger/OneChanger time to restart services
                logAction($"[GeminiPro] Step 1 Success.");

                // Step 2: Set SOCKS5 (No location change)
                string socksConfig = config.GetSocksString();

                if (string.IsNullOrEmpty(socksConfig))
                {
                    logAction($"[GeminiPro] WARNING: No SOCKS5 config found for {serial}. Proceeding without proxy.");
                }
                else
                {
                    string msgStep2 = $"Step 2: Setting Proxy...";
                    updateStatus(msgStep2, Color.Orange);
                    logAction($"[GeminiPro] Step 2: Extracting SOCKS5 config for {serial}...");
                    logAction($"[GeminiPro] Setting proxy / Đang thiết lập proxy: {socksConfig}");
                    
                    if (apiClient is MichangerApiClient mcProxy)
                    {
                        await mcProxy.SetSocksAsync(serial, socksConfig);
                    }
                    else if (apiClient is OnechangerApiClient ocProxy)
                    {
                        await ocProxy.ConfigSockAsync(serial, socksConfig, changeLocation: "false");
                    }
                    await Task.Delay(1000);
                    logAction($"[GeminiPro] Step 2 Success.");
                }

                // Step 3: Launch Target App SAU KHI Set IP
                string msgStep3 = $"Step 3: Launching App...";
                updateStatus(msgStep3, Color.Orange);
                logAction($"[GeminiPro] Step 3: Launching target app: {targetApp}...");
                
                await AdbClient.OpenAppAsync(serial, targetApp);
                logAction($"[GeminiPro] Step 3 Success.");
                
                updateStatus("Completed", Color.LightGreen);
                logAction($"[GeminiPro] FLOW COMPLETED for {serial}. / KỊCH BẢN HOÀN TẤT cho {serial}.");
            }
            catch (Exception ex)
            {
                updateStatus("Failed", Color.Red);
                logAction($"[GeminiPro] ERROR on {serial}: {ex.Message} / LỖI trên thiêt bị {serial}");
            }
        }
    }
}
