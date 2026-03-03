using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MichangerAPIControl.Models;

namespace MichangerAPIControl.Controls
{
    public partial class DeviceControlItem : UserControl
    {
        private DeviceConfig _config;

        public event EventHandler<DeviceActionEventArgs> ActionClicked;

        // Custom Event Args to pass logic to main form
        public class DeviceActionEventArgs : EventArgs
        {
            public string ActionName { get; set; }
            public DeviceConfig Config { get; set; }
            public DeviceControlItem ControlItem { get; set; }
            
            public DeviceActionEventArgs(string actionName, DeviceConfig config, DeviceControlItem item)
            {
                ActionName = actionName;
                Config = config;
                ControlItem = item;
            }
        }

        public DeviceControlItem()
        {
            InitializeComponent();
        }

        public void SetDevice(DeviceConfig config, string status)
        {
            _config = config;
            LblSerial.Text = config.SerialNumber;
            LblStatus.Text = status;
            
            // Unsubscribe temporarily to avoid firing during setup
            if (TxtSocks != null) TxtSocks.TextChanged -= TxtSocks_TextChanged;
            
            if (TxtSocks != null)
                TxtSocks.Text = config.GetSocksString();
                
            if (TxtSocks != null) TxtSocks.TextChanged += TxtSocks_TextChanged;
        }

        private void TxtSocks_TextChanged(object sender, EventArgs e)
        {
            if (_config != null)
            {
                _config.FullSocks = TxtSocks.Text;
            }
        }

        public bool IsSelected
        {
            get => ChkSelect.Checked;
            set => ChkSelect.Checked = value;
        }

        public DeviceConfig GetConfig() => _config;

        public void UpdateActionStatus(string statusText, Color color)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string, Color>(UpdateActionStatus), statusText, color);
                return;
            }
            LblActionStatus.Text = statusText;
            LblActionStatus.ForeColor = color;
        }

        public void ToggleActionButtons(bool isEnabled)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<bool>(ToggleActionButtons), isEnabled);
                return;
            }
            BtnRandomChange.Enabled = isEnabled;
            BtnGeminiPro.Enabled = isEnabled;
            BtnConfigSocks.Enabled = isEnabled;
            // Optionally disable settings button too during run
            BtnSettings.Enabled = isEnabled;
        }

        private void BtnRandomChange_Click(object sender, EventArgs e)
        {
            ActionClicked?.Invoke(this, new DeviceActionEventArgs("Random & Change", _config, this));
        }

        private void BtnConfigSocks_Click(object sender, EventArgs e)
        {
            ActionClicked?.Invoke(this, new DeviceActionEventArgs("Config Socks5", _config, this));
        }

        private void BtnGeminiPro_Click(object sender, EventArgs e)
        {
            ActionClicked?.Invoke(this, new DeviceActionEventArgs("Run GeminiPro Flow", _config, this));
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            ActionClicked?.Invoke(this, new DeviceActionEventArgs("Open Settings", _config, this));
        }
    }
}
