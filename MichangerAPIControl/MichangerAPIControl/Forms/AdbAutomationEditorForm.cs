using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MichangerAPIControl.Automation;
using MichangerAPIControl.Core;

namespace MichangerAPIControl.Forms
{
    public partial class AdbAutomationEditorForm : Form
    {
        private string _selectedDeviceId;
        private Bitmap _currentScreenshot;
        private bool _isCapturing = false;
        private bool _isSwipeMode = false;
        private Point _startPointSwipe;
        private Rectangle _selectionRectangle;
        private Point _initialMouseLocation;

        // Screen reference size constants (matches the PictureBox display size)
        // Portrait: 270x555, Landscape: 555x270
        private int _refWidth = 270;
        private int _refHeight = 555;
        private string _lastUiDumpXml;
        private bool _stopScript = false;

        public AdbAutomationEditorForm(string deviceId = null)
        {
            InitializeComponent();
            _selectedDeviceId = deviceId;
            
            // Optimization: Double buffering to avoid flicker
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
               ?.SetValue(picScreen, true, null);
            typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
               ?.SetValue(pnlViewContainer, true, null);
        }

        private async void AdbAutomationEditorForm_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(1000, 700);
            
            // Set reasonable splitter distance for wide screen
            splitMain.SplitterDistance = Math.Max(700, this.Width - 400); 

            await RefreshDeviceList();
            if (!string.IsNullOrEmpty(_selectedDeviceId))
            {
                cbbDevices.SelectedItem = _selectedDeviceId;
                await TakeScreenshot();
            }
        }

        private async Task RefreshDeviceList()
        {
            try
            {
                var devices = await AdbClient.GetDevicesAsync();
                cbbDevices.Items.Clear();
                foreach (var d in devices) cbbDevices.Items.Add(d);

                if (cbbDevices.Items.Count > 0 && cbbDevices.SelectedIndex == -1)
                {
                    if (!string.IsNullOrEmpty(_selectedDeviceId) && cbbDevices.Items.Contains(_selectedDeviceId))
                        cbbDevices.SelectedItem = _selectedDeviceId;
                    else
                        cbbDevices.SelectedIndex = 0;
                }
            }
            catch { }
        }

        private async void btnRefreshDevices_Click(object sender, EventArgs e) => await RefreshDeviceList();

