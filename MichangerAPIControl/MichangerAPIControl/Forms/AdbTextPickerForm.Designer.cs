namespace MichangerAPIControl.Forms
{
    partial class AdbTextPickerForm
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
            this.dgvText = new System.Windows.Forms.DataGridView();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnAddIfFound = new System.Windows.Forms.Button();
            this.btnAddTapText = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvText)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();

            // dgvText
            this.dgvText.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvText.Location = new System.Drawing.Point(0, 0);
            this.dgvText.Name = "dgvText";
            this.dgvText.ReadOnly = true;
            this.dgvText.RowHeadersVisible = false;
            this.dgvText.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvText.Size = new System.Drawing.Size(800, 400);

            // pnlActions
            this.pnlActions.Controls.Add(this.btnAddIfFound);
            this.pnlActions.Controls.Add(this.btnAddTapText);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(0, 400);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(10);
            this.pnlActions.Size = new System.Drawing.Size(800, 50);

            // btnAddIfFound
            this.btnAddIfFound.Location = new System.Drawing.Point(10, 10);
            this.btnAddIfFound.Name = "btnAddIfFound";
            this.btnAddIfFound.Size = new System.Drawing.Size(250, 30);
            this.btnAddIfFound.Text = "Add If Text Found Branch";
            this.btnAddIfFound.UseVisualStyleBackColor = true;
            this.btnAddIfFound.Click += new System.EventHandler(this.btnAddIfFound_Click);

            // btnAddTapText
            this.btnAddTapText.Location = new System.Drawing.Point(270, 10);
            this.btnAddTapText.Name = "btnAddTapText";
            this.btnAddTapText.Size = new System.Drawing.Size(250, 30);
            this.btnAddTapText.Text = "Add TapText Command";
            this.btnAddTapText.UseVisualStyleBackColor = true;
            this.btnAddTapText.Click += new System.EventHandler(this.btnAddTapText_Click);

            // AdbTextPickerForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvText);
            this.Controls.Add(this.pnlActions);
            this.Name = "AdbTextPickerForm";
            this.Text = "ADB UI Text Mapper — MichangerAPIControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            ((System.ComponentModel.ISupportInitialize)(this.dgvText)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvText;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnAddIfFound;
        private System.Windows.Forms.Button btnAddTapText;
    }
}
