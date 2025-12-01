using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TTEK_MAUI.Models;

namespace TTEK_MAUI.Services
{
    internal class MarketDataService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        private const string BaseUrl = "https://10.0.2.2.2:7206/api/MarketData/Summary";

        public async Task<MarketSummaryModel?> GetMarketSummaryAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<MarketSummaryModel>(content);
                    return data;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"API call Failed: {ex.Message}");
            }

            return new MarketSummaryModel();
        }
    }
}