        private async void cbbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newId = cbbDevices.SelectedItem?.ToString();
            if (_selectedDeviceId != newId)
            {
                _selectedDeviceId = newId;
                await TakeScreenshot();
            }
        }

        private async void btnScreenshot_Click(object sender, EventArgs e) => await TakeScreenshot();

        private async Task TakeScreenshot()
        {
            if (string.IsNullOrEmpty(_selectedDeviceId) || _isCapturing) return;

            _isCapturing = true;
            lblStatus.Text = "Capturing fresh screenshot...";

            try
            {
                // Use a dedicated folder for screenshots to avoid confusion
                string captureDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Captures");
                if (!Directory.Exists(captureDir)) Directory.CreateDirectory(captureDir);

                // Aggressively clean up ALL previous temp files for this device
                string pattern = $"tmp_scr_{_selectedDeviceId}_*.png";
                foreach (var oldFile in Directory.GetFiles(captureDir, pattern))
                {
                    try { File.SetAttributes(oldFile, FileAttributes.Normal); File.Delete(oldFile); } catch { }
                }

                string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string tempFile = Path.Combine(captureDir, $"tmp_scr_{_selectedDeviceId}_{timeStamp}.png");
                
                // Method 1: Try Direct ADB Shell Screencap (Most reliable for freshness)
                lblStatus.Text = "Capturing (ADB Shell)...";
                string devicePath = $"/sdcard/s_{timeStamp}.png";
                var capResult = await AdbClient.ExecuteCommandAsync($"-s {_selectedDeviceId} shell screencap -p {devicePath}");
                
                if (!capResult.Contains("Error"))
                {
                    await AdbClient.ExecuteCommandAsync($"-s {_selectedDeviceId} pull {devicePath} \"{tempFile}\"");
                    await AdbClient.ExecuteCommandAsync($"-s {_selectedDeviceId} shell rm {devicePath}");
                }

                // Method 2 Fallback: Try KAutoHelper if ADB pull failed
                if (!File.Exists(tempFile) || new FileInfo(tempFile).Length < 100)
                {
                    lblStatus.Text = "Fallback: KAutoHelper...";
                    await Task.Run(() => 
                    {
                        try { KAutoHelper.ADBHelper.ScreenShoot(_selectedDeviceId, false, tempFile); } catch { } 
                    });
                }

                if (File.Exists(tempFile) && new FileInfo(tempFile).Length > 0)
                {
                    // Update UI on the main thread
                    this.Invoke(new Action(() => {
                        // Dispose old images to release memory and lock
                        var oldImg = picScreen.Image;
                        picScreen.Image = null;
                        oldImg?.Dispose();
                        _currentScreenshot?.Dispose();

                        // Load new image via MemoryStream COPY
                        byte[] imageBytes = File.ReadAllBytes(tempFile);
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            _currentScreenshot = new Bitmap(ms);
                            
                            bool isLandscape = _currentScreenshot.Width > _currentScreenshot.Height;
                            if (isLandscape) 
                            { 
                                _refWidth = 555; _refHeight = 270;
                                splitMain.SplitterDistance = 600;
                            }
                            else 
                            { 
                                _refWidth = 270; _refHeight = 555; 
                                splitMain.SplitterDistance = 350;
                            }

                            picScreen.Size = new Size(_refWidth, _refHeight);
                            picScreen.Image = _currentScreenshot;
                        }
                        CenterPictureBox();
                        lblStatus.Text = $"Fresh Screenshot ready ({_refWidth}x{_refHeight}) at {DateTime.Now:HH:mm:ss}";
                    }));
                }
                else
                {
                    lblStatus.Text = "Critical: Failed to capture ANY screenshot.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Capture Error: " + ex.Message;
            }
            finally
            {
                _isCapturing = false;
            }
        }

        private void CenterPictureBox()
        {
            if (picScreen.Parent != null)
            {
                int left = (pnlViewContainer.ClientSize.Width - picScreen.Width) / 2;
                int top = (pnlViewContainer.ClientSize.Height - picScreen.Height) / 2;
                
                picScreen.Left = Math.Max(0, left);
                picScreen.Top = Math.Max(0, top);
            }
        }

        private Point _startPoint;
        private Rectangle _cropRect;
        private bool _isSelecting = false;

        private void pnlViewContainer_Resize(object sender, EventArgs e) => CenterPictureBox();

        private void picScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentScreenshot == null) return;
            
            if (_isSwipeMode)
            {
                _startPointSwipe = e.Location;
            }
            else
            {
                _isSelecting = true;
                _startPoint = e.Location;
                _cropRect = new Rectangle(e.Location, new Size()); // Reset crop rect
                picScreen.Invalidate();
            }
        }

        private void picScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || _currentScreenshot == null) return;

            if (_isSwipeMode)
            {
                txtCommandPreview.Text = $"Swipe|{_startPointSwipe.X}x{_startPointSwipe.Y}|{e.X}x{e.Y}";
            }
            else if (_isSelecting)
            {
                int x = Math.Min(_startPoint.X, e.X);
                int y = Math.Min(_startPoint.Y, e.Y);
                int w = Math.Abs(_startPoint.X - e.X);
                int h = Math.Abs(_startPoint.Y - e.Y);
                _cropRect = new Rectangle(x, y, w, h);
                picScreen.Invalidate();
                txtCommandPreview.Text = $"Crop (Select Area)";
            }
        }

        private void picScreen_MouseUp(object sender, MouseEventArgs e)
        {
            if (_currentScreenshot == null) return;
            
            if (!_isSwipeMode)
            {
                _isSelecting = false;
                if (_cropRect.Width > 0 && _cropRect.Height > 0)
                {
                    UpdateCropPreview();
                    txtCommandPreview.Text = $"Tap|{_cropRect.X}x{_cropRect.Y}";
                }
                else
                {
                    txtCommandPreview.Text = $"Tap|{e.X}x{e.Y}";
                }
                _cropRect = Rectangle.Empty; // Clear selection after mouse up
                picScreen.Invalidate();
            }
        }

        private void picScreen_Paint(object sender, PaintEventArgs e)
        {
            if (_isSelecting && _cropRect.Width > 0 && _cropRect.Height > 0)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    e.Graphics.DrawRectangle(pen, _cropRect);
                }
            }
        }

        private void UpdateCropPreview()
        {
            if (_currentScreenshot == null || _cropRect.Width <= 0 || _cropRect.Height <= 0) return;
            
            try
            {
                // Scale crop rect to real image dimensions
                double scaleX = (double)_currentScreenshot.Width / picScreen.Width;
                double scaleY = (double)_currentScreenshot.Height / picScreen.Height;

                int realX = (int)(_cropRect.X * scaleX);
                int realY = (int)(_cropRect.Y * scaleY);
                int realW = (int)(_cropRect.Width * scaleX);
                int realH = (int)(_cropRect.Height * scaleY);

                // Boundary check
                realX = Math.Max(0, Math.Min(realX, _currentScreenshot.Width - 1));
                realY = Math.Max(0, Math.Min(realY, _currentScreenshot.Height - 1));
                realW = Math.Max(1, Math.Min(realW, _currentScreenshot.Width - realX));
                realH = Math.Max(1, Math.Min(realH, _currentScreenshot.Height - realY));

                Rectangle realRect = new Rectangle(realX, realY, realW, realH);
                Bitmap cropped = _currentScreenshot.Clone(realRect, _currentScreenshot.PixelFormat);
                
                var oldImg = picPreviewCrop.Image;
                picPreviewCrop.Image = cropped;
                oldImg?.Dispose();
            }
            catch { }
        }

        private async void btnGetUIText_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedDeviceId)) return;
            lblStatus.Text = "Dumping UI hierarchy for map...";
            try
            {
                _lastUiDumpXml = await AdbClient.DumpUIAsync(_selectedDeviceId);
                if (string.IsNullOrEmpty(_lastUiDumpXml) || _lastUiDumpXml.Contains("Error"))
                {
                    lblStatus.Text = "UI Dump failed.";
                    return;
                }

                using (var picker = new AdbTextPickerForm(_lastUiDumpXml))
                {
                    if (picker.ShowDialog() == DialogResult.OK)
                    {
                        if (!string.IsNullOrEmpty(picker.SelectedCommand))
                        {
                            rtbScript.AppendText(picker.SelectedCommand + Environment.NewLine);
                            lblStatus.Text = "Command added from map.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "UI Map Error: " + ex.Message;
            }
        }

        private string ExtractTextFromXml(string xml, int x, int y)
        {
            try
            {
                // PictureBox reference size is 270x555 (Portrait) or 555x270 (Landscape).
                // XML dump coordinates are REAL device pixels.
                // We need to scale our reference coordinate to real pixels.
                double scaleX = (double)_currentScreenshot.Width / picScreen.Width;
                double scaleY = (double)_currentScreenshot.Height / picScreen.Height;
                int realX = (int)(x * scaleX);
                int realY = (int)(y * scaleY);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                
                // Find node whose bounds [x1,y1][x2,y2] contains(realX, realY)
                XmlNodeList nodes = doc.SelectNodes("//node");
                foreach (XmlNode node in nodes)
                {
                    string bounds = node.Attributes["bounds"]?.Value;
                    if (string.IsNullOrEmpty(bounds)) continue;

                    // Parse bounds: [0,0][1080,2400]
                    var parts = bounds.Split(new[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 4)
                    {
                        int x1 = int.Parse(parts[0]);
                        int y1 = int.Parse(parts[1]);
                        int x2 = int.Parse(parts[2]);
                        int y2 = int.Parse(parts[3]);

                        if (realX >= x1 && realX <= x2 && realY >= y1 && realY <= y2)
                        {
                            string text = node.Attributes["text"]?.Value;
                            if (string.IsNullOrEmpty(text)) text = node.Attributes["content-desc"]?.Value;
                            if (!string.IsNullOrEmpty(text)) return text;
                        }
                    }
                }
            }
            catch { }
            return null;
        }

        private void btnAddCommand_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCommandPreview.Text))
            {
                string cmd = txtCommandPreview.Text;
                if (!cmd.EndsWith(Environment.NewLine)) cmd += Environment.NewLine;
                rtbScript.AppendText(cmd);
                lblStatus.Text = "Command added to script.";
            }
        }

        private async void btnTestCommand_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedDeviceId) || string.IsNullOrEmpty(txtCommandPreview.Text)) return;
            string cmd = txtCommandPreview.Text;
            lblStatus.Text = $"Testing: {cmd}...";
            // Map our reference (270x555) back to real or percent in ADBCommand
            await Task.Run(() => ADBCommand.ExecuteCommand(_selectedDeviceId, cmd));
            lblStatus.Text = "Test complete.";
        }

        private async void btnRunScript_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedDeviceId) || rtbScript.Lines.Length == 0) return;
            var scriptLines = rtbScript.Lines.ToList();

            _stopScript = false;
            btnRunScript.Enabled = false;
            btnStopScript.Enabled = true;
            lblStatus.Text = "Running script with GOTO logic...";
            
            try
            {
                await Task.Run(() => 
                {
                    var lines = scriptLines;
                    var labels = new System.Collections.Generic.Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                    
                    // Pre-scan labels
                    for (int i = 0; i < lines.Count; i++)
                    {
                        string line = lines[i].Trim();
                        if (line.StartsWith("Label|", StringComparison.OrdinalIgnoreCase))
                        {
                            string labelName = line.Split('|')[1];
                            labels[labelName] = i;
                        }
                    }

                    int currentLine = 0;
                    while (currentLine < lines.Count && !_stopScript)
                    {
                        string line = lines[currentLine].Trim();
                        if (string.IsNullOrWhiteSpace(line)) { currentLine++; continue; }
                        
                        this.Invoke(new Action(() => lblStatus.Text = $"Row {currentLine + 1}: {line}"));
                        
                        string result = ADBCommand.ExecuteCommand(_selectedDeviceId, line);
                        
                        if (result.StartsWith("GOTO|"))
                        {
                            string target = result.Split('|')[1];
                            if (labels.ContainsKey(target))
                            {
                                currentLine = labels[target];
                                continue; // Jump to label line
                            }
                            else if (int.TryParse(target, out int lineNum))
                            {
                                currentLine = lineNum - 1; // 1-based to 0-based
                                continue;
                            }
                        }
                        else if (result == "STOP")
                        {
                            break;
                        }
                        else if (result == "FAIL_BRANCH")
                        {
                             // Optional: stop on failure? User usually wants branching or continue
                        }

                        currentLine++;
                        if (!line.ToLower().StartsWith("sleep") && currentLine < lines.Count)
                            System.Threading.Thread.Sleep(300);
                    }
                });
                lblStatus.Text = _stopScript ? "Script interupted by user." : "Script execution finished.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Execution Error: " + ex.Message;
            }
            finally
            {
                btnRunLine.Enabled = true;
                btnRunScript.Enabled = true;
                btnStopScript.Enabled = false;
                if (!_stopScript) lblStatus.Text = "Script finished.";
                else lblStatus.Text = "Script stopped.";
            }
        }

        private void btnStopScript_Click(object sender, EventArgs e)
        {
            _stopScript = true;
            lblStatus.Text = "Stopping...";
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            if (_currentScreenshot == null || picPreviewCrop.Image == null)
            {
                MessageBox.Show("Please select an area on the screen first.");
                return;
            }

            string imageName = txtImageName.Text.Trim();
            if (string.IsNullOrEmpty(imageName))
            {
                MessageBox.Show("Please enter a name for the image.");
                return;
            }

            try
            {
                string imagesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                if (!Directory.Exists(imagesDir)) Directory.CreateDirectory(imagesDir);

                string savePath = Path.Combine(imagesDir, imageName + ".png");
                picPreviewCrop.Image.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);
                
                lblStatus.Text = $"Image saved to {imageName}.png";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving image: " + ex.Message);
            }
        }

        private void btnGenClickImage_Click(object sender, EventArgs e)
        {
            string imageName = txtImageName.Text.Trim();
            if (string.IsNullOrEmpty(imageName)) return;
            string cmd = $"ClickImage|{imageName}.png";
            rtbScript.AppendText(cmd + Environment.NewLine);
            lblStatus.Text = "ClickImage command added.";
        }

        private void btnGenIfImageFound_Click(object sender, EventArgs e)
        {
            string imageName = txtImageName.Text.Trim();
            if (string.IsNullOrEmpty(imageName)) return;
            string cmd = $"IfImageFound|{imageName}.png|Goto:LABEL_NAME|Else:Continue";
            rtbScript.AppendText(cmd + Environment.NewLine);
            lblStatus.Text = "IfImageFound branch added.";
        }

        private void btnSendText_Click(object sender, EventArgs e)
        {
            string cmd = $"SendText|{txtAdvancedValue.Text}";
            rtbScript.AppendText(cmd + Environment.NewLine);
            lblStatus.Text = "SendText added to script.";
        }

        private void btnSendKey_Click(object sender, EventArgs e)
        {
            string cmd = $"SendKey|{txtAdvancedValue.Text}";
            rtbScript.AppendText(cmd + Environment.NewLine);
            lblStatus.Text = "SendKey added to script.";
        }

        private void btnLabel_Click(object sender, EventArgs e)
        {
            string cmd = $"Label|{txtAdvancedValue.Text}";
            rtbScript.AppendText(cmd + Environment.NewLine);
            lblStatus.Text = "Label added to script.";
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            string cmd = $"Goto|{txtAdvancedValue.Text}";
            rtbScript.AppendText(cmd + Environment.NewLine);
            lblStatus.Text = "Goto added to script.";
        }

        private async void btnRunLine_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedDeviceId)) return;
            int lineIndex = rtbScript.GetLineFromCharIndex(rtbScript.SelectionStart);
            if (lineIndex < 0 || lineIndex >= rtbScript.Lines.Length) return;
            
            string line = rtbScript.Lines[lineIndex];
            if (string.IsNullOrWhiteSpace(line)) return;

            lblStatus.Text = $"Running Line: {line}";
            await Task.Run(() => ADBCommand.ExecuteCommand(_selectedDeviceId, line));
            lblStatus.Text = "Line complete.";
        }

        private void btnClearScript_Click(object sender, EventArgs e) => rtbScript.Clear();

        private void btnSaveScript_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Files|*.txt", InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Script") };
            if (sfd.ShowDialog() == DialogResult.OK) File.WriteAllText(sfd.FileName, rtbScript.Text);
        }

        private void btnLoadScript_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Text Files|*.txt", InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Script") };
            if (ofd.ShowDialog() == DialogResult.OK) rtbScript.Text = File.ReadAllText(ofd.FileName);
        }

        private void cbxSwipeMode_CheckedChanged(object sender, EventArgs e) => _isSwipeMode = cbxSwipeMode.Checked;

        private void AdbAutomationEditorForm_MouseWheel(object sender, MouseEventArgs e)
        {
            // Zoom can be added later by scaling the 270x555 control
        }
        private void btnWaitRandom_Click(object sender, EventArgs e)
        {
            // Format: WaitRandom|min|max (milliseconds)
            // If txtAdvancedValue has "1000|3000" or "1000-3000", parse min/max
            string val = txtAdvancedValue.Text.Trim();
            string min = "1000", max = "3000";
            if (!string.IsNullOrEmpty(val))
            {
                var sep = val.Contains('|') ? new[] { '|' } : new[] { '-' };
                var parts = val.Split(sep, System.StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2) { min = parts[0].Trim(); max = parts[1].Trim(); }
                else if (parts.Length == 1) { min = "500"; max = parts[0].Trim(); }
            }
            string cmd = $"WaitRandom|{min}|{max}";
            rtbScript.AppendText(cmd + Environment.NewLine);
            lblStatus.Text = $"WaitRandom ({min}-{max}ms) added.";
        }

        private void btnLongPress_Click(object sender, EventArgs e)
        {
            // Use the coordinate from the command preview (set when user clicks on the screen)
            string preview = txtCommandPreview.Text.Trim();
            if (preview.StartsWith("Tap|", StringComparison.OrdinalIgnoreCase))
            {
                // Convert Tap|XxY -> LongPress|XxY
                string coordPart = preview.Substring(4);
                string cmd = $"LongPress|{coordPart}";
                rtbScript.AppendText(cmd + Environment.NewLine);
                lblStatus.Text = "LongPress added to script.";
            }
            else if (!string.IsNullOrEmpty(txtAdvancedValue.Text.Trim()))
            {
                // Fall back to manual value in Advanced box (e.g. "135x200")
                string cmd = $"LongPress|{txtAdvancedValue.Text.Trim()}";
                rtbScript.AppendText(cmd + Environment.NewLine);
                lblStatus.Text = "LongPress added to script.";
            }
            else
            {
                MessageBox.Show("Hãy click vào màn hình thiết bị trước để chọn tọa độ, hoặc nhập tọa độ (vd: 135x200) vào ô Advanced Value.", "Long Press", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOpenApp_Click(object sender, EventArgs e)
        {
            string pkg = txtAdvancedValue.Text.Trim();
            if (string.IsNullOrEmpty(pkg)) { MessageBox.Show("Vui lòng nhập package name vào ô Advanced Value"); return; }
            string cmd = $"OpenApp|{pkg}";
            rtbScript.AppendText(cmd + Environment.NewLine);
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            string pkg = txtAdvancedValue.Text.Trim();
            if (string.IsNullOrEmpty(pkg)) { MessageBox.Show("Vui lòng nhập package name vào ô Advanced Value"); return; }
            string cmd = $"CloseApp|{pkg}";
            rtbScript.AppendText(cmd + Environment.NewLine);
        }

        private void btnClearApp_Click(object sender, EventArgs e)
        {
            string pkg = txtAdvancedValue.Text.Trim();
            if (string.IsNullOrEmpty(pkg)) { MessageBox.Show("Vui lòng nhập package name vào ô Advanced Value"); return; }
            string cmd = $"ClearApp|{pkg}";
            rtbScript.AppendText(cmd + Environment.NewLine);
        }
    }
}
