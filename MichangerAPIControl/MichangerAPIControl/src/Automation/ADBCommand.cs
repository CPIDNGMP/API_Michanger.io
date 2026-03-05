using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using KAutoHelper;
using MichangerAPIControl.Core;

namespace MichangerAPIControl.Automation
{
    public class ADBCommand
    {
        private static Random _random = new Random();
        
        public static string Openapp(string deviceid, string Command)
        {
            string[] parts = Command.Split('|');
            if (parts.Length >= 2)
            {
                string package = parts[1];
                string CMDopenapp = $"-s {deviceid} shell monkey -p {package} 1";
                Core.AdbClient.ExecuteCommandAsync(CMDopenapp).GetAwaiter().GetResult();
                return "NEXT";
            }
            return "Fail: OpenApp package missing";
        }

        public static string Closeapp(string deviceid, string Command)
        {
            string[] parts = Command.Split('|');
            if (parts.Length >= 2)
            {
                string package = parts[1];
                string CMDCloseApp = $"-s {deviceid} shell am force-stop {package}";
                Core.AdbClient.ExecuteCommandAsync(CMDCloseApp).GetAwaiter().GetResult();
                return "NEXT";
            }
            return "Fail: CloseApp package missing";
        }

        public static string ClearApp(string deviceid, string Command)
        {
            string[] parts = Command.Split('|');
            if (parts.Length >= 2)
            {
                string package = parts[1];
                string CMD = $"-s {deviceid} shell pm clear {package}";
                Core.AdbClient.ExecuteCommandAsync(CMD).GetAwaiter().GetResult();
                return "NEXT";
            }
            return "Fail: ClearApp package missing";
        }

        public static string WaitRandom(string Command)
        {
            string[] parts = Command.Split('|');
            if (parts.Length >= 3)
            {
                if (int.TryParse(parts[1], out int min) && int.TryParse(parts[2], out int max))
                {
                    int delay = _random.Next(min, max);
                    Thread.Sleep(delay);
                    return "NEXT";
                }
            }
            return "Fail: WaitRandom parameters invalid";
        }

        public static string Tap(string Deviceid, string Command, int picBoxRefWidth = 270, int picBoxRefHeight = 555)
        {
            string[] Position = Command.Split('|');
            if (Position.Length < 2) return "Lỗi tham chiếu! " + Command;

            int mousx = 0, mousey = 0;
            bool isPixel = false;

            if (Position.Length >= 3)
            {
                // Format: Tap|X|Y (Direct Pixels)
                if (int.TryParse(Position[1], out mousx) && int.TryParse(Position[2], out mousey))
                {
                    isPixel = true;
                }
            }
            else
            {
                // Format: Tap|XxY (Reference based)
                string[] TapArr = Position[1].Split('x');
                if (TapArr.Length >= 2)
                {
                    int.TryParse(TapArr[0], out mousx);
                    int.TryParse(TapArr[1], out mousey);
                }
            }

            if (isPixel)
            {
                KAutoHelper.ADBHelper.Tap(Deviceid, mousx, mousey);
            }
            else
            {
                double xxkey = ((double)mousx / picBoxRefWidth) * 100;
                double yykey = ((double)mousey / picBoxRefHeight) * 100;
                KAutoHelper.ADBHelper.TapByPercent(Deviceid, xxkey, yykey, 1);
            }
            
            return "NEXT";
        }

        public static string Zoom(string Deviceid, string Command, bool isZoomIn, int picBoxRefWidth = 270, int picBoxRefHeight = 555)
        {
            string[] Position = Command.Split('|');
            if (Position.Length < 2) return "Lỗi tham chiếu! " + Command;

            string[] TapArr = Position[1].Split('x');
            if (TapArr.Length < 2) return "Lỗi tham chiếu! " + Command;

            if (int.TryParse(TapArr[0], out int mousx) && int.TryParse(TapArr[1], out int mousey))
            {
                var screenSize = KAutoHelper.ADBHelper.GetScreenResolution(Deviceid);
                int screenWidth = screenSize.X;
                int screenHeight = screenSize.Y;

                int realX = (int)((double)mousx / picBoxRefWidth * screenWidth);
                int realY = (int)((double)mousey / picBoxRefHeight * screenHeight);

                int dragPixels = (int)(screenHeight * 0.2);
                int endY = isZoomIn ? (realY + dragPixels) : (realY - dragPixels);
                if (endY < 0) endY = 0;
                if (endY > screenHeight) endY = screenHeight;

                string cmdTap = $"input swipe {realX} {realY} {realX} {realY} 50";
                string cmdDrag = $"input swipe {realX} {realY} {realX} {endY} 1000";
                
                string fullCmd = $"-s {Deviceid} shell \"{cmdTap} && {cmdDrag}\"";
                Core.AdbClient.ExecuteCommandAsync(fullCmd).GetAwaiter().GetResult();
                
                return Command;
            }
            return "Lỗi giá trị! " + Command;
        }

