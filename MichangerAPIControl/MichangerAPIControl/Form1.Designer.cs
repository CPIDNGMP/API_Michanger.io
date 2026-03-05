namespace MichangerAPIControl
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblToolType = new System.Windows.Forms.Label();
            this.BtnToolMichanger = new System.Windows.Forms.Button();
            this.BtnToolOneChanger = new System.Windows.Forms.Button();
            this.lblActiveToolStatus = new System.Windows.Forms.Label();
            this.BtnScan = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.lblDeviceList = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.pnlDeviceList = new System.Windows.Forms.FlowLayoutPanel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelActions = new System.Windows.Forms.Panel();
            this.BtnRandomAndChange = new System.Windows.Forms.Button();
            this.BtnRunGemini = new System.Windows.Forms.Button();
            this.BtnAdbEditor = new System.Windows.Forms.Button();
            this.BtnGlobalConfigSocks = new System.Windows.Forms.Button();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.lblSettingsTitle = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.TxtBrand = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.TxtModel = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.TxtCountry = new System.Windows.Forms.TextBox();
            this.panelInstructions = new System.Windows.Forms.Panel();
            this.btnLangVietnamese = new System.Windows.Forms.Button();
            this.btnLangEnglish = new System.Windows.Forms.Button();
            this.lblInstructions = new System.Windows.Forms.RichTextBox();
            this.panelLogs = new System.Windows.Forms.Panel();
            this.TxtConsole = new System.Windows.Forms.RichTextBox();
            
            this.panelLeft.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.panelInstructions.SuspendLayout();
            this.panelLogs.SuspendLayout();
            this.SuspendLayout();
            
            // panelLeft
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(10, 15, 25);
            this.panelLeft.Controls.Add(this.lblAppTitle);
            this.panelLeft.Controls.Add(this.lblToolType);
            this.panelLeft.Controls.Add(this.BtnToolMichanger);
            this.panelLeft.Controls.Add(this.BtnToolOneChanger);
            this.panelLeft.Controls.Add(this.lblActiveToolStatus);
            this.panelLeft.Controls.Add(this.BtnScan);
            this.panelLeft.Controls.Add(this.BtnExit);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(180, 700);
            
            // lblAppTitle
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(20, 20);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Text = "ADB CONTROL";
            
            // lblToolType
            this.lblToolType.AutoSize = true;
            this.lblToolType.ForeColor = System.Drawing.Color.LightGray;
            this.lblToolType.Location = new System.Drawing.Point(10, 80);
            this.lblToolType.Name = "lblToolType";
            this.lblToolType.Text = "Select Tool / Chọn Công cụ:";
            
            // BtnToolMichanger
            this.BtnToolMichanger.BackColor = System.Drawing.Color.FromArgb(30, 35, 50);
            this.BtnToolMichanger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnToolMichanger.ForeColor = System.Drawing.Color.White;
            this.BtnToolMichanger.Location = new System.Drawing.Point(10, 105);
            this.BtnToolMichanger.Name = "BtnToolMichanger";
            this.BtnToolMichanger.Size = new System.Drawing.Size(160, 30);
            this.BtnToolMichanger.Text = "Michanger Pro";
            this.BtnToolMichanger.UseVisualStyleBackColor = false;
            this.BtnToolMichanger.Click += new System.EventHandler(this.BtnToolMichanger_Click);

            // BtnToolOneChanger
            this.BtnToolOneChanger.BackColor = System.Drawing.Color.FromArgb(30, 35, 50);
            this.BtnToolOneChanger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnToolOneChanger.ForeColor = System.Drawing.Color.White;
            this.BtnToolOneChanger.Location = new System.Drawing.Point(10, 140);
            this.BtnToolOneChanger.Name = "BtnToolOneChanger";
            this.BtnToolOneChanger.Size = new System.Drawing.Size(160, 30);
            this.BtnToolOneChanger.Text = "OneChanger";
            this.BtnToolOneChanger.UseVisualStyleBackColor = false;
            this.BtnToolOneChanger.Click += new System.EventHandler(this.BtnToolOneChanger_Click);
            
            // lblActiveToolStatus
            this.lblActiveToolStatus.AutoSize = true;
            this.lblActiveToolStatus.ForeColor = System.Drawing.Color.Red;
            this.lblActiveToolStatus.Location = new System.Drawing.Point(10, 185);
            this.lblActiveToolStatus.Name = "lblActiveToolStatus";
            this.lblActiveToolStatus.Text = "Status: OFF";

            // BtnScan
            this.BtnScan.BackColor = System.Drawing.Color.FromArgb(30, 35, 50);
            this.BtnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnScan.ForeColor = System.Drawing.Color.White;
            this.BtnScan.Location = new System.Drawing.Point(10, 220);
            this.BtnScan.Name = "BtnScan";
            this.BtnScan.Size = new System.Drawing.Size(160, 35);
            this.BtnScan.Text = "Scan Devices / Quét Thiết Bị";
            this.BtnScan.UseVisualStyleBackColor = false;
            this.BtnScan.Click += new System.EventHandler(this.BtnScan_Click);
            
            // BtnExit
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(30, 35, 50);
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.ForeColor = System.Drawing.Color.IndianRed;
            this.BtnExit.Location = new System.Drawing.Point(10, 265);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(160, 35);
            this.BtnExit.Text = "Exit App";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            
            // panelCenter
            this.panelCenter.BackColor = System.Drawing.Color.FromArgb(20, 25, 40);
            this.panelCenter.Controls.Add(this.lblDeviceList);
            this.panelCenter.Controls.Add(this.chkSelectAll);
            this.panelCenter.Controls.Add(this.pnlDeviceList);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelCenter.Location = new System.Drawing.Point(180, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Padding = new System.Windows.Forms.Padding(10);
            this.panelCenter.Size = new System.Drawing.Size(510, 700);
            
            // lblDeviceList
            this.lblDeviceList.AutoSize = true;
            this.lblDeviceList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDeviceList.ForeColor = System.Drawing.Color.White;
            this.lblDeviceList.Location = new System.Drawing.Point(10, 15);
            this.lblDeviceList.Name = "lblDeviceList";
            this.lblDeviceList.Text = "Connected Devices / Thiết bị đã kết nối";
            
            // chkSelectAll
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.ForeColor = System.Drawing.Color.White;
            this.chkSelectAll.Location = new System.Drawing.Point(13, 40);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(74, 19);
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.ChkSelectAll_CheckedChanged);
            
            // pnlDeviceList
            this.pnlDeviceList.AutoScroll = true;
            this.pnlDeviceList.Location = new System.Drawing.Point(10, 70);
            this.pnlDeviceList.Name = "pnlDeviceList";
            this.pnlDeviceList.Size = new System.Drawing.Size(490, 620);
            this.pnlDeviceList.WrapContents = false;
            this.pnlDeviceList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;

            // panelRight
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            // Z-ORDER MATTERS FOR DOCKING: Add Fill last, Top/Bottom first.
            this.panelRight.Controls.Add(this.panelInstructions); // (Dock.Fill) goes LAST
            this.panelRight.Controls.Add(this.panelSettings);     // (Dock.Top)
            this.panelRight.Controls.Add(this.panelActions);      // (Dock.Top)
            this.panelRight.Controls.Add(this.panelLogs);         // (Dock.Bottom)
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(690, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(10);

            // panelActions
            this.panelActions.Controls.Add(this.BtnAdbEditor);
            this.panelActions.Controls.Add(this.BtnRandomAndChange);
            this.panelActions.Controls.Add(this.BtnRunGemini);
            this.panelActions.Controls.Add(this.BtnGlobalConfigSocks);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelActions.Location = new System.Drawing.Point(10, 10);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(530, 150);
            
            // BtnAdbEditor
            this.BtnAdbEditor.BackColor = System.Drawing.Color.FromArgb(50, 55, 75);
            this.BtnAdbEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdbEditor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BtnAdbEditor.ForeColor = System.Drawing.Color.Yellow;
            this.BtnAdbEditor.Location = new System.Drawing.Point(380, 5);
            this.BtnAdbEditor.Name = "BtnAdbEditor";
            this.BtnAdbEditor.Size = new System.Drawing.Size(140, 40);
            this.BtnAdbEditor.Text = "🛠 ADB EDITOR";
            this.BtnAdbEditor.UseVisualStyleBackColor = false;
            this.BtnAdbEditor.Click += new System.EventHandler(this.BtnAdbEditor_Click);
            
            // BtnRandomAndChange
            this.BtnRandomAndChange.BackColor = System.Drawing.Color.FromArgb(50, 55, 75);
            this.BtnRandomAndChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRandomAndChange.ForeColor = System.Drawing.Color.White;
            this.BtnRandomAndChange.Location = new System.Drawing.Point(0, 5);
            this.BtnRandomAndChange.Name = "BtnRandomAndChange";
            this.BtnRandomAndChange.Size = new System.Drawing.Size(180, 40);
            this.BtnRandomAndChange.Text = "Random && Change";
            this.BtnRandomAndChange.UseVisualStyleBackColor = false;
            this.BtnRandomAndChange.Click += new System.EventHandler(this.BtnRandomAndChange_Click);
            
            // BtnRunGemini
            this.BtnRunGemini.BackColor = System.Drawing.Color.FromArgb(50, 55, 75);
            this.BtnRunGemini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRunGemini.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BtnRunGemini.ForeColor = System.Drawing.Color.Cyan;
            this.BtnRunGemini.Location = new System.Drawing.Point(190, 5);
            this.BtnRunGemini.Name = "BtnRunGemini";
            this.BtnRunGemini.Size = new System.Drawing.Size(180, 40);
            this.BtnRunGemini.Text = "✨ RUN GEMINIPRO";
            this.BtnRunGemini.UseVisualStyleBackColor = false;
            this.BtnRunGemini.Click += new System.EventHandler(this.BtnRunGemini_Click);

            // BtnGlobalConfigSocks
            this.BtnGlobalConfigSocks.BackColor = System.Drawing.Color.FromArgb(50, 55, 75);
            this.BtnGlobalConfigSocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGlobalConfigSocks.ForeColor = System.Drawing.Color.White;
            this.BtnGlobalConfigSocks.Location = new System.Drawing.Point(0, 55);
            this.BtnGlobalConfigSocks.Name = "BtnGlobalConfigSocks";
            this.BtnGlobalConfigSocks.Size = new System.Drawing.Size(370, 40);
            this.BtnGlobalConfigSocks.Text = "Config Socks5";
            this.BtnGlobalConfigSocks.UseVisualStyleBackColor = false;
            this.BtnGlobalConfigSocks.Click += new System.EventHandler(this.BtnGlobalConfigSocks_Click);

            // panelSettings
            this.panelSettings.Controls.Add(this.lblSettingsTitle);
            this.panelSettings.Controls.Add(this.lblBrand);
            this.panelSettings.Controls.Add(this.TxtBrand);
            this.panelSettings.Controls.Add(this.lblModel);
            this.panelSettings.Controls.Add(this.TxtModel);
            this.panelSettings.Controls.Add(this.lblCountry);
            this.panelSettings.Controls.Add(this.TxtCountry);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSettings.Location = new System.Drawing.Point(10, 115);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.panelSettings.Size = new System.Drawing.Size(530, 100);

            // lblSettingsTitle
            this.lblSettingsTitle.AutoSize = true;
            this.lblSettingsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSettingsTitle.ForeColor = System.Drawing.Color.White;
            this.lblSettingsTitle.Location = new System.Drawing.Point(0, 5);
            this.lblSettingsTitle.Text = "Settings & Filters / Cấu hình & Lọc";

            this.lblBrand.AutoSize = true;
            this.lblBrand.ForeColor = System.Drawing.Color.LightGray;
            this.lblBrand.Location = new System.Drawing.Point(0, 35);
            this.lblBrand.Text = "Brand:";
            
            this.TxtBrand.BackColor = System.Drawing.Color.FromArgb(40, 45, 60);
            this.TxtBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBrand.ForeColor = System.Drawing.Color.White;
            this.TxtBrand.Location = new System.Drawing.Point(50, 32);
            this.TxtBrand.Size = new System.Drawing.Size(120, 23);
            this.TxtBrand.Text = "google";

            this.lblModel.AutoSize = true;
            this.lblModel.ForeColor = System.Drawing.Color.LightGray;
            this.lblModel.Location = new System.Drawing.Point(180, 35);
            this.lblModel.Text = "Model:";
            
            this.TxtModel.BackColor = System.Drawing.Color.FromArgb(40, 45, 60);
            this.TxtModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtModel.ForeColor = System.Drawing.Color.White;
            this.TxtModel.Location = new System.Drawing.Point(230, 32);
            this.TxtModel.Size = new System.Drawing.Size(120, 23);
            this.TxtModel.Text = "Pixel 10 Pro";

            this.lblCountry.AutoSize = true;
            this.lblCountry.ForeColor = System.Drawing.Color.LightGray;
            this.lblCountry.Location = new System.Drawing.Point(360, 35);
            this.lblCountry.Text = "Country:";
            
            this.TxtCountry.BackColor = System.Drawing.Color.FromArgb(40, 45, 60);
            this.TxtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCountry.ForeColor = System.Drawing.Color.White;
            this.TxtCountry.Location = new System.Drawing.Point(420, 32);
            this.TxtCountry.Size = new System.Drawing.Size(80, 23);
            this.TxtCountry.Text = "US";

            // panelInstructions
            this.panelInstructions.Controls.Add(this.btnLangVietnamese);
            this.panelInstructions.Controls.Add(this.btnLangEnglish);
            this.panelInstructions.Controls.Add(this.lblInstructions);
            this.panelInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInstructions.Location = new System.Drawing.Point(10, 215);
            this.panelInstructions.Name = "panelInstructions";
            this.panelInstructions.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            
            // btnLangVietnamese
            this.btnLangVietnamese.BackColor = System.Drawing.Color.FromArgb(30, 35, 50);
            this.btnLangVietnamese.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLangVietnamese.ForeColor = System.Drawing.Color.White;
            this.btnLangVietnamese.Location = new System.Drawing.Point(0, 5);
            this.btnLangVietnamese.Size = new System.Drawing.Size(120, 25);
            this.btnLangVietnamese.Text = "VN Tiếng Việt";
            this.btnLangVietnamese.Click += new System.EventHandler(this.BtnLangVietnamese_Click);
            
            // btnLangEnglish
            this.btnLangEnglish.BackColor = System.Drawing.Color.FromArgb(30, 35, 50);
            this.btnLangEnglish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLangEnglish.ForeColor = System.Drawing.Color.White;
            this.btnLangEnglish.Location = new System.Drawing.Point(125, 5);
            this.btnLangEnglish.Size = new System.Drawing.Size(120, 25);
            this.btnLangEnglish.Text = "US English";
            this.btnLangEnglish.Click += new System.EventHandler(this.BtnLangEnglish_Click);

            // lblInstructions
            this.lblInstructions.BackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            this.lblInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblInstructions.ForeColor = System.Drawing.Color.LightGray;
            this.lblInstructions.Location = new System.Drawing.Point(0, 40);
            this.lblInstructions.ReadOnly = true;
            this.lblInstructions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblInstructions.Size = new System.Drawing.Size(530, 280);
            this.lblInstructions.Text = "Instructions go here...";

            // panelLogs
            this.panelLogs.Controls.Add(this.TxtConsole);
            this.panelLogs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLogs.Location = new System.Drawing.Point(10, 540);
            this.panelLogs.Name = "panelLogs";
            this.panelLogs.Size = new System.Drawing.Size(530, 150);

            // TxtConsole
            this.TxtConsole.BackColor = System.Drawing.Color.Black;
            this.TxtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtConsole.ForeColor = System.Drawing.Color.Lime;
            this.TxtConsole.ReadOnly = true;
            this.TxtConsole.Text = "[Hệ thống] Đã khởi tạo. Sẵn sàng quét thiết bị ADB.\n";

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(20, 25, 35);
            this.ClientSize = new System.Drawing.Size(1250, 700);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelLeft);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "Form1";
            this.Text = "ADB Multi-Device Control Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelActions.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.panelInstructions.ResumeLayout(false);
            this.panelLogs.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblToolType;
        private System.Windows.Forms.Button BtnToolMichanger;
        private System.Windows.Forms.Button BtnToolOneChanger;
        private System.Windows.Forms.Button BtnScan;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Label lblActiveToolStatus;

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Label lblDeviceList;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.FlowLayoutPanel pnlDeviceList;

        private System.Windows.Forms.Panel panelRight;
        
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button BtnRandomAndChange;
        private System.Windows.Forms.Button BtnRunGemini;
        private System.Windows.Forms.Button BtnAdbEditor;
        private System.Windows.Forms.Button BtnGlobalConfigSocks;

        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label lblSettingsTitle;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.TextBox TxtBrand;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox TxtModel;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox TxtCountry;

        private System.Windows.Forms.Panel panelInstructions;
        private System.Windows.Forms.Button btnLangVietnamese;
        private System.Windows.Forms.Button btnLangEnglish;
        private System.Windows.Forms.RichTextBox lblInstructions;

        private System.Windows.Forms.Panel panelLogs;
        private System.Windows.Forms.RichTextBox TxtConsole;
    }
}
