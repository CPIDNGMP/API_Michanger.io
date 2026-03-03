using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace MichangerAPIControl.ApiClients
{
    /// <summary>
    /// Base class for API clients. Handles requests, delays, and URL encoding.
    /// Lớp cơ sở cho các Client API. Xử lý gửi request, delay bắt buộc, và mã hoá URL.
    /// </summary>
    public abstract class BaseApiClient
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _baseUrl;
        
        // Ensure a minimum delay between requests / Đảm bảo khoảng thời gian trễ tối thiểu giữa các request (100ms)
        protected const int MINIMUM_DELAY_MS = 100;
        protected DateTime _lastRequestTime = DateTime.MinValue;

        public BaseApiClient(string baseUrl, int port = 9999)
        {
            _baseUrl = $"http://{baseUrl}:{port}";
            _httpClient = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };
        }

        /// <summary>
        /// Builds the full URL with query parameters encoded properly.
        /// Tạo URL đầy đủ kèm theo các tham số (đã được url-encode).
        /// </summary>
        protected string BuildUrl(string endpoint, Dictionary<string, string> queryParams)
        {
            var uriBuilder = new UriBuilder($"{_baseUrl}/{endpoint}");
            
            if (queryParams != null && queryParams.Count > 0)
            {
                var query = string.Join("&", queryParams
                    .Where(kvp => !string.IsNullOrEmpty(kvp.Value))
                    .Select(kvp => $"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}")); // Escape special chars / Mã hóa ký tự đặc biệt
                uriBuilder.Query = query;
            }

            return uriBuilder.ToString();
        }

        /// <summary>
        /// Sends an asynchronous GET request, enforcing the minimum delay rule.
        /// Gửi yêu cầu GET bất đồng bộ, tuân thủ luật chờ delay tối thiểu.
        /// </summary>
        protected async Task<string> SendGetRequestAsync(string url)
        {
            // Enforce minimum delay / Áp dụng delay tối thiểu 100ms
            var elapsed = DateTime.Now - _lastRequestTime;
            if (elapsed.TotalMilliseconds < MINIMUM_DELAY_MS)
            {
                await Task.Delay(MINIMUM_DELAY_MS - (int)elapsed.TotalMilliseconds);
            }

            try
            {
                var response = await _httpClient.GetAsync(url);
                _lastRequestTime = DateTime.Now;

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                // Rethrow format / Bắt và ném lại lỗi để UI xử lý hiển thị
                throw new Exception($"API Request failed to {url}: {ex.Message}", ex);
            }
        }
    }
}
