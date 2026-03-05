using System;
using System.Drawing;
using System.Threading.Tasks;
using MichangerAPIControl.ApiClients;
using MichangerAPIControl.Automation.Flows;
using MichangerAPIControl.Core;
using MichangerAPIControl.Models;

namespace MichangerAPIControl.Automation
{
    /// <summary>
    /// Built-in automation flow: GeminiPro sequence.
    ///
    /// Steps executed per device:
    ///   [Step 0 - Optional] Wipe target app data (if Wipe = "True" in device settings)
    ///   [Step 1] Change device fingerprint using the active API (Michanger / OneChanger)
    ///            — Brand and Model are read from DeviceConfig (per-device) or global settings.
    ///   [Step 2] Set SOCKS5 proxy (if configured for this device)
    ///   [Step 3] Launch the target app
    ///
    /// To create your own custom flow, implement <see cref="IFlow"/>.
    /// Luong GeminiPro tich hop san. De tao flow tuy chinh, implement IFlow.
    /// </summary>
    public class GeminiProFlow : IFlow
    {
        // --- IFlow ---
        public string Name => "GeminiPro Flow";

        public async Task ExecuteAsync(
            BaseApiClient apiClient,
            string serial,
            Action<string> log,
            Action<string, Color> updateStatus)
        {
            await RunAsync(apiClient, serial, log, updateStatus);
        }

        // --- Static helper kept for internal usages and backwards compatibility ---

        /// <summary>
        /// Executes the GeminiPro sequence on a specific device.
        /// Thuc thi quy trinh GeminiPro tren thiet bi bang API Tool da chon.
        /// </summary>
        public static async Task RunAsync(
            BaseApiClient apiClient,
            string serial,
            Action<string> log,
            Action<string, Color> updateStatus)
        {
            try
            {
                log($"[GeminiPro] Starting flow for device: {serial}");

                var config = DeviceConfigManager.GetConfig(serial);

                // Resolve target app (fall back to YouTube if not set)
                string targetApp = string.IsNullOrWhiteSpace(config.AppWipe)
                    ? "com.google.android.youtube"
                    : config.AppWipe.Replace("package:", "").Trim();

                // ── Step 0: Wipe app data (optional, before changing device info) ──────────
                if (config.Wipe == "True")
                {
                    string msg0 = $"Step 0: Wiping data for app: {targetApp}...";
                    updateStatus(msg0, Color.Orange);
                    log($"[GeminiPro] {msg0}");

                    await AdbClient.ClearAppAsync(serial, targetApp);
                    await Task.Delay(1000);
                    log("[GeminiPro] Step 0 Success.");
                }

                // ── Step 1: Change device fingerprint ────────────────────────────────────
                // Reads Brand/Model from per-device config. Falls back to global defaults.
                string brand   = !string.IsNullOrWhiteSpace(config.FilterBrand)   ? config.FilterBrand   : "google";
                string model   = !string.IsNullOrWhiteSpace(config.FilterModel)   ? config.FilterModel   : "Pixel 10 Pro";
                string os      = config.FilterOs;
                string country = config.FilterCountry;
                string carrier = config.FilterCarrier;

                string msg1 = $"Step 1: Changing device info ({brand} {model})...";
                updateStatus(msg1, Color.Orange);
                log($"[GeminiPro] {msg1}");

                if (apiClient is MichangerApiClient mc)
                {
                    await mc.ChangeDeviceAsync(
                        serial,
                        filterBrand:   brand,
                        filterModel:   model,
                        filterOs:      string.IsNullOrWhiteSpace(os)      ? null : os,
                        filterCountry: string.IsNullOrWhiteSpace(country) ? null : country,
                        filterCarrier: string.IsNullOrWhiteSpace(carrier) ? null : carrier);
                }
                else if (apiClient is OnechangerApiClient oc)
                {
                    await oc.ChangeDeviceAsync(
                        serial,
                        filterBrand:   brand,
                        filterModel:   model,
                        filterOs:      string.IsNullOrWhiteSpace(os)      ? null : os,
                        filterCountry: string.IsNullOrWhiteSpace(country) ? null : country,
                        filterCarrier: string.IsNullOrWhiteSpace(carrier) ? null : carrier);
                }

                // Allow Michanger / OneChanger time to restart services
                await Task.Delay(1500);
                log("[GeminiPro] Step 1 Success.");

                // ── Step 2: Set SOCKS5 proxy ─────────────────────────────────────────────
                string socksConfig = config.GetSocksString();

                if (string.IsNullOrEmpty(socksConfig))
                {
                    log($"[GeminiPro] WARNING: No SOCKS5 config on {serial}. Proceeding without proxy.");
                }
                else
                {
                    string msg2 = "Step 2: Setting Proxy...";
                    updateStatus(msg2, Color.Orange);
                    log($"[GeminiPro] Step 2: Setting proxy: {socksConfig}");

                    if (apiClient is MichangerApiClient mcProxy)
                        await mcProxy.SetSocksAsync(serial, socksConfig);
                    else if (apiClient is OnechangerApiClient ocProxy)
                        await ocProxy.ConfigSockAsync(serial, socksConfig, changeLocation: "false");

                    await Task.Delay(1000);
                    log("[GeminiPro] Step 2 Success.");
                }

                // ── Step 3: Launch target app ────────────────────────────────────────────
                string msg3 = $"Step 3: Launching App ({targetApp})...";
                updateStatus(msg3, Color.Orange);
                log($"[GeminiPro] {msg3}");

                await AdbClient.OpenAppAsync(serial, targetApp);
                log("[GeminiPro] Step 3 Success.");

                updateStatus("Completed", Color.LightGreen);
                log($"[GeminiPro] FLOW COMPLETED for {serial}.");
            }
            catch (Exception ex)
            {
                updateStatus("Failed", Color.Red);
                log($"[GeminiPro] ERROR on {serial}: {ex.Message}");
            }
        }
    }
}
