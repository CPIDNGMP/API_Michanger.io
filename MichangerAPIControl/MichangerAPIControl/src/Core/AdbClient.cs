using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MichangerAPIControl.Core
{
    /// <summary>
    /// Wrapper for ADB (Android Debug Bridge) commands.
    /// Lớp bao bọc để tương tác với các lệnh ADB.
    /// </summary>
    public static class AdbClient
    {
        /// <summary>
        /// Gets a list of connected device serial numbers.
        /// Lấy danh sách các số serial của thiết bị đang kết nối.
        /// </summary>
        /// <returns>A list of serial strings / Danh sách chuỗi serial</returns>
        public static async Task<List<string>> GetDevicesAsync()
        {
            var output = await ExecuteCommandAsync("devices");
            var devices = new List<string>();

            // Parse output: "List of devices attached\nemulator-5554\tdevice"
            // Phân tích kết quả trả về từ ADB
            var lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2 && parts[1] == "device")
                {
                    devices.Add(parts[0]);
                }
            }

            return devices;
        }

        /// <summary>
        /// Opens a specific URL on the device's default browser using an ADB Intent.
        /// Mở một URL cụ thể trên trình duyệt mặc định của thiết bị bằng ADB Intent.
        /// </summary>
        /// <param name="serial">Device Serial / Số Serial (VD: emulator-5554)</param>
        /// <param name="url">The URL to open / Đường dẫn cần mở</param>
        public static async Task OpenBrowserUrlAsync(string serial, string url)
        {
            // adb -s <serial> shell am start -a android.intent.action.VIEW -d "<url>"
            var safeUrl = url.Replace("&", "\\&"); // Escape characters for shell / Khử ký tự đặc biệt cho shell
            await ExecuteCommandAsync($"-s {serial} shell am start -a android.intent.action.VIEW -d \"{safeUrl}\"");
        }

        /// <summary>
        /// Clears data for a specific application package.
        /// Xóa toàn bộ dữ liệu của một ứng dụng cụ thể.
        /// </summary>
        public static async Task ClearAppAsync(string serial, string packageName)
        {
            if (string.IsNullOrWhiteSpace(packageName)) return;
            await ExecuteCommandAsync($"-s {serial} shell pm clear {packageName}");
        }

        /// <summary>
        /// Opens a specific application by its package name using the monkey command.
        /// Mở một ứng dụng bằng package name thông qua lệnh monkey.
        /// </summary>
        public static async Task OpenAppAsync(string serial, string packageName)
        {
            if (string.IsNullOrWhiteSpace(packageName)) return;
            await ExecuteCommandAsync($"-s {serial} shell monkey -p {packageName} -c android.intent.category.LAUNCHER 1");
        }

        /// <summary>
        /// Attempts to remove all Google accounts by clearing Google Play Services data.
        /// Thử gỡ toàn bộ tài khoản Google bằng cách xóa data của Google Play Services.
        /// </summary>
        public static async Task RemoveGoogleAccountsAsync(string serial)
        {
            // This is the fastest standard ADB method to detach assigned accounts without Root
            await ExecuteCommandAsync($"-s {serial} shell pm clear com.google.android.gms");
            await ExecuteCommandAsync($"-s {serial} shell pm clear com.google.android.gsf");
        }

        /// <summary>
        /// Executes an arbitrary ADB command and returns the standard output.
        /// Thực thi một lệnh ADB bất kỳ và trả về kết quả (stdout).
        /// </summary>
        /// <param name="arguments">The arguments passed to adb.exe / Tham số truyền cho adb.exe</param>
        /// <returns>Command output as string / Kết quả dạng chuỗi</returns>
        public static Task<string> ExecuteCommandAsync(string arguments)
        {
            var tcs = new TaskCompletionSource<string>();

            // Khởi tạo process ẩn / Initialize a hidden process
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "adb",
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                },
                EnableRaisingEvents = true
            };

            process.Exited += (sender, args) =>
            {
                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();
                
                if (process.ExitCode != 0 && string.IsNullOrWhiteSpace(output))
                {
                    tcs.SetException(new Exception($"ADB Error ({process.ExitCode}): {error}"));
                }
                else
                {
                    tcs.SetResult(output);
                }
                process.Dispose();
            };

            process.Start();

            return tcs.Task;
        }
    }
}
