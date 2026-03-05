using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MichangerAPIControl.Automation
{
    public class AdbScriptRunner
    {
        public static async Task ExecuteScriptAsync(string deviceId, string scriptPath, Action<string> logAction)
        {
            if (!File.Exists(scriptPath))
            {
                logAction($"[Error] Script file not found: {scriptPath}");
                return;
            }

            string[] lines = File.ReadAllLines(scriptPath);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;

                string[] elements = line.Split('|');
                string command = elements[0];
                logAction($"[Execute] {line}");

                try
                {
                    string result = "";
                    switch (command)
                    {
                        case "Tap":
                            result = ADBCommand.Tap(deviceId, line);
                            break;
                        case "DoubleTap":
                            result = ADBCommand.DoubleTap(deviceId, line);
                            break;
                        case "LongPress":
                            result = ADBCommand.LongPress(deviceId, line);
                            break;
                        case "Swipe":
                            result = ADBCommand.Swipe(deviceId, line);
                            break;
                        case "Sleep":
                            result = ADBCommand.Sleep(deviceId, line);
                            break;
                        case "Send":
                            result = ADBCommand.Send(deviceId, line);
                            break;
                        case "OpenApp":
                            result = ADBCommand.Openapp(deviceId, line);
                            break;
                        case "CloseApp":
                            result = ADBCommand.Closeapp(deviceId, line);
                            break;
                        case "IfImageFound":
                            result = ADBCommand.ImageFound(deviceId, line);
                            // Nếu kết quả trả về là một lệnh RunScript, ta có thể gọi đệ quy (tùy nhu cầu)
                            break;
                        case "IfImageNotFound":
                            result = ADBCommand.ImageNotFound(deviceId, line);
                            break;
                        case "RunScript":
                            if (elements.Length > 1)
                            {
                                string nextScript = Path.Combine(Application.StartupPath, "Script", elements[1]);
                                await ExecuteScriptAsync(deviceId, nextScript, logAction);
                            }
                            break;
                    }
                    if (!string.IsNullOrEmpty(result)) logAction($"[Result] {result}");
                }
                catch (Exception ex)
                {
                    logAction($"[Error] Failed to execute {line}: {ex.Message}");
                }
            }
        }
    }
}
