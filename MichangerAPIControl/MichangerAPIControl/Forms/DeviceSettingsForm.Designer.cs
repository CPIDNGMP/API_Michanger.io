namespace MichangerAPIControl.Forms
{
    partial class DeviceSettingsForm
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
            this.LblBrand = new System.Windows.Forms.Label();
            this.TxtBrand = new System.Windows.Forms.TextBox();
            this.LblModel = new System.Windows.Forms.Label();
            this.TxtModel = new System.Windows.Forms.TextBox();
            this.LblOS = new System.Windows.Forms.Label();
            this.TxtOS = new System.Windows.Forms.TextBox();
            this.LblCountry = new System.Windows.Forms.Label();
            this.TxtCountry = new System.Windows.Forms.TextBox();
            this.LblAppWipe = new System.Windows.Forms.Label();
            this.TxtAppWipe = new System.Windows.Forms.TextBox();
            this.CbFactoryReset = new System.Windows.Forms.CheckBox();
            this.CbWipe = new System.Windows.Forms.CheckBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // 
            // LblBrand
            // 
            this.LblBrand.AutoSize = true;
            this.LblBrand.ForeColor = System.Drawing.Color.White;
            this.LblBrand.Location = new System.Drawing.Point(20, 20);
            this.LblBrand.Name = "LblBrand";
            this.LblBrand.Size = new System.Drawing.Size(41, 15);
            this.LblBrand.Text = "Brand:";
            
            // 
            // TxtBrand
            // 
            this.TxtBrand.BackColor = System.Drawing.Color.FromArgb(40, 45, 60);
            this.TxtBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBrand.ForeColor = System.Drawing.Color.White;
            this.TxtBrand.Location = new System.Drawing.Point(120, 18);
            this.TxtBrand.Name = "TxtBrand";
            this.TxtBrand.Size = new System.Drawing.Size(200, 23);
            
            // 
            // LblModel
            // 
            this.LblModel.AutoSize = true;
            this.LblModel.ForeColor = System.Drawing.Color.White;
            this.LblModel.Location = new System.Drawing.Point(20, 50);
            this.LblModel.Name = "LblModel";
            this.LblModel.Size = new System.Drawing.Size(44, 15);
            this.LblModel.Text = "Model:";
            
            // 
            // TxtModel
            // 
            this.TxtModel.BackColor = System.Drawing.Color.FromArgb(40, 45, 60);
            this.TxtModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtModel.ForeColor = System.Drawing.Color.White;
            this.TxtModel.Location = new System.Drawing.Point(120, 48);
            this.TxtModel.Name = "TxtModel";
            this.TxtModel.Size = new System.Drawing.Size(200, 23);
            
            // 
            // LblOS
            // 
            this.LblOS.AutoSize = true;
            this.LblOS.ForeColor = System.Drawing.Color.White;
            this.LblOS.Location = new System.Drawing.Point(20, 80);
            this.LblOS.Name = "LblOS";
            this.LblOS.Size = new System.Drawing.Size(65, 15);
            this.LblOS.Text = "OS Version:";
            
            // 
            // TxtOS
            // 
            this.TxtOS.BackColor = System.Drawing.Color.FromArgb(40, 45, 60);
            this.TxtOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtOS.ForeColor = System.Drawing.Color.White;
            this.TxtOS.Location = new System.Drawing.Point(120, 78);
            this.TxtOS.Name = "TxtOS";
            this.TxtOS.Size = new System.Drawing.Size(200, 23);
            
            // 
            // LblCountry
            // 
            this.LblCountry.AutoSize = true;
            this.LblCountry.ForeColor = System.Drawing.Color.White;
            this.LblCountry.Location = new System.Drawing.Point(20, 110);
            this.LblCountry.Name = "LblCountry";
            this.LblCountry.Size = new System.Drawing.Size(53, 15);
            this.LblCountry.Text = "Country:";
            
            // 
            // TxtCountry
            // 
            this.TxtCountry.BackColor = System.Drawing.Color.FromArgb(40, 45, 60);
            this.TxtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCountry.ForeColor = System.Drawing.Color.White;
            this.TxtCountry.Location = new System.Drawing.Point(120, 108);
            this.TxtCountry.Name = "TxtCountry";
            this.TxtCountry.Size = new System.Drawing.Size(200, 23);
            
            // 
            // LblAppWipe
            // 
            this.LblAppWipe.AutoSize = true;
            this.LblAppWipe.ForeColor = System.Drawing.Color.White;
            this.LblAppWipe.Location = new System.Drawing.Point(20, 140);
            this.LblAppWipe.Name = "LblAppWipe";
            this.LblAppWipe.Size = new System.Drawing.Size(64, 15);
            this.LblAppWipe.Text = "App Wipe:";
            
            // 
            // TxtAppWipe
            // 
            this.TxtAppWipe.BackColor = System.Drawing.Color.FromArgb(40, 45, 60);
            this.TxtAppWipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAppWipe.ForeColor = System.Drawing.Color.White;
            this.TxtAppWipe.Location = new System.Drawing.Point(120, 138);
            this.TxtAppWipe.Name = "TxtAppWipe";
            this.TxtAppWipe.Size = new System.Drawing.Size(200, 23);
            
            // 
            // CbFactoryReset
            // 
            this.CbFactoryReset.AutoSize = true;
            this.CbFactoryReset.ForeColor = System.Drawing.Color.White;
            this.CbFactoryReset.Location = new System.Drawing.Point(120, 170);
            this.CbFactoryReset.Name = "CbFactoryReset";
            this.CbFactoryReset.Size = new System.Drawing.Size(95, 19);
            this.CbFactoryReset.Text = "Factory Reset";
            this.CbFactoryReset.UseVisualStyleBackColor = true;
            
            // 
            // CbWipe
            // 
            this.CbWipe.AutoSize = true;
            this.CbWipe.ForeColor = System.Drawing.Color.White;
            this.CbWipe.Location = new System.Drawing.Point(230, 170);
            this.CbWipe.Name = "CbWipe";
            this.CbWipe.Size = new System.Drawing.Size(55, 19);
            this.CbWipe.Text = "Wipe";
            this.CbWipe.UseVisualStyleBackColor = true;
            
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(50, 55, 75);
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(100, 200);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(100, 30);
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(50, 55, 75);
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(220, 200);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 30);
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            
            // 
            // DeviceSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(25, 30, 45);
            this.ClientSize = new System.Drawing.Size(350, 250);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.CbWipe);
            this.Controls.Add(this.CbFactoryReset);
            this.Controls.Add(this.TxtAppWipe);
            this.Controls.Add(this.LblAppWipe);
            this.Controls.Add(this.TxtCountry);
            this.Controls.Add(this.LblCountry);
            this.Controls.Add(this.TxtOS);
            this.Controls.Add(this.LblOS);
            this.Controls.Add(this.TxtModel);
            this.Controls.Add(this.LblModel);
            this.Controls.Add(this.TxtBrand);
            this.Controls.Add(this.LblBrand);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detailed Device Filters";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label LblBrand;
        private System.Windows.Forms.TextBox TxtBrand;
        private System.Windows.Forms.Label LblModel;
        private System.Windows.Forms.TextBox TxtModel;
        private System.Windows.Forms.Label LblOS;
        private System.Windows.Forms.TextBox TxtOS;
        private System.Windows.Forms.Label LblCountry;
        private System.Windows.Forms.TextBox TxtCountry;
        private System.Windows.Forms.Label LblAppWipe;
        private System.Windows.Forms.TextBox TxtAppWipe;
        private System.Windows.Forms.CheckBox CbFactoryReset;
        private System.Windows.Forms.CheckBox CbWipe;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
    }
}