        public static string DoubleTap(string Deviceid, string Command, int picBoxRefWidth = 270, int picBoxRefHeight = 555)
        {
            string[] Position = Command.Split('|');
            if (Position.Length >= 2)
            {
                string[] TapArr = Position[1].Split('x');
                if (TapArr.Length >= 2)
                {
                    if (int.TryParse(TapArr[0], out int mousx) && int.TryParse(TapArr[1], out int mousey))
                    {
                        double xxkey = ((double)mousx / picBoxRefWidth) * 100;
                        double yykey = ((double)mousey / picBoxRefHeight) * 100;

                        KAutoHelper.ADBHelper.TapByPercent(Deviceid, xxkey, yykey, 1);
                        Thread.Sleep(100);
                        KAutoHelper.ADBHelper.TapByPercent(Deviceid, xxkey, yykey, 1);
                        return "NEXT";
                    }
                }
            }
            return "Fail: DoubleTap reference error";
        }

        public static string LongPress(string Deviceid, string Command, int picBoxRefWidth = 270, int picBoxRefHeight = 555)
        {
            string[] Position = Command.Split('|');
            if (Position.Length >= 2)
            {
                var screensize = KAutoHelper.ADBHelper.GetScreenResolution(Deviceid);
                string[] TapArr = Position[1].Split('x');
                if (TapArr.Length >= 2)
                {
                    if (int.TryParse(TapArr[0], out int mousx) && int.TryParse(TapArr[1], out int mousey))
                    {
                        int xxkey = (int)((double)mousx / picBoxRefWidth * screensize.X);
                        int yykey = (int)((double)mousey / picBoxRefHeight * screensize.Y);

                        KAutoHelper.ADBHelper.LongPress(Deviceid, xxkey, yykey, 1000);
                        return "NEXT";
                    }
                }
            }
            return "Fail: LongPress reference error";
        }

        public static string Swipe(string Deviceid, string Command, int picBoxRefWidth = 270, int picBoxRefHeight = 555)
        {
            string[] Tap = Command.Split('|');
            if (Tap.Length >= 3)
            {
                string[] pos1split = Tap[1].Split('x');
                string[] pos2split = Tap[2].Split('x');

                if (pos1split.Length >= 2 && pos2split.Length >= 2)
                {
                    if (int.TryParse(pos1split[0], out int x1) && int.TryParse(pos1split[1], out int y1) &&
                        int.TryParse(pos2split[0], out int x2) && int.TryParse(pos2split[1], out int y2))
                    {
                        double xxkey1 = ((double)x1 / picBoxRefWidth) * 100;
                        double yykey1 = ((double)y1 / picBoxRefHeight) * 100;
                        double xxkey2 = ((double)x2 / picBoxRefWidth) * 100;
                        double yykey2 = ((double)y2 / picBoxRefHeight) * 100;

                        KAutoHelper.ADBHelper.SwipeByPercent(Deviceid, xxkey1, yykey1, xxkey2, yykey2, 100);
                        return "NEXT";
                    }
                }
            }
            return "Fail: Swipe reference error";
        }

        public static string Sleep(string Deviceid, string Command)
        {
            string[] Tap = Command.Split('|');
            if (Tap.Length >= 2)
            {
                if (int.TryParse(Tap[1], out int sleeptime))
                {
                    Thread.Sleep(sleeptime);
                    return "NEXT";
                }
            }
            return "Fail: Sleep time invalid";
        }

