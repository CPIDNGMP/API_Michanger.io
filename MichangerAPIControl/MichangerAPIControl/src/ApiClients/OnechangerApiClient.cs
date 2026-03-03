using System.Collections.Generic;
using System.Threading.Tasks;

namespace MichangerAPIControl.ApiClients
{
    /// <summary>
    /// OneChanger API Implementation (Mặc định Port 9999).
    /// Triển khai 4 nhóm Endpoints API của OneChanger.
    /// </summary>
    public class OnechangerApiClient : BaseApiClient
    {
        public OnechangerApiClient(string baseUrl = "localhost", int port = 9999) 
            : base(baseUrl, port) { }

        // 1. API Random & Change Info
        public async Task<string> ChangeDeviceAsync(string serial, string filterBrand = null, string filterModel = null, 
            string filterOs = null, string filterCountry = null, string filterCarrier = null, 
            string customCarrier = null, string lat = null, string lon = null, string factoryReset = null)
        {
            // Similar to Michanger, URL structure is the same but for OneChanger backend
            // Tương tự cấu trúc Michanger nhưng dành cho máy chủ OneChanger
            var p = new Dictionary<string, string> { { "serial", serial } };
            if (filterBrand != null) p["filter_brand"] = filterBrand;
            if (filterModel != null) p["filter_model"] = filterModel;
            if (filterOs != null) p["filter_os"] = filterOs;
            if (filterCountry != null) p["filter_country"] = filterCountry;
            if (filterCarrier != null) p["filter_carrier"] = filterCarrier;
            if (customCarrier != null) p["custom_carrier"] = customCarrier;
            if (lat != null) p["lat"] = lat;
            if (lon != null) p["long"] = lon;
            if (factoryReset != null) p["factory_reset"] = factoryReset;

            return await SendGetRequestAsync(BuildUrl("change", p));
        }

        // 2. API Backup & Restore
        public async Task<string> BackupAsync(string serial, string note = null, string packages = null)
        {
            var p = new Dictionary<string, string> { { "serial", serial } };
            if (note != null) p["note"] = note;
            if (packages != null) p["packages"] = packages; // e.g. com.facebook.katana

            return await SendGetRequestAsync(BuildUrl("backup", p));
        }

        public async Task<string> RestoreAsync(string serial, string backupFile = null, string gmail = null)
        {
            var p = new Dictionary<string, string> { { "serial", serial } };
            if (backupFile != null) p["backup_file"] = backupFile;
            if (gmail != null) p["gmail"] = gmail;

            return await SendGetRequestAsync(BuildUrl("restore", p));
        }

        public async Task<string> GetRestoreListAsync()
        {
            return await SendGetRequestAsync(BuildUrl("getlist", new Dictionary<string, string>()));
        }

        // 3. API Network (SOCKS5/Proxy)
        public async Task<string> ConfigSockAsync(string serial, string sock, string changeLocation = "false", string changeTimezone = "false", string changeWebrtc = "false")
        {
            var p = new Dictionary<string, string> 
            { 
                { "serial", serial }, 
                { "sock", sock },
                { "change_location", changeLocation },
                { "change_timezone", changeTimezone },
                { "change_webrtc", changeWebrtc }
            };

            return await SendGetRequestAsync(BuildUrl("configSock", p));
        }

        public async Task<string> CurrentSockAsync(string serial)
        {
            return await SendGetRequestAsync(BuildUrl("currentSock", new Dictionary<string, string> { { "serial", serial } }));
        }

        public async Task<string> ChangeInfoByCurrentIpAsync(string serial)
        {
            return await SendGetRequestAsync(BuildUrl("changeInfoByCurrentIP", new Dictionary<string, string> { { "serial", serial } }));
        }

        // 4. Utility / Tiện ích
        public async Task<string> InstallApkAsync(string serial, string pathToApk)
        {
            var p = new Dictionary<string, string> { { "serial", serial }, { "path", pathToApk } };
            return await SendGetRequestAsync(BuildUrl("installApk", p));
        }

        // Test API Validation
        public async Task<string> TestApiAsync()
        {
            return await SendGetRequestAsync(BuildUrl("test", new Dictionary<string, string>()));
        }
    }
}
