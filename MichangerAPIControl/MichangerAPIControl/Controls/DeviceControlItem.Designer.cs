namespace MichangerAPIControl.Controls
{
    partial class DeviceControlItem
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

        private void InitializeComponent()
        {
            this.ChkSelect = new System.Windows.Forms.CheckBox();
            this.LblSerial = new System.Windows.Forms.Label();
            this.LblStatus = new System.Windows.Forms.Label();
            this.BtnRandomChange = new System.Windows.Forms.Button();
            this.BtnConfigSocks = new System.Windows.Forms.Button();
            this.BtnGeminiPro = new System.Windows.Forms.Button();
            this.BtnSettings = new System.Windows.Forms.Button();
            this.LblSocks = new System.Windows.Forms.Label();
            this.TxtSocks = new System.Windows.Forms.TextBox();
            this.LblActionStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            
            // 
            // ChkSelect
            // 
            this.ChkSelect.AutoSize = true;
            this.ChkSelect.Location = new System.Drawing.Point(10, 15);
            this.ChkSelect.Name = "ChkSelect";
            this.ChkSelect.Size = new System.Drawing.Size(15, 14);
            this.ChkSelect.TabIndex = 0;
            this.ChkSelect.UseVisualStyleBackColor = true;
            
            // 
            // LblSerial
            // 
            this.LblSerial.AutoSize = true;
            this.LblSerial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LblSerial.ForeColor = System.Drawing.Color.White;
            this.LblSerial.Location = new System.Drawing.Point(30, 12);
            this.LblSerial.Name = "LblSerial";
            this.LblSerial.Size = new System.Drawing.Size(86, 19);
            this.LblSerial.TabIndex = 1;
            this.LblSerial.Text = "Serial_Here";
            
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.ForeColor = System.Drawing.Color.LightGray;
            this.LblStatus.Location = new System.Drawing.Point(130, 14);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(59, 15);
            this.LblStatus.TabIndex = 2;
            this.LblStatus.Text = "Connected";
            
            // 
            // LblSocks
            // 
            this.LblSocks.AutoSize = true;
            this.LblSocks.ForeColor = System.Drawing.Color.LightGray;
            this.LblSocks.Location = new System.Drawing.Point(210, 14);
            this.LblSocks.Name = "LblSocks";
            this.LblSocks.Size = new System.Drawing.Size(51, 15);
            this.LblSocks.TabIndex = 8;
            this.LblSocks.Text = "SOCKS5:";
            
            // 
            // TxtSocks
            // 
            this.TxtSocks.BackColor = System.Drawing.Color.FromArgb(40, 45, 60);
            this.TxtSocks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSocks.ForeColor = System.Drawing.Color.White;
            this.TxtSocks.Location = new System.Drawing.Point(265, 12);
            this.TxtSocks.Name = "TxtSocks";
            this.TxtSocks.Size = new System.Drawing.Size(155, 23);
            this.TxtSocks.TabIndex = 9;
            
            // 
            // BtnRandomChange
            // 
            this.BtnRandomChange.BackColor = System.Drawing.Color.FromArgb(50, 55, 75);
            this.BtnRandomChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRandomChange.ForeColor = System.Drawing.Color.White;
            this.BtnRandomChange.Location = new System.Drawing.Point(10, 45);
            this.BtnRandomChange.Name = "BtnRandomChange";
            this.BtnRandomChange.Size = new System.Drawing.Size(180, 25);
            this.BtnRandomChange.TabIndex = 4;
            this.BtnRandomChange.Text = "Rand+Change";
            this.BtnRandomChange.UseVisualStyleBackColor = false;
            this.BtnRandomChange.Click += new System.EventHandler(this.BtnRandomChange_Click);
            
            // 
            // BtnConfigSocks
            // 
            this.BtnConfigSocks.BackColor = System.Drawing.Color.FromArgb(50, 55, 75);
            this.BtnConfigSocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConfigSocks.ForeColor = System.Drawing.Color.White;
            this.BtnConfigSocks.Location = new System.Drawing.Point(425, 10);
            this.BtnConfigSocks.Name = "BtnConfigSocks";
            this.BtnConfigSocks.Size = new System.Drawing.Size(30, 27);
            this.BtnConfigSocks.TabIndex = 10;
            this.BtnConfigSocks.Text = "✓";
            this.BtnConfigSocks.UseVisualStyleBackColor = false;
            this.BtnConfigSocks.Click += new System.EventHandler(this.BtnConfigSocks_Click);
            
            // 
            // BtnGeminiPro
            // 
            this.BtnGeminiPro.BackColor = System.Drawing.Color.FromArgb(50, 55, 75);
            this.BtnGeminiPro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGeminiPro.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.BtnGeminiPro.ForeColor = System.Drawing.Color.Cyan;
            this.BtnGeminiPro.Location = new System.Drawing.Point(200, 45);
            this.BtnGeminiPro.Name = "BtnGeminiPro";
            this.BtnGeminiPro.Size = new System.Drawing.Size(120, 25);
            this.BtnGeminiPro.TabIndex = 6;
            this.BtnGeminiPro.Text = "✨ RUN GEMINIPRO";
            this.BtnGeminiPro.UseVisualStyleBackColor = false;
            this.BtnGeminiPro.Click += new System.EventHandler(this.BtnGeminiPro_Click);
            
            // 
            // BtnSettings
            // 
            this.BtnSettings.BackColor = System.Drawing.Color.FromArgb(60, 65, 85);
            this.BtnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnSettings.ForeColor = System.Drawing.Color.White;
            this.BtnSettings.Location = new System.Drawing.Point(325, 45);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Size = new System.Drawing.Size(130, 25);
            this.BtnSettings.TabIndex = 7;
            this.BtnSettings.Text = "⚙ Device Settings";
            this.BtnSettings.UseVisualStyleBackColor = false;
            this.BtnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            
            // 
            // LblActionStatus
            // 
            this.LblActionStatus.AutoSize = true;
            this.LblActionStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.LblActionStatus.ForeColor = System.Drawing.Color.DarkGray;
            this.LblActionStatus.Location = new System.Drawing.Point(10, 78);
            this.LblActionStatus.Name = "LblActionStatus";
            this.LblActionStatus.Size = new System.Drawing.Size(65, 15);
            this.LblActionStatus.TabIndex = 11;
            this.LblActionStatus.Text = "Status: Idle";
            
            // 
            // DeviceControlItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(30, 35, 50);
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LblActionStatus);
            this.Controls.Add(this.TxtSocks);
            this.Controls.Add(this.LblSocks);
            this.Controls.Add(this.BtnConfigSocks);
            this.Controls.Add(this.BtnSettings);
            this.Controls.Add(this.BtnGeminiPro);
            this.Controls.Add(this.BtnRandomChange);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.LblSerial);
            this.Controls.Add(this.ChkSelect);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Name = "DeviceControlItem";
            this.Size = new System.Drawing.Size(465, 100);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckBox ChkSelect;
        private System.Windows.Forms.Label LblSerial;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.Button BtnRandomChange;
        private System.Windows.Forms.Button BtnConfigSocks;
        private System.Windows.Forms.Button BtnGeminiPro;
        private System.Windows.Forms.Button BtnSettings;
        private System.Windows.Forms.Label LblSocks;
        private System.Windows.Forms.TextBox TxtSocks;
        private System.Windows.Forms.Label LblActionStatus;
    }
}
