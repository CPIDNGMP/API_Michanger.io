using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using MichangerAPIControl.ApiClients;
using MichangerAPIControl.Core;
using MichangerAPIControl.Models;
using MichangerAPIControl.Controls;
using MichangerAPIControl.Automation;
using MichangerAPIControl.Forms;

namespace MichangerAPIControl
{
    public partial class Form1 : Form
    {
        private MichangerApiClient _michangerApi;
        private OnechangerApiClient _onechangerApi;
        private bool _isVietnamese = true;
        private int _activeToolIndex = 0; // 0: Michanger Pro, 1: OneChanger

        public Form1()
        {
            InitializeComponent();
            _michangerApi = new MichangerApiClient();
            _onechangerApi = new OnechangerApiClient();
            
            DeviceConfigManager.Load(); // Ensure device configs are loaded first
            LoadApplicationSettings();

            // Default UI update for the buttons (if no settings loaded)
            if (BtnToolMichanger.BackColor != Color.FromArgb(0, 122, 204) && BtnToolOneChanger.BackColor != Color.FromArgb(0, 122, 204))
            {
                 SwitchTool(_activeToolIndex);
            }

            UpdateLanguage();
            _ = PollApiStatusAsync();
        }

        private void LogMessage(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(LogMessage), msg);
                return;
            }
            TxtConsole.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}\n");
            TxtConsole.ScrollToCaret();
        }

        private async Task PollApiStatusAsync()
        {
            while (true)
            {
                try
                {
                    bool isProcessRunning = false;
                    bool isPortOpen = false;

                    string targetProcess = _activeToolIndex == 0 ? "Michanger" : "OneChanger";

                    var processes = System.Diagnostics.Process.GetProcesses();
                    foreach (var p in processes)
                    {
                        if (p.ProcessName.IndexOf(targetProcess, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            isProcessRunning = true;
                            break;
                        }
                        if (_activeToolIndex == 1 && p.ProcessName.IndexOf("One changer", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            isProcessRunning = true;
                            break;
                        }
                    }

                    try
                    {
                        using (var client = new System.Net.Sockets.TcpClient())
                        {
                            var result = client.BeginConnect("127.0.0.1", 9999, null, null);
                            isPortOpen = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                        }
                    }
                    catch { }

                    bool isToolOn = isProcessRunning && isPortOpen;
                    string toolName = _activeToolIndex == 0 ? "Michanger Pro" : "OneChanger";

                    this.Invoke(new Action(() => {
                        lblActiveToolStatus.Text = $"{toolName}: {(isToolOn ? "ON" : "OFF")}";
                        lblActiveToolStatus.ForeColor = isToolOn ? Color.LightGreen : Color.Red;
                    }));
                }
                catch { }

                await Task.Delay(3000);
            }
        }

        private void BtnToolMichanger_Click(object sender, EventArgs e)
        {
            if (_activeToolIndex == 0) return;
            SwitchTool(0);
        }

        private void BtnToolOneChanger_Click(object sender, EventArgs e)
        {
            if (_activeToolIndex == 1) return;
            SwitchTool(1);
        }

        private void SwitchTool(int toolIndex)
        {
            _activeToolIndex = toolIndex;

            // Explicitly force ENABLED so WinForms doesn't paint them gray
            BtnToolMichanger.Enabled = true;
            BtnToolOneChanger.Enabled = true;

            // Highlight the active button using BackColor and Border
            BtnToolMichanger.BackColor = (toolIndex == 0) ? Color.FromArgb(0, 122, 204) : Color.FromArgb(30, 35, 50);
            BtnToolOneChanger.BackColor = (toolIndex == 1) ? Color.FromArgb(0, 122, 204) : Color.FromArgb(30, 35, 50);

            BtnToolMichanger.FlatAppearance.BorderColor = (toolIndex == 0) ? Color.Cyan : Color.FromArgb(60, 65, 80);
            BtnToolOneChanger.FlatAppearance.BorderColor = (toolIndex == 1) ? Color.Cyan : Color.FromArgb(60, 65, 80);
            
            BtnToolMichanger.FlatAppearance.BorderSize = (toolIndex == 0) ? 2 : 1;
            BtnToolOneChanger.FlatAppearance.BorderSize = (toolIndex == 1) ? 2 : 1;

            if (toolIndex == 0) // Michanger Pro Selected
            {
                LogMessage("Switched Backend Context to Michanger Pro.");
                UpdateLanguage();
            }
            else // OneChanger Selected
            {
                LogMessage("Switched Backend Context to OneChanger.");
                UpdateLanguage();
            }
        }

        private void UpdateLanguage()
        {
            string activeToolName = _activeToolIndex == 0 ? "Michanger Pro" : "OneChanger";

            if (_isVietnamese)
            {
                lblInstructions.Text = $"HƯỚNG DẪN CƠ BẢN:\n1. Công cụ đang chọn là {activeToolName}. Hãy đảm bảo {activeToolName} đang mở và báo 'ON' ở cột trái.\n2. Cắm cáp điện thoại, bấm 'Quét Thiết Bị' để xem danh sách.\n3. Tick chọn các thiết bị muốn chạy.\n4. Vùng Cấu hình (Brand, Model, Country) dùng cho Đổi thông tin hàng loạt.\n5. Để cấu hình SOCKS5, nhập proxy vào ô SOCKS5 trên từng thiết bị, sau đó bấm nút '✓' (Config Socks5).\n6. Để chạy luồng GeminiPro tự động: Vui lòng nhập SOCKS5 trước, sau đó bấm 'RUN GEMINIPRO'. Luồng sẽ tự Đổi máy -> Gắn SOCKS -> Mở app YouTube (hoặc app wipe).";
            }
            else
            {
                lblInstructions.Text = $"BASIC INSTRUCTIONS:\n1. The selected tool is {activeToolName}. Please ensure {activeToolName} is open and shows 'ON' in the left column.\n2. Plug in your phone cable, click 'Scan Devices' to view the list.\n3. Check the devices you want to run.\n4. The Settings area (Brand, Model, Country) is used for batch changing info.\n5. To configure SOCKS5, enter the proxy in the SOCKS5 box on each device, then click the '✓' (Config Socks5) button.\n6. To run the automated GeminiPro flow: Please enter SOCKS5 first, then click 'RUN GEMINIPRO'. The flow will Automatically Change Device -> Set SOCKS -> Open YouTube app (or wipe app).";
            }
        }

        private void BtnLangVietnamese_Click(object sender, EventArgs e)
        {
            _isVietnamese = true;
            UpdateLanguage();
        }

        private void BtnLangEnglish_Click(object sender, EventArgs e)
        {
            _isVietnamese = false;
            UpdateLanguage();
        }

        private async void BtnScan_Click(object sender, EventArgs e)
        {
            LogMessage("Scanning for ADB devices... / Đang quét thiết bị ADB...");
            BtnScan.Enabled = false;
            pnlDeviceList.Controls.Clear();

            try
            {
                var devices = await AdbClient.GetDevicesAsync();
                LogMessage($"Found {devices.Count} devices.");

                foreach (var serial in devices)
                {
                    var config = DeviceConfigManager.GetConfig(serial);
                    var item = new DeviceControlItem();
                    item.SetDevice(config, "Connected");
                    item.ActionClicked += DeviceItem_ActionClicked;
                    pnlDeviceList.Controls.Add(item);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error scanning devices: {ex.Message}");
            }
            finally
            {
                BtnScan.Enabled = true;
            }
        }

        private void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = chkSelectAll.Checked;
            foreach (Control ctrl in pnlDeviceList.Controls)
            {
                if (ctrl is DeviceControlItem item)
                {
                    item.IsSelected = isChecked;
                }
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeviceConfigManager.Save();
            SaveApplicationSettings();
        }

        // --- GLOBAL ACTIONS ---
        
        private BaseApiClient GetActiveApiClient()
        {
            return _activeToolIndex == 0 ? (BaseApiClient)_michangerApi : _onechangerApi;
        }

        private async void ExecuteActionOnSelectedDevices(string actionName)
        {
            var apiClient = GetActiveApiClient();
            var tasks = new List<Task>();

            foreach (Control ctrl in pnlDeviceList.Controls)
            {
                if (ctrl is DeviceControlItem item && item.IsSelected)
                {
                    var serial = item.GetConfig().SerialNumber;
                    var config = item.GetConfig();
                    item.ToggleActionButtons(false);
                    item.UpdateActionStatus($"Running {actionName}...", Color.Orange);

                    tasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            if (actionName == "Random & Change")
                            {
                                if (apiClient is MichangerApiClient mc)
                                    await mc.ChangeDeviceAsync(serial, filterBrand: TxtBrand.Text, filterModel: TxtModel.Text, filterCountry: TxtCountry.Text);
                                else if (apiClient is OnechangerApiClient oc)
                                    await oc.ChangeDeviceAsync(serial, filterBrand: TxtBrand.Text, filterModel: TxtModel.Text, filterCountry: TxtCountry.Text);
                            }
                            else if (actionName == "Run GeminiPro Flow")
                            {
                                await GeminiProFlow.ExecuteAsync(apiClient, serial, LogMessage, (msg, color) => 
                                {
                                    this.Invoke(new Action(() => item.UpdateActionStatus(msg, color)));
                                });
                            }
                            else if (actionName == "Config Socks5")
                            {
                                string socksStr = config.GetSocksString();
                                if (string.IsNullOrEmpty(socksStr))
                                {
                                    item.UpdateActionStatus("Error: Socks5 empty", Color.Red);
                                    LogMessage($"[Error] {serial}: Socks5 is empty.");
                                    return;
                                }

                                if (apiClient is MichangerApiClient mcProxy)
                                    await mcProxy.SetSocksAsync(serial, socksStr);
                                else if (apiClient is OnechangerApiClient ocProxy)
                                    await ocProxy.ConfigSockAsync(serial, socksStr, changeLocation: "false");
                            }

                            if (actionName != "Run GeminiPro Flow")
                            {
                                item.UpdateActionStatus("Success", Color.LightGreen);
                            }
                            LogMessage($"[Success] {serial} finished {actionName}");
                        }
                        catch (Exception ex)
                        {
                            item.UpdateActionStatus("Failed", Color.Red);
                            LogMessage($"[Error] {serial}: {ex.Message}");
                        }
                        finally
                        {
                            item.ToggleActionButtons(true);
                        }
                    }));
                }
            }

            if (tasks.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một thiết bị / Please select at least one device.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LogMessage($"Started {actionName} on {tasks.Count} devices.");
            await Task.WhenAll(tasks);
            LogMessage($"Completed {actionName} on all selected devices.");
        }

        private void BtnRandomAndChange_Click(object sender, EventArgs e) => ExecuteActionOnSelectedDevices("Random & Change");
        private void BtnRunGemini_Click(object sender, EventArgs e) => ExecuteActionOnSelectedDevices("Run GeminiPro Flow");
        private void BtnGlobalConfigSocks_Click(object sender, EventArgs e) => ExecuteActionOnSelectedDevices("Config Socks5");

        // --- INDIVIDUAL ACTIONS ---
        private async void DeviceItem_ActionClicked(object sender, DeviceControlItem.DeviceActionEventArgs e)
        {
            var apiClient = GetActiveApiClient();
            var serial = e.Config.SerialNumber;
            var item = e.ControlItem;

            item.ToggleActionButtons(false);
            item.UpdateActionStatus($"Running {e.ActionName}...", Color.Orange);

            try
            {
                if (e.ActionName == "Random & Change")
                {
                    if (apiClient is MichangerApiClient mc)
                        await mc.ChangeDeviceAsync(serial, filterBrand: TxtBrand.Text, filterModel: TxtModel.Text, filterCountry: TxtCountry.Text);
                    else if (apiClient is OnechangerApiClient oc)
                        await oc.ChangeDeviceAsync(serial, filterBrand: TxtBrand.Text, filterModel: TxtModel.Text, filterCountry: TxtCountry.Text);
                }
                else if (e.ActionName == "Run GeminiPro Flow")
                {
                    await GeminiProFlow.ExecuteAsync(apiClient, serial, LogMessage, (msg, color) => 
                    {
                        this.Invoke(new Action(() => item.UpdateActionStatus(msg, color)));
                    });
                }
                else if (e.ActionName == "Config Socks5")
                {
                    string socksStr = e.Config.GetSocksString();
                    if (string.IsNullOrEmpty(socksStr))
                    {
                        item.UpdateActionStatus("Error: Socks5 empty", Color.Red);
                        LogMessage($"[Error] {serial}: Socks5 is empty.");
                        return;
                    }

                    if (apiClient is MichangerApiClient mcProxy)
                        await mcProxy.SetSocksAsync(serial, socksStr);
                    else if (apiClient is OnechangerApiClient ocProxy)
                        await ocProxy.ConfigSockAsync(serial, socksStr, changeLocation: "false");
                }

                else if (e.ActionName == "Open Settings")
                {
                    using (var frm = new DeviceSettingsForm(e.Config))
                    {
                        frm.ShowDialog(this);
                    }
                }

                if (e.ActionName != "Run GeminiPro Flow")
                {
                    item.UpdateActionStatus("Success", Color.LightGreen);
                }
                LogMessage($"[Success] {serial} finished {e.ActionName}");
            }
            catch (Exception ex)
            {
                item.UpdateActionStatus("Failed", Color.Red);
                LogMessage($"[Error] {serial}: {ex.Message}");
            }
            finally
            {
                item.ToggleActionButtons(true);
            }
        }

        // --- APP SETTINGS PERSISTENCE ---
        private void LoadApplicationSettings()
        {
            try
            {
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings", "app.json");
                if (File.Exists(configPath))
                {
                    string json = File.ReadAllText(configPath);
                    var settings = new JavaScriptSerializer().Deserialize<Form1Settings>(json);
                    if (settings != null)
                    {
                        if (settings.WindowBounds.Width > 0 && settings.WindowBounds.Height > 0)
                        {
                            this.StartPosition = FormStartPosition.Manual;
                            this.Bounds = settings.WindowBounds;
                        }

                        TxtBrand.Text = settings.GlobalBrand ?? "google";
                        TxtModel.Text = settings.GlobalModel ?? "Pixel 10 Pro";
                        TxtCountry.Text = settings.GlobalCountry ?? "US";

                        _activeToolIndex = settings.ActiveToolIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Warning: Failed to load app settings: {ex.Message}");
            }

            // Apply loaded tool state
            SwitchTool(_activeToolIndex);
        }

        private void SaveApplicationSettings()
        {
            try
            {
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings", "app.json");
                var dir = Path.GetDirectoryName(configPath);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                var settings = new Form1Settings
                {
                    WindowBounds = this.WindowState == FormWindowState.Normal ? this.Bounds : this.RestoreBounds,
                    GlobalBrand = TxtBrand.Text,
                    GlobalModel = TxtModel.Text,
                    GlobalCountry = TxtCountry.Text,
                    ActiveToolIndex = _activeToolIndex
                };

                string json = new JavaScriptSerializer().Serialize(settings);
                File.WriteAllText(configPath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving app settings: {ex.Message}");
            }
        }
    }

    public class Form1Settings
    {
        public Rectangle WindowBounds { get; set; }
        public string GlobalBrand { get; set; }
        public string GlobalModel { get; set; }
        public string GlobalCountry { get; set; }
        public int ActiveToolIndex { get; set; }
    }
}
