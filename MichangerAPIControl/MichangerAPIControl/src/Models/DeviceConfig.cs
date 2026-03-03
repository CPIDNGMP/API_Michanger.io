using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace MichangerAPIControl.Models
{
    /// <summary>
    /// Configuration for a single ADB device, including its specific SOCKS5 proxy settings.
    /// Cấu hình cho một thiết bị ADB cụ thể, bao gồm thông số SOCKS5 riêng biệt.
    /// </summary>
    public class DeviceConfig
    {
        public string SerialNumber { get; set; } = string.Empty;
        public string SocksHost { get; set; } = string.Empty;
        public string SocksPort { get; set; } = string.Empty;
        public string SocksUser { get; set; } = string.Empty;
        public string SocksPass { get; set; } = string.Empty;

        // Individual API Filters
        public string FilterBrand { get; set; } = "google";
        public string FilterModel { get; set; } = "Pixel 10 Pro";
        public string FilterOs { get; set; } = string.Empty;
        public string FilterCountry { get; set; } = "US";
        public string FilterCarrier { get; set; } = string.Empty;
        public string CustomCarrier { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string FactoryReset { get; set; } = string.Empty;
        public string Wipe { get; set; } = string.Empty;
        public string AppWipe { get; set; } = "package: com.google.android.apps.subscriptions.red";

        /// <summary>
        /// Gets the properly formatted SOCKS5 string for API use.
        /// Lấy chuỗi SOCKS5 đã được định dạng chuẩn để gửi qua API.
        /// </summary>
        public string GetSocksString()
        {
            if (!string.IsNullOrEmpty(FullSocks))
                return FullSocks;

            if (string.IsNullOrEmpty(SocksHost) || string.IsNullOrEmpty(SocksPort))
                return string.Empty;
            
            if (!string.IsNullOrEmpty(SocksUser) && !string.IsNullOrEmpty(SocksPass))
                return $"{SocksHost}:{SocksPort}:{SocksUser}:{SocksPass}";
            
            return $"{SocksHost}:{SocksPort}";
        }
        
        // Single string for easier UI binding
        public string FullSocks { get; set; } = string.Empty;
    }

    /// <summary>
    /// Manages loading and saving the configuration file for all devices.
    /// Quản lý việc tải và lưu file cấu hình của tất cả thiết bị.
    /// </summary>
    public static class DeviceConfigManager
    {
        private static readonly string ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings", "devices.json");
        private static Dictionary<string, DeviceConfig> _configs = new Dictionary<string, DeviceConfig>();

        /// <summary>
        /// Loads settings from disk.
        /// Tải cấu hình từ ổ cứng.
        /// </summary>
        public static void Load()
        {
            if (!File.Exists(ConfigPath)) return;
            
            try
            {
                string json = File.ReadAllText(ConfigPath);
                var list = new JavaScriptSerializer().Deserialize<List<DeviceConfig>>(json);
                if (list != null)
                {
                    _configs.Clear();
                    foreach (var cfg in list)
                    {
                        _configs[cfg.SerialNumber] = cfg;
                    }
                }
            }
            catch (Exception ex)
            {
                // In a real app, log this error specifically / Trong thực tế nên log lỗi này lại
                Console.WriteLine($"Error loading config: {ex.Message}");
            }
        }

        /// <summary>
        /// Saves all settings to disk.
        /// Lưu tất cả cấu hình xuống ổ cứng.
        /// </summary>
        public static void Save()
        {
            try
            {
                var dir = Path.GetDirectoryName(ConfigPath);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                var list = new List<DeviceConfig>(_configs.Values);
                string json = new JavaScriptSerializer().Serialize(list);
                File.WriteAllText(ConfigPath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving config: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets or creates a configuration object for the given serial.
        /// Lấy hoặc tạo mới cấu hình cho một số serial cụ thể.
        /// </summary>
        public static DeviceConfig GetConfig(string serial)
        {
            if (!_configs.ContainsKey(serial))
            {
                _configs[serial] = new DeviceConfig { SerialNumber = serial };
            }
            return _configs[serial];
        }
    }
}
