namespace MichangerAPIControl.Forms
{
    partial class AdbAutomationEditorForm
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
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.pnlViewContainer = new System.Windows.Forms.Panel();
            this.picScreen = new System.Windows.Forms.PictureBox();
            this.tabRight = new System.Windows.Forms.TabControl();
            this.tabControls = new System.Windows.Forms.TabPage();
            this.grbScript = new System.Windows.Forms.GroupBox();
            this.rtbScript = new System.Windows.Forms.RichTextBox();
            this.flpScriptActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRunLine = new System.Windows.Forms.Button();
            this.btnRunScript = new System.Windows.Forms.Button();
            this.btnStopScript = new System.Windows.Forms.Button();
            this.btnClearScript = new System.Windows.Forms.Button();
            this.btnSaveScript = new System.Windows.Forms.Button();
            this.btnLoadScript = new System.Windows.Forms.Button();
            this.grbAppControl = new System.Windows.Forms.GroupBox();
            this.flpAppControl = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOpenApp = new System.Windows.Forms.Button();
            this.btnCloseApp = new System.Windows.Forms.Button();
            this.btnClearApp = new System.Windows.Forms.Button();
            this.grbAdvanced = new System.Windows.Forms.GroupBox();
            this.flpAdvanced = new System.Windows.Forms.FlowLayoutPanel();
            this.txtAdvancedValue = new System.Windows.Forms.TextBox();
            this.btnSendText = new System.Windows.Forms.Button();
            this.btnSendKey = new System.Windows.Forms.Button();
            this.btnLabel = new System.Windows.Forms.Button();
            this.btnGoto = new System.Windows.Forms.Button();
            this.btnWaitRandom = new System.Windows.Forms.Button();
            this.grbCommand = new System.Windows.Forms.GroupBox();
            this.flpCommand = new System.Windows.Forms.FlowLayoutPanel();
            this.cbxSwipeMode = new System.Windows.Forms.CheckBox();
            this.txtCommandPreview = new System.Windows.Forms.TextBox();
            this.btnTestCommand = new System.Windows.Forms.Button();
            this.btnGetUIText = new System.Windows.Forms.Button();
            this.btnAddCommand = new System.Windows.Forms.Button();
            this.btnLongPress = new System.Windows.Forms.Button();
            this.grbCrop = new System.Windows.Forms.GroupBox();
            this.picPreviewCrop = new System.Windows.Forms.PictureBox();
            this.flpCrop = new System.Windows.Forms.FlowLayoutPanel();
            this.txtImageName = new System.Windows.Forms.TextBox();
            this.btnCrop = new System.Windows.Forms.Button();
            this.btnGenClickImage = new System.Windows.Forms.Button();
            this.btnGenIfImageFound = new System.Windows.Forms.Button();
            this.grbDevice = new System.Windows.Forms.GroupBox();
            this.flpDevice = new System.Windows.Forms.FlowLayoutPanel();
            this.cbbDevices = new System.Windows.Forms.ComboBox();
            this.btnRefreshDevices = new System.Windows.Forms.Button();
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnlViewContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScreen)).BeginInit();
            this.tabRight.SuspendLayout();
            this.tabControls.SuspendLayout();
            this.grbScript.SuspendLayout();
            this.flpScriptActions.SuspendLayout();
            this.grbAppControl.SuspendLayout();
            this.flpAppControl.SuspendLayout();
            this.grbAdvanced.SuspendLayout();
            this.flpAdvanced.SuspendLayout();
            this.grbCommand.SuspendLayout();
            this.flpCommand.SuspendLayout();
            this.grbCrop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreviewCrop)).BeginInit();
            this.flpCrop.SuspendLayout();
            this.grbDevice.SuspendLayout();
            this.flpDevice.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.pnlViewContainer);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.tabRight);
            this.splitMain.Size = new System.Drawing.Size(1288, 887);
            this.splitMain.SplitterDistance = 750;
            this.splitMain.TabIndex = 0;
            // 
            // pnlViewContainer
            // 
            this.pnlViewContainer.AutoScroll = true;
            this.pnlViewContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlViewContainer.Controls.Add(this.picScreen);
            this.pnlViewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlViewContainer.Name = "pnlViewContainer";
            this.pnlViewContainer.Size = new System.Drawing.Size(750, 887);
            this.pnlViewContainer.TabIndex = 0;
            this.pnlViewContainer.Resize += new System.EventHandler(this.pnlViewContainer_Resize);
            // 
            // picScreen
            // 
            this.picScreen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picScreen.BackColor = System.Drawing.Color.Black;
            this.picScreen.Location = new System.Drawing.Point(-62, 39);
            this.picScreen.Name = "picScreen";
            this.picScreen.Size = new System.Drawing.Size(270, 555);
            this.picScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picScreen.TabIndex = 0;
            this.picScreen.TabStop = false;
            this.picScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.picScreen_Paint);
            this.picScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picScreen_MouseDown);
            this.picScreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picScreen_MouseMove);
            this.picScreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picScreen_MouseUp);
            // 
            // tabRight
            // 
            this.tabRight.Controls.Add(this.tabControls);
            this.tabRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRight.Location = new System.Drawing.Point(0, 0);
            this.tabRight.Name = "tabRight";
            this.tabRight.SelectedIndex = 0;
            this.tabRight.Size = new System.Drawing.Size(534, 887);
            this.tabRight.TabIndex = 0;
            // 
            // tabControls
            // 
            this.tabControls.AutoScroll = true;
            this.tabControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.tabControls.Controls.Add(this.grbScript);
            this.tabControls.Controls.Add(this.grbAppControl);
            this.tabControls.Controls.Add(this.grbAdvanced);
            this.tabControls.Controls.Add(this.grbCommand);
            this.tabControls.Controls.Add(this.grbCrop);
            this.tabControls.Controls.Add(this.grbDevice);
            this.tabControls.AutoScroll = true;
            this.tabControls.ForeColor = System.Drawing.Color.White;
            this.tabControls.Location = new System.Drawing.Point(4, 24);
            this.tabControls.Name = "tabControls";
            this.tabControls.Padding = new System.Windows.Forms.Padding(12);
            this.tabControls.Size = new System.Drawing.Size(526, 859);
            this.tabControls.TabIndex = 0;
            this.tabControls.Text = "Automation Tools";
            // 
            // grbScript
            // 
            this.grbScript.Controls.Add(this.rtbScript);
            this.grbScript.Controls.Add(this.flpScriptActions);
            this.grbScript.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbScript.Location = new System.Drawing.Point(12, 505);
            this.grbScript.Name = "grbScript";
            this.grbScript.Size = new System.Drawing.Size(502, 288);
            this.grbScript.TabIndex = 3;
            this.grbScript.TabStop = false;
            this.grbScript.Text = "Script Editor - Full Control";
            // 
            // rtbScript
            // 
            this.rtbScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbScript.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbScript.Location = new System.Drawing.Point(3, 19);
            this.rtbScript.Name = "rtbScript";
            this.rtbScript.Size = new System.Drawing.Size(496, 186);
            this.rtbScript.TabIndex = 0;
            this.rtbScript.Text = "";
            // 
            // flpScriptActions
            // 
            this.flpScriptActions.AutoSize = true;
            this.flpScriptActions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpScriptActions.Controls.Add(this.btnRunLine);
            this.flpScriptActions.Controls.Add(this.btnRunScript);
            this.flpScriptActions.Controls.Add(this.btnStopScript);
            this.flpScriptActions.Controls.Add(this.btnClearScript);
            this.flpScriptActions.Controls.Add(this.btnSaveScript);
            this.flpScriptActions.Controls.Add(this.btnLoadScript);
            this.flpScriptActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpScriptActions.Location = new System.Drawing.Point(3, 205);
            this.flpScriptActions.Name = "flpScriptActions";
            this.flpScriptActions.Padding = new System.Windows.Forms.Padding(5);
            this.flpScriptActions.Size = new System.Drawing.Size(496, 80);
            this.flpScriptActions.TabIndex = 1;
            // 
            // btnRunLine
            // 
            this.btnRunLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnRunLine.ForeColor = System.Drawing.Color.White;
            this.btnRunLine.Location = new System.Drawing.Point(8, 8);
            this.btnRunLine.Name = "btnRunLine";
            this.btnRunLine.Size = new System.Drawing.Size(76, 29);
            this.btnRunLine.TabIndex = 0;
            this.btnRunLine.Text = "Step";
            this.btnRunLine.UseVisualStyleBackColor = false;
            this.btnRunLine.Click += new System.EventHandler(this.btnRunLine_Click);
            // 
            // btnRunScript
            // 
            this.btnRunScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnRunScript.ForeColor = System.Drawing.Color.White;
            this.btnRunScript.Location = new System.Drawing.Point(90, 8);
            this.btnRunScript.Name = "btnRunScript";
            this.btnRunScript.Size = new System.Drawing.Size(82, 29);
            this.btnRunScript.TabIndex = 1;
            this.btnRunScript.Text = "Run All";
            this.btnRunScript.UseVisualStyleBackColor = false;
            this.btnRunScript.Click += new System.EventHandler(this.btnRunScript_Click);
            // 
            // btnStopScript
            // 
            this.btnStopScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnStopScript.Enabled = false;
            this.btnStopScript.ForeColor = System.Drawing.Color.White;
            this.btnStopScript.Location = new System.Drawing.Point(178, 8);
            this.btnStopScript.Name = "btnStopScript";
            this.btnStopScript.Size = new System.Drawing.Size(82, 29);
            this.btnStopScript.TabIndex = 2;
            this.btnStopScript.Text = "Stop";
            this.btnStopScript.UseVisualStyleBackColor = false;
            this.btnStopScript.Click += new System.EventHandler(this.btnStopScript_Click);
            // 
            // btnClearScript
            // 
            this.btnClearScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnClearScript.ForeColor = System.Drawing.Color.White;
            this.btnClearScript.Location = new System.Drawing.Point(266, 8);
            this.btnClearScript.Name = "btnClearScript";
            this.btnClearScript.Size = new System.Drawing.Size(82, 29);
            this.btnClearScript.TabIndex = 3;
            this.btnClearScript.Text = "Clear";
            this.btnClearScript.UseVisualStyleBackColor = false;
            this.btnClearScript.Click += new System.EventHandler(this.btnClearScript_Click);
            // 
            // btnSaveScript
            // 
            this.btnSaveScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSaveScript.ForeColor = System.Drawing.Color.White;
            this.btnSaveScript.Location = new System.Drawing.Point(8, 43);
            this.btnSaveScript.Name = "btnSaveScript";
            this.btnSaveScript.Size = new System.Drawing.Size(169, 29);
            this.btnSaveScript.TabIndex = 4;
            this.btnSaveScript.Text = "Save Script";
            this.btnSaveScript.UseVisualStyleBackColor = false;
            this.btnSaveScript.Click += new System.EventHandler(this.btnSaveScript_Click);
            // 
            // btnLoadScript
            // 
            this.btnLoadScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnLoadScript.ForeColor = System.Drawing.Color.White;
            this.btnLoadScript.Location = new System.Drawing.Point(183, 43);
            this.btnLoadScript.Name = "btnLoadScript";
            this.btnLoadScript.Size = new System.Drawing.Size(169, 29);
            this.btnLoadScript.TabIndex = 5;
            this.btnLoadScript.Text = "Load Script";
            this.btnLoadScript.UseVisualStyleBackColor = false;
            this.btnLoadScript.Click += new System.EventHandler(this.btnLoadScript_Click);
            // 
            // grbAppControl
            // 
            this.grbAppControl.AutoSize = true;
            this.grbAppControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grbAppControl.Controls.Add(this.flpAppControl);
            this.grbAppControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbAppControl.Location = new System.Drawing.Point(12, 419);
            this.grbAppControl.Name = "grbAppControl";
            this.grbAppControl.Size = new System.Drawing.Size(502, 86);
            this.grbAppControl.TabIndex = 5;
            this.grbAppControl.TabStop = false;
            this.grbAppControl.Text = "App Control";
            // 
            // flpAppControl
            // 
            this.flpAppControl.AutoSize = true;
            this.flpAppControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpAppControl.Controls.Add(this.btnOpenApp);
            this.flpAppControl.Controls.Add(this.btnCloseApp);
            this.flpAppControl.Controls.Add(this.btnClearApp);
            this.flpAppControl.Location = new System.Drawing.Point(3, 19);
            this.flpAppControl.MaximumSize = new System.Drawing.Size(500, 0);
            this.flpAppControl.Name = "flpAppControl";
            this.flpAppControl.Padding = new System.Windows.Forms.Padding(5);
            this.flpAppControl.Size = new System.Drawing.Size(313, 45);
            this.flpAppControl.TabIndex = 0;
            this.flpAppControl.WrapContents = true;
            // 
            // btnOpenApp
            // 
            this.btnOpenApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnOpenApp.ForeColor = System.Drawing.Color.White;
            this.btnOpenApp.Location = new System.Drawing.Point(8, 8);
            this.btnOpenApp.Name = "btnOpenApp";
            this.btnOpenApp.Size = new System.Drawing.Size(95, 29);
            this.btnOpenApp.TabIndex = 0;
            this.btnOpenApp.Text = "Open App";
            this.btnOpenApp.UseVisualStyleBackColor = false;
            this.btnOpenApp.Click += new System.EventHandler(this.btnOpenApp_Click);
            // 
            // btnCloseApp
            // 
            this.btnCloseApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCloseApp.ForeColor = System.Drawing.Color.White;
            this.btnCloseApp.Location = new System.Drawing.Point(109, 8);
            this.btnCloseApp.Name = "btnCloseApp";
            this.btnCloseApp.Size = new System.Drawing.Size(95, 29);
            this.btnCloseApp.TabIndex = 1;
            this.btnCloseApp.Text = "Close App";
            this.btnCloseApp.UseVisualStyleBackColor = false;
            this.btnCloseApp.Click += new System.EventHandler(this.btnCloseApp_Click);
            // 
            // btnClearApp
            // 
            this.btnClearApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnClearApp.ForeColor = System.Drawing.Color.White;
            this.btnClearApp.Location = new System.Drawing.Point(210, 8);
            this.btnClearApp.Name = "btnClearApp";
            this.btnClearApp.Size = new System.Drawing.Size(95, 29);
            this.btnClearApp.TabIndex = 2;
            this.btnClearApp.Text = "Clear App";
            this.btnClearApp.UseVisualStyleBackColor = false;
            this.btnClearApp.Click += new System.EventHandler(this.btnClearApp_Click);
            // 
            // grbAdvanced
            // 
            this.grbAdvanced.AutoSize = true;
            this.grbAdvanced.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grbAdvanced.Controls.Add(this.flpAdvanced);
            this.grbAdvanced.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbAdvanced.Location = new System.Drawing.Point(12, 333);
            this.grbAdvanced.Name = "grbAdvanced";
            this.grbAdvanced.Size = new System.Drawing.Size(502, 86);
            this.grbAdvanced.TabIndex = 4;
            this.grbAdvanced.TabStop = false;
            this.grbAdvanced.Text = "Advanced (Text/Key/Flow)";
            // 
            // flpAdvanced
            // 
            this.flpAdvanced.AutoSize = true;
            this.flpAdvanced.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpAdvanced.Controls.Add(this.txtAdvancedValue);
            this.flpAdvanced.Controls.Add(this.btnSendText);
            this.flpAdvanced.Controls.Add(this.btnSendKey);
            this.flpAdvanced.Controls.Add(this.btnLabel);
            this.flpAdvanced.Controls.Add(this.btnGoto);
            this.flpAdvanced.Controls.Add(this.btnWaitRandom);
            this.flpAdvanced.Location = new System.Drawing.Point(3, 19);
            this.flpAdvanced.MaximumSize = new System.Drawing.Size(500, 0);
            this.flpAdvanced.Name = "flpAdvanced";
            this.flpAdvanced.Padding = new System.Windows.Forms.Padding(5);
            this.flpAdvanced.Size = new System.Drawing.Size(480, 80);
            this.flpAdvanced.TabIndex = 0;
            this.flpAdvanced.WrapContents = true;
            // 
            // txtAdvancedValue
            // 
            this.txtAdvancedValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtAdvancedValue.ForeColor = System.Drawing.Color.White;
            this.txtAdvancedValue.Location = new System.Drawing.Point(8, 8);
            this.txtAdvancedValue.Name = "txtAdvancedValue";
            this.txtAdvancedValue.Size = new System.Drawing.Size(338, 23);
            this.txtAdvancedValue.TabIndex = 0;
            // 
            // btnSendText
            // 
            this.btnSendText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSendText.ForeColor = System.Drawing.Color.White;
            this.btnSendText.Location = new System.Drawing.Point(352, 8);
            this.btnSendText.Name = "btnSendText";
            this.btnSendText.Size = new System.Drawing.Size(82, 29);
            this.btnSendText.TabIndex = 1;
            this.btnSendText.Text = "Send Text";
            this.btnSendText.UseVisualStyleBackColor = false;
            this.btnSendText.Click += new System.EventHandler(this.btnSendText_Click);
            // 
            // btnSendKey
            // 
            this.btnSendKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSendKey.ForeColor = System.Drawing.Color.White;
            this.btnSendKey.Location = new System.Drawing.Point(440, 8);
            this.btnSendKey.Name = "btnSendKey";
            this.btnSendKey.Size = new System.Drawing.Size(82, 29);
            this.btnSendKey.TabIndex = 2;
            this.btnSendKey.Text = "Send Key";
            this.btnSendKey.UseVisualStyleBackColor = false;
            this.btnSendKey.Click += new System.EventHandler(this.btnSendKey_Click);
            // 
            // btnLabel
            // 
            this.btnLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnLabel.ForeColor = System.Drawing.Color.White;
            this.btnLabel.Location = new System.Drawing.Point(528, 8);
            this.btnLabel.Name = "btnLabel";
            this.btnLabel.Size = new System.Drawing.Size(82, 29);
            this.btnLabel.TabIndex = 3;
            this.btnLabel.Text = "Label";
            this.btnLabel.UseVisualStyleBackColor = false;
            this.btnLabel.Click += new System.EventHandler(this.btnLabel_Click);
            // 
            // btnGoto
            // 
            this.btnGoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnGoto.ForeColor = System.Drawing.Color.White;
            this.btnGoto.Location = new System.Drawing.Point(616, 8);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(76, 29);
            this.btnGoto.TabIndex = 4;
            this.btnGoto.Text = "Goto";
            this.btnGoto.UseVisualStyleBackColor = false;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // btnWaitRandom
            // 
            this.btnWaitRandom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnWaitRandom.ForeColor = System.Drawing.Color.White;
            this.btnWaitRandom.Location = new System.Drawing.Point(698, 8);
            this.btnWaitRandom.Name = "btnWaitRandom";
            this.btnWaitRandom.Size = new System.Drawing.Size(82, 29);
            this.btnWaitRandom.TabIndex = 5;
            this.btnWaitRandom.Text = "Wait Random";
            this.btnWaitRandom.UseVisualStyleBackColor = false;
            this.btnWaitRandom.Click += new System.EventHandler(this.btnWaitRandom_Click);
            // 
            // grbCommand
            // 
            this.grbCommand.AutoSize = true;
            this.grbCommand.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grbCommand.Controls.Add(this.flpCommand);
            this.grbCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbCommand.Location = new System.Drawing.Point(12, 241);
            this.grbCommand.Name = "grbCommand";
            this.grbCommand.Size = new System.Drawing.Size(502, 92);
            this.grbCommand.TabIndex = 2;
            this.grbCommand.TabStop = false;
            this.grbCommand.Text = "Command Builder (Click/Swipe)";
            // 
            // flpCommand
            // 
            this.flpCommand.AutoSize = true;
            this.flpCommand.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpCommand.Controls.Add(this.cbxSwipeMode);
            this.flpCommand.Controls.Add(this.txtCommandPreview);
            this.flpCommand.Controls.Add(this.btnTestCommand);
            this.flpCommand.Controls.Add(this.btnGetUIText);
            this.flpCommand.Controls.Add(this.btnAddCommand);
            this.flpCommand.Controls.Add(this.btnLongPress);
            this.flpCommand.Location = new System.Drawing.Point(3, 19);
            this.flpCommand.MaximumSize = new System.Drawing.Size(500, 0);
            this.flpCommand.Name = "flpCommand";
            this.flpCommand.Padding = new System.Windows.Forms.Padding(5);
            this.flpCommand.Size = new System.Drawing.Size(480, 150);
            this.flpCommand.TabIndex = 0;
            this.flpCommand.WrapContents = true;
            // 
            // cbxSwipeMode
            // 
            this.cbxSwipeMode.Location = new System.Drawing.Point(8, 8);
            this.cbxSwipeMode.Name = "cbxSwipeMode";
            this.cbxSwipeMode.Size = new System.Drawing.Size(233, 28);
            this.cbxSwipeMode.TabIndex = 4;
            this.cbxSwipeMode.Text = "Swipe Mode (Click and Drag)";
            this.cbxSwipeMode.CheckedChanged += new System.EventHandler(this.cbxSwipeMode_CheckedChanged);
            // 
            // txtCommandPreview
            // 
            this.txtCommandPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtCommandPreview.ForeColor = System.Drawing.Color.White;
            this.txtCommandPreview.Location = new System.Drawing.Point(247, 8);
            this.txtCommandPreview.Name = "txtCommandPreview";
            this.txtCommandPreview.ReadOnly = true;
            this.txtCommandPreview.Size = new System.Drawing.Size(338, 23);
            this.txtCommandPreview.TabIndex = 1;
            // 
            // btnTestCommand
            // 
            this.btnTestCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnTestCommand.ForeColor = System.Drawing.Color.White;
            this.btnTestCommand.Location = new System.Drawing.Point(591, 8);
            this.btnTestCommand.Name = "btnTestCommand";
            this.btnTestCommand.Size = new System.Drawing.Size(163, 35);
            this.btnTestCommand.TabIndex = 2;
            this.btnTestCommand.Text = "Test Command";
            this.btnTestCommand.UseVisualStyleBackColor = false;
            this.btnTestCommand.Click += new System.EventHandler(this.btnTestCommand_Click);
            // 
            // btnGetUIText
            // 
            this.btnGetUIText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnGetUIText.ForeColor = System.Drawing.Color.White;
            this.btnGetUIText.Location = new System.Drawing.Point(760, 8);
            this.btnGetUIText.Name = "btnGetUIText";
            this.btnGetUIText.Size = new System.Drawing.Size(163, 35);
            this.btnGetUIText.TabIndex = 0;
            this.btnGetUIText.Text = "Get Text Map";
            this.btnGetUIText.UseVisualStyleBackColor = false;
            this.btnGetUIText.Click += new System.EventHandler(this.btnGetUIText_Click);
            // 
            // btnAddCommand
            // 
            this.btnAddCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnAddCommand.ForeColor = System.Drawing.Color.White;
            this.btnAddCommand.Location = new System.Drawing.Point(929, 8);
            this.btnAddCommand.Name = "btnAddCommand";
            this.btnAddCommand.Size = new System.Drawing.Size(163, 35);
            this.btnAddCommand.TabIndex = 3;
            this.btnAddCommand.Text = "Add to Script";
            this.btnAddCommand.UseVisualStyleBackColor = false;
            this.btnAddCommand.Click += new System.EventHandler(this.btnAddCommand_Click);
            // 
            // btnLongPress
            // 
            this.btnLongPress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnLongPress.ForeColor = System.Drawing.Color.White;
            this.btnLongPress.Location = new System.Drawing.Point(1273, 8);
            this.btnLongPress.Name = "btnLongPress";
            this.btnLongPress.Size = new System.Drawing.Size(163, 35);
            this.btnLongPress.TabIndex = 5;
            this.btnLongPress.Text = "Long Press";
            this.btnLongPress.UseVisualStyleBackColor = false;
            this.btnLongPress.Click += new System.EventHandler(this.btnLongPress_Click);
            // 
            // grbCrop
            // 
            this.grbCrop.AutoSize = true;
            this.grbCrop.Controls.Add(this.picPreviewCrop);
            this.grbCrop.Controls.Add(this.flpCrop);
            this.grbCrop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbCrop.Location = new System.Drawing.Point(12, 104);
            this.grbCrop.Name = "grbCrop";
            this.grbCrop.Size = new System.Drawing.Size(502, 137);
            this.grbCrop.TabIndex = 1;
            this.grbCrop.TabStop = false;
            this.grbCrop.Text = "Image Search Builder (Crop)";
            // 
            // picPreviewCrop
            // 
            this.picPreviewCrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreviewCrop.Location = new System.Drawing.Point(12, 23);
            this.picPreviewCrop.Name = "picPreviewCrop";
            this.picPreviewCrop.Size = new System.Drawing.Size(93, 92);
            this.picPreviewCrop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreviewCrop.TabIndex = 0;
            this.picPreviewCrop.TabStop = false;
            // 
            // flpCrop
            // 
            this.flpCrop.AutoSize = true;
            this.flpCrop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpCrop.Controls.Add(this.txtImageName);
            this.flpCrop.Controls.Add(this.btnCrop);
            this.flpCrop.Controls.Add(this.btnGenClickImage);
            this.flpCrop.Controls.Add(this.btnGenIfImageFound);
            this.flpCrop.Location = new System.Drawing.Point(111, 23);
            this.flpCrop.MaximumSize = new System.Drawing.Size(380, 0);
            this.flpCrop.Name = "flpCrop";
            this.flpCrop.Padding = new System.Windows.Forms.Padding(5);
            this.flpCrop.Size = new System.Drawing.Size(380, 100);
            this.flpCrop.TabIndex = 1;
            this.flpCrop.WrapContents = true;
            // 
            // txtImageName
            // 
            this.txtImageName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtImageName.ForeColor = System.Drawing.Color.White;
            this.txtImageName.Location = new System.Drawing.Point(8, 8);
            this.txtImageName.Name = "txtImageName";
            this.txtImageName.Size = new System.Drawing.Size(233, 23);
            this.txtImageName.TabIndex = 1;
            // 
            // btnCrop
            // 
            this.btnCrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCrop.ForeColor = System.Drawing.Color.White;
            this.btnCrop.Location = new System.Drawing.Point(247, 8);
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(233, 35);
            this.btnCrop.TabIndex = 2;
            this.btnCrop.Text = "1. Crop and Save Image";
            this.btnCrop.UseVisualStyleBackColor = false;
            this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
            // 
            // btnGenClickImage
            // 
            this.btnGenClickImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnGenClickImage.ForeColor = System.Drawing.Color.White;
            this.btnGenClickImage.Location = new System.Drawing.Point(8, 49);
            this.btnGenClickImage.Name = "btnGenClickImage";
            this.btnGenClickImage.Size = new System.Drawing.Size(117, 35);
            this.btnGenClickImage.TabIndex = 3;
            this.btnGenClickImage.Text = "2a. + Click";
            this.btnGenClickImage.UseVisualStyleBackColor = false;
            this.btnGenClickImage.Click += new System.EventHandler(this.btnGenClickImage_Click);
            // 
            // btnGenIfImageFound
            // 
            this.btnGenIfImageFound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnGenIfImageFound.ForeColor = System.Drawing.Color.White;
            this.btnGenIfImageFound.Location = new System.Drawing.Point(131, 49);
            this.btnGenIfImageFound.Name = "btnGenIfImageFound";
            this.btnGenIfImageFound.Size = new System.Drawing.Size(111, 35);
            this.btnGenIfImageFound.TabIndex = 4;
            this.btnGenIfImageFound.Text = "2b. + If Found";
            this.btnGenIfImageFound.UseVisualStyleBackColor = false;
            this.btnGenIfImageFound.Click += new System.EventHandler(this.btnGenIfImageFound_Click);
            // 
            // grbDevice
            // 
            this.grbDevice.AutoSize = true;
            this.grbDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grbDevice.Controls.Add(this.flpDevice);
            this.grbDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbDevice.Location = new System.Drawing.Point(12, 12);
            this.grbDevice.Name = "grbDevice";
            this.grbDevice.Size = new System.Drawing.Size(502, 92);
            this.grbDevice.TabIndex = 0;
            this.grbDevice.TabStop = false;
            this.grbDevice.Text = "Device Control";
            // 
            // flpDevice
            // 
            this.flpDevice.AutoSize = true;
            this.flpDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpDevice.Controls.Add(this.cbbDevices);
            this.flpDevice.Controls.Add(this.btnRefreshDevices);
            this.flpDevice.Controls.Add(this.btnScreenshot);
            this.flpDevice.Location = new System.Drawing.Point(3, 19);
            this.flpDevice.MaximumSize = new System.Drawing.Size(500, 0);
            this.flpDevice.Name = "flpDevice";
            this.flpDevice.Padding = new System.Windows.Forms.Padding(5);
            this.flpDevice.Size = new System.Drawing.Size(480, 80);
            this.flpDevice.TabIndex = 0;
            this.flpDevice.WrapContents = true;
            // 
            // cbbDevices
            // 
            this.cbbDevices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cbbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbDevices.ForeColor = System.Drawing.Color.White;
            this.cbbDevices.FormattingEnabled = true;
            this.cbbDevices.Location = new System.Drawing.Point(8, 8);
            this.cbbDevices.Name = "cbbDevices";
            this.cbbDevices.Size = new System.Drawing.Size(233, 23);
            this.cbbDevices.TabIndex = 0;
            this.cbbDevices.SelectedIndexChanged += new System.EventHandler(this.cbbDevices_SelectedIndexChanged);
            // 
            // btnRefreshDevices
            // 
            this.btnRefreshDevices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnRefreshDevices.ForeColor = System.Drawing.Color.White;
            this.btnRefreshDevices.Location = new System.Drawing.Point(247, 8);
            this.btnRefreshDevices.Name = "btnRefreshDevices";
            this.btnRefreshDevices.Size = new System.Drawing.Size(93, 29);
            this.btnRefreshDevices.TabIndex = 1;
            this.btnRefreshDevices.Text = "Refresh";
            this.btnRefreshDevices.UseVisualStyleBackColor = false;
            this.btnRefreshDevices.Click += new System.EventHandler(this.btnRefreshDevices_Click);
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnScreenshot.ForeColor = System.Drawing.Color.White;
            this.btnScreenshot.Location = new System.Drawing.Point(346, 8);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(130, 35);
            this.btnScreenshot.TabIndex = 2;
            this.btnScreenshot.Text = "Screenshot";
            this.btnScreenshot.UseVisualStyleBackColor = false;
            this.btnScreenshot.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 887);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1288, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            // 
            // AdbAutomationEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1288, 909);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(931, 686);
            this.Name = "AdbAutomationEditorForm";
            this.Text = "ADB Automation Editor & Coordinate Picker";
            this.Load += new System.EventHandler(this.AdbAutomationEditorForm_Load);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.pnlViewContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picScreen)).EndInit();
            this.tabRight.ResumeLayout(false);
            this.tabControls.ResumeLayout(false);
            this.tabControls.PerformLayout();
            this.grbScript.ResumeLayout(false);
            this.grbScript.PerformLayout();
            this.flpScriptActions.ResumeLayout(false);
            this.grbAppControl.ResumeLayout(false);
            this.grbAppControl.PerformLayout();
            this.flpAppControl.ResumeLayout(false);
            this.grbAdvanced.ResumeLayout(false);
            this.grbAdvanced.PerformLayout();
            this.flpAdvanced.ResumeLayout(false);
            this.flpAdvanced.PerformLayout();
            this.grbCommand.ResumeLayout(false);
            this.grbCommand.PerformLayout();
            this.flpCommand.ResumeLayout(false);
            this.flpCommand.PerformLayout();
            this.grbCrop.ResumeLayout(false);
            this.grbCrop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreviewCrop)).EndInit();
            this.flpCrop.ResumeLayout(false);
            this.flpCrop.PerformLayout();
            this.grbDevice.ResumeLayout(false);
            this.grbDevice.PerformLayout();
            this.flpDevice.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox grbAppControl;
        private System.Windows.Forms.FlowLayoutPanel flpAppControl;
        private System.Windows.Forms.Button btnOpenApp;
        private System.Windows.Forms.Button btnCloseApp;
        private System.Windows.Forms.Button btnClearApp;
        private System.Windows.Forms.Button btnWaitRandom;
        private System.Windows.Forms.Button btnLongPress;
        private System.Windows.Forms.FlowLayoutPanel flpDevice;
        private System.Windows.Forms.FlowLayoutPanel flpCrop;
        private System.Windows.Forms.FlowLayoutPanel flpCommand;
        private System.Windows.Forms.FlowLayoutPanel flpAdvanced;
        private System.Windows.Forms.FlowLayoutPanel flpScriptActions;

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel pnlViewContainer;
        private System.Windows.Forms.PictureBox picScreen;
        private System.Windows.Forms.TabControl tabRight;
        private System.Windows.Forms.TabPage tabControls;
        private System.Windows.Forms.GroupBox grbDevice;
        private System.Windows.Forms.ComboBox cbbDevices;
        private System.Windows.Forms.Button btnRefreshDevices;
        private System.Windows.Forms.Button btnScreenshot;
        private System.Windows.Forms.GroupBox grbCrop;
        private System.Windows.Forms.PictureBox picPreviewCrop;
        private System.Windows.Forms.TextBox txtImageName;
        private System.Windows.Forms.Button btnCrop;
        private System.Windows.Forms.Button btnGenClickImage;
        private System.Windows.Forms.Button btnGenIfImageFound;
        private System.Windows.Forms.GroupBox grbCommand;
        private System.Windows.Forms.TextBox txtCommandPreview;
        private System.Windows.Forms.Button btnTestCommand;
        private System.Windows.Forms.Button btnGetUIText;
        private System.Windows.Forms.Button btnAddCommand;
        private System.Windows.Forms.CheckBox cbxSwipeMode;
        private System.Windows.Forms.GroupBox grbScript;
        private System.Windows.Forms.RichTextBox rtbScript;
        private System.Windows.Forms.Button btnRunLine;
        private System.Windows.Forms.Button btnRunScript;
        private System.Windows.Forms.Button btnStopScript;
        private System.Windows.Forms.Button btnClearScript;
        private System.Windows.Forms.Button btnSaveScript;
        private System.Windows.Forms.Button btnLoadScript;
        private System.Windows.Forms.GroupBox grbAdvanced;
        private System.Windows.Forms.TextBox txtAdvancedValue;
        private System.Windows.Forms.Button btnSendText;
        private System.Windows.Forms.Button btnSendKey;
        private System.Windows.Forms.Button btnLabel;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}