        public static string Send(string Deviceid, string Command)
        {
            string[] Position = Command.Split('|');
            if (Position.Length >= 2)
            {
                string key = Position[1];
                switch (key)
                {
                    case "Home":
                        KAutoHelper.ADBHelper.Key(Deviceid, KAutoHelper.ADBKeyEvent.KEYCODE_HOME);
                        break;
                    case "Back":
                        KAutoHelper.ADBHelper.Key(Deviceid, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
                        break;
                    case "AppSwitch":
                        KAutoHelper.ADBHelper.Key(Deviceid, KAutoHelper.ADBKeyEvent.KEYCODE_APP_SWITCH);
                        break;
                    default:
                        KAutoHelper.ADBHelper.InputText(Deviceid, key);
                        break;
                }
                return Command;
            }
            return "Lỗi tham chiếu! " + Command;
        }

        public static string TapText(string deviceid, string Command)
        {
            string[] parts = Command.Split('|');
            if (parts.Length < 2) return "Lỗi tham chiếu: " + Command;
            
            string targetText = parts[1];
            try
            {
                // Run sync for internal command execution
                string xml = Core.AdbClient.DumpUIAsync(deviceid).GetAwaiter().GetResult();
                if (string.IsNullOrEmpty(xml) || xml.Contains("Error")) return "Lỗi: " + xml;

                var doc = new System.Xml.XmlDocument();
                doc.LoadXml(xml);
                var nodes = doc.SelectNodes("//node");
                foreach (System.Xml.XmlNode node in nodes)
                {
                    string text = node.Attributes["text"]?.Value;
                    string desc = node.Attributes["content-desc"]?.Value;
                    if (text == targetText || desc == targetText)
                    {
                        string bounds = node.Attributes["bounds"]?.Value;
                        if (!string.IsNullOrEmpty(bounds))
                        {
                            var bParts = bounds.Split(new[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (bParts.Length == 4)
                            {
                                int x1 = int.Parse(bParts[0]);
                                int y1 = int.Parse(bParts[1]);
                                int x2 = int.Parse(bParts[2]);
                                int y2 = int.Parse(bParts[3]);
                                KAutoHelper.ADBHelper.Tap(deviceid, (x1 + x2) / 2, (y1 + y2) / 2);
                                return Command;
                            }
                        }
                    }
                }
                return "Fail: Text not found";
            }
            catch (Exception ex) { return "Error: " + ex.Message; }
        }

        public static string ImageFound(string deviceid, string Command)
        {
            string[] FullCommand = Command.Split('|');
            string imageFolderPath = Path.Combine(Application.StartupPath, "Script\\Image");
            if (FullCommand.Length >= 3)
            {
                string ImageName = FullCommand[1];
                string ImagePath = Path.Combine(imageFolderPath, ImageName + ".png");
                
                string script = FullCommand[2].ToLower().Contains("timeout") ? (FullCommand.Length > 3 ? FullCommand[3] : "") : FullCommand[2];

                switch (script)
                {
                    case "ClickAndContinue":
                        return ClickImage(deviceid, ImagePath) == "OK" ? "NEXT" : "FAIL_BRANCH";
                    case "RunScript":
                        if (FindImage(deviceid, ImagePath) == "OK")
                        {
                            int scriptIndex = FullCommand[2].ToLower().Contains("timeout") ? 3 : 2;
                            return (FullCommand.Length > scriptIndex + 1) ? $"RUNSCRIPT|{FullCommand[scriptIndex]}" : "FAIL: Missing script name";
                        }
                        return "FAIL_BRANCH";
                    case "IfTextFound":
                    case "TextFound":
                        return TextFound(deviceid, Command);
                    case "Continue":
                        return FindImage(deviceid, ImagePath) == "OK" ? "NEXT" : "FAIL_BRANCH";
                    case "Goto":
                        if (FindImage(deviceid, ImagePath) == "OK")
                        {
                             // Syntax: IfImageFound|ImgName|Goto|LabelName
                             return (FullCommand.Length >= 4) ? $"GOTO|{FullCommand[3]}" : "NEXT";
                        }
                        return "NEXT";
                    default:
                        // Support Branching Syntax: IfImageFound|Image|Goto:Label1|Else:Label2
                        if (FindImage(deviceid, ImagePath) == "OK")
                        {
                             foreach(var p in FullCommand) if(p.StartsWith("Goto:", StringComparison.OrdinalIgnoreCase)) return $"GOTO|{p.Substring(5)}";
                             return "NEXT";
                        }
                        else
                        {
                             foreach(var p in FullCommand) if(p.StartsWith("Else:", StringComparison.OrdinalIgnoreCase)) return $"GOTO|{p.Substring(5)}";
                             return "NEXT";
                        }
                }
            }
            return "Fail: ImageFound ref error";
        }

        public static string ImageNotFound(string deviceid, string Command)
        {
            string[] FullCommand = Command.Split('|');
            string imageFolderPath = Path.Combine(Application.StartupPath, "Script\\Image");
            if (FullCommand.Length >= 3)
            {
                string ImageName = FullCommand[1];
                string ImagePath = Path.Combine(imageFolderPath, ImageName + ".png");

                string script = FullCommand[2].ToLower().Contains("timeout") ? (FullCommand.Length > 3 ? FullCommand[3] : "") : FullCommand[2];

                switch (script)
                {
                    case "Continue":
                        return FindImage(deviceid, ImagePath) == "OK" ? Command + " FailFound" : Command;
                    case "RunScript":
                        if (FindImage(deviceid, ImagePath) == "OK") return "Image Found! Skip Script.";
                        int scriptIndex = FullCommand[2].ToLower().Contains("timeout") ? 3 : 2;
                        return (FullCommand.Length > scriptIndex + 1) ? $"{FullCommand[scriptIndex]}|{FullCommand[scriptIndex + 1]}" : "Lỗi thiếu tham số script!";
                    default:
                        return "Sai cú pháp!";
                }
            }
            return "Lỗi tham chiếu! " + Command;
        }

        public static string ClickImage(string deviceId, string imagePath)
        {
            if (!File.Exists(imagePath)) return "Fail: Image not found";
            try
            {
                byte[] imgBytes = File.ReadAllBytes(imagePath);
                using (MemoryStream ms = new MemoryStream(imgBytes))
                {
                    using (Bitmap image = new Bitmap(ms))
                    {
                        var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceId, false);
                        if (screen != null)
                        {
                            var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, image);
                            if (point != null)
                            {
                                KAutoHelper.ADBHelper.Tap(deviceId, point.Value.X, point.Value.Y);
                                return "OK";
                            }
                            return "Fail: Image not found on screen";
                        }
                        return "Fail: Screenshot failed";
                    }
                }
            }
            catch (Exception ex) { return "Error: " + ex.Message; }
        }

        public static string FindImage(string deviceId, string imagePath)
        {
            if (!File.Exists(imagePath)) return "Fail";
            try
            {
                byte[] imgBytes = File.ReadAllBytes(imagePath);
                using (MemoryStream ms = new MemoryStream(imgBytes))
                {
                    using (Bitmap image = new Bitmap(ms))
                    {
                        var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceId, false);
                        if (screen != null)
                        {
                            var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, image);
                            return point != null ? "OK" : "Fail";
                        }
                        return "Fail";
                    }
                }
            }
            catch { return "Fail"; }
        }

