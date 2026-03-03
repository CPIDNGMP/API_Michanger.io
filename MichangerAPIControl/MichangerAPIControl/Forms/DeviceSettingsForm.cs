using System;
using System.Windows.Forms;
using MichangerAPIControl.Models;

namespace MichangerAPIControl.Forms
{
    public partial class DeviceSettingsForm : Form
    {
        private DeviceConfig _config;

        public DeviceSettingsForm(DeviceConfig config)
        {
            InitializeComponent();
            _config = config;
            LoadConfig();
        }

        private void LoadConfig()
        {
            TxtBrand.Text = _config.FilterBrand;
            TxtModel.Text = _config.FilterModel;
            TxtOS.Text = _config.FilterOs;
            TxtCountry.Text = _config.FilterCountry;
            TxtAppWipe.Text = _config.AppWipe;
            CbFactoryReset.Checked = _config.FactoryReset == "True";
            CbWipe.Checked = _config.Wipe == "True";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _config.FilterBrand = TxtBrand.Text;
            _config.FilterModel = TxtModel.Text;
            _config.FilterOs = TxtOS.Text;
            _config.FilterCountry = TxtCountry.Text;
            _config.AppWipe = TxtAppWipe.Text;
            _config.FactoryReset = CbFactoryReset.Checked ? "True" : string.Empty;
            _config.Wipe = CbWipe.Checked ? "True" : string.Empty;

            DeviceConfigManager.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
