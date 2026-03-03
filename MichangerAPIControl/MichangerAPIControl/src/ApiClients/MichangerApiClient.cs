using System.Collections.Generic;
using System.Threading.Tasks;

namespace MichangerAPIControl.ApiClients
{
    /// <summary>
    /// Michanger Pro API Implementation (Mặc định Port 9999).
    /// Triển khai 9 nhóm Endpoints API của Michanger Pro.
    /// </summary>
    public class MichangerApiClient : BaseApiClient
    {
        public MichangerApiClient(string baseUrl = "localhost", int port = 9999) 
            : base(baseUrl, port) { }

        // 1. Random & change info
        public async Task<string> ChangeDeviceAsync(string serial, string filterBrand = null, string filterModel = null, 
            string filterOs = null, string filterCountry = null, string filterCarrier = null, 
            string customCarrier = null, string lat = null, string lon = null, string factoryReset = null)
        {
            var p = new Dictionary<string, string> { { "serial", serial } };
            if (filterBrand != null) p["filter_brand"] = filterBrand;
            if (filterModel != null) p["filter_model"] = filterModel; // Pixel 3a XL => Pixel%203a%20XL (BaseApiClient auto encodes)
            if (filterOs != null) p["filter_os"] = filterOs;
            if (filterCountry != null) p["filter_country"] = filterCountry;
            if (filterCarrier != null) p["filter_carrier"] = filterCarrier;
            if (customCarrier != null) p["custom_carrier"] = customCarrier; // Format: T-Mobile|310160
            if (lat != null) p["lat"] = lat;
            if (lon != null) p["long"] = lon;
            if (factoryReset != null) p["factory_reset"] = factoryReset; // True/False

            string url = BuildUrl("change", p);
            return await SendGetRequestAsync(url);
        }

        // 2. Random & change sim info only
        public async Task<string> ChangeSimOnlyAsync(string serial, string filterCountry = null, 
            string filterCarrier = null, string customCarrier = null, string wipe = null)
        {
            var p = new Dictionary<string, string> { { "serial", serial } };
            if (filterCountry != null) p["filter_country"] = filterCountry;
            if (filterCarrier != null) p["filter_carrier"] = filterCarrier;
            if (customCarrier != null) p["custom_carrier"] = customCarrier;
            if (wipe != null) p["wipe"] = wipe; // True/False

            return await SendGetRequestAsync(BuildUrl("changesimonly", p));
        }

        // 3. Change location only
        public async Task<string> ChangeLocationOnlyAsync(string serial, string lat, string lon, string wipe = null)
        {
            var p = new Dictionary<string, string> { { "serial", serial }, { "lat", lat }, { "long", lon } };
            if (wipe != null) p["wipe"] = wipe;

            return await SendGetRequestAsync(BuildUrl("changelocationonly", p));
        }

        // 4. Backup data only
        public async Task<string> BackupOnlyAsync(string serial, string note = null, string filename = null, string full = null)
        {
            var p = new Dictionary<string, string> { { "serial", serial } };
            if (note != null) p["note"] = note;
            if (filename != null) p["filename"] = filename;
            if (full != null) p["full"] = full; // true/false

            return await SendGetRequestAsync(BuildUrl("backuponly", p));
        }

        // 5. Backup & change info
        public async Task<string> BackupAndChangeAsync(string serial, string note = null, string filename = null, 
            string full = null, string factoryReset = null) // + filters similar to ChangeDevice
        {
            var p = new Dictionary<string, string> { { "serial", serial } };
            if (note != null) p["note"] = note;
            if (filename != null) p["filename"] = filename;
            if (full != null) p["full"] = full;
            if (factoryReset != null) p["factory_reset"] = factoryReset;

            return await SendGetRequestAsync(BuildUrl("backup", p));
        }

        // 6. Restore (GetList & Restore)
        public async Task<string> GetRestoreListAsync(string type = "all")
        {
            var p = new Dictionary<string, string> { { "type", type } };
            return await SendGetRequestAsync(BuildUrl("getlist", p));
        }

        public async Task<string> RestoreAsync(string serial, string filename = null, string gmail = null, string lat = null, string lon = null)
        {
            var p = new Dictionary<string, string> { { "serial", serial } };
            if (filename != null) p["filename"] = filename;
            if (gmail != null) p["gmail"] = gmail;
            if (lat != null) p["lat"] = lat;
            if (lon != null) p["long"] = lon;

            return await SendGetRequestAsync(BuildUrl("restore", p));
        }

        // 7. Proxy config
        public async Task<string> ClearProxyAsync(string serial) => await SendGetRequestAsync(BuildUrl("clearproxy", new Dictionary<string, string> { { "serial", serial } }));
        public async Task<string> SetProxyAsync(string serial, string proxyHostPort) => await SendGetRequestAsync(BuildUrl("setproxy", new Dictionary<string, string> { { "serial", serial }, { "proxy", proxyHostPort } }));

        // 8. SOCKS5 config
        public async Task<string> ClearSocksAsync(string serial) => await SendGetRequestAsync(BuildUrl("clearsocks", new Dictionary<string, string> { { "serial", serial } }));
        public async Task<string> SetSocksAsync(string serial, string socksConfig) => await SendGetRequestAsync(BuildUrl("setsocks", new Dictionary<string, string> { { "serial", serial }, { "socks", socksConfig } }));

        // 9. Get Carrier
        public async Task<string> GetCarrierAsync(string countryCode = "all")
        {
            var p = new Dictionary<string, string> { { "country", countryCode } };
            return await SendGetRequestAsync(BuildUrl("getcarrier", p));
        }
        
        // Test API Validation / Nhóm API kiểm tra kết nối
        public async Task<string> TestApiAsync()
        {
            return await SendGetRequestAsync(BuildUrl("test", new Dictionary<string, string>()));
        }
    }
}