        public static string TextFound(string deviceId, string command)
        {
            try
            {
                var parts = command.Split('|');
                if (parts.Length < 2) return "FAIL_BRANCH";
                string targetText = parts[1];

                string xml = Task.Run(() => AdbClient.DumpUIAsync(deviceId)).Result;
                if (string.IsNullOrEmpty(xml)) return "FAIL_BRANCH";

                bool found = xml.Contains($"text=\"{targetText}\"") || xml.Contains($"content-desc=\"{targetText}\"");
                
                if (found)
                {
                    // Branching: IfTextFound|Text|Goto:Label|Else:Label
                    foreach(var p in parts) if(p.StartsWith("Goto:", StringComparison.OrdinalIgnoreCase)) return $"GOTO|{p.Substring(5)}";
                    return "NEXT";
                }
                else
                {
                    foreach(var p in parts) if(p.StartsWith("Else:", StringComparison.OrdinalIgnoreCase)) return $"GOTO|{p.Substring(5)}";
                    return "NEXT";
                }
            }
            catch { return "FAIL_BRANCH"; }
        }

        public static string ExecuteCommand(string deviceId, string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return "NEXT";
            
            string[] parts = line.Split('|');
            string cmdName = parts[0].ToLower();

            try
            {
                switch (cmdName)
                {
                    case "label":
                        return "NEXT"; // Labels are handled by the runner pre-scan
                    case "goto":
                        return parts.Length > 1 ? "GOTO|" + parts[1] : "NEXT";
                    case "tap":
                        return Tap(deviceId, line);
                    case "swipe":
                        return Swipe(deviceId, line);
                    case "doubletap":
                        return DoubleTap(deviceId, line);
                    case "longpress":
                        return LongPress(deviceId, line);
                    case "openapp":
                        return Openapp(deviceId, line);
                    case "closeapp":
                        return Closeapp(deviceId, line);
                    case "clearapp":
                        return ClearApp(deviceId, line);
                    case "waitrandom":
                        return WaitRandom(line);
                    case "send":
                    case "sendtext":
                    case "sendkey":
                        return Send(deviceId, line);
                    case "sleep":
                        return Sleep(deviceId, line);
                    case "ifimagefound":
                    case "imagefound":
                        return ImageFound(deviceId, line);
                    case "clickimage":
                        return ClickImage(deviceId, line.Split('|')[1].Contains(":") ? line.Split('|')[1] : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", line.Split('|')[1])) == "OK" ? "NEXT" : "FAIL_BRANCH";
                    case "imagenotfound":
                        return ImageNotFound(deviceId, line);
                    case "iftextfound":
                    case "textfound":
                        return TextFound(deviceId, line);
                    case "taptext":
                        return TapText(deviceId, line).Contains("Fail") ? "FAIL_BRANCH" : "NEXT";
                    case "zoom":
                        return Zoom(deviceId, line, true);
                    default:
                        Core.AdbClient.ExecuteCommandAsync($"-s {deviceId} shell {line}").GetAwaiter().GetResult();
                        return "NEXT";
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
