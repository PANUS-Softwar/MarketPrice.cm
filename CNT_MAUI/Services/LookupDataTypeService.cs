using System.Net.Http.Json;
using CNT_MAUI.Models.POCOs;

namespace CNT_MAUI.Services
{
    public class LookupDataTypeService(HttpClient httpClient) : ILookupDataTypeService
    {
        public async Task<IEnumerable<LookupDataType>> GetLookupDataTypeAsync()
        {
            var response = await httpClient.GetAsync("LookupDataTypes");
            response.EnsureSuccessStatusCode();

            var lookupDataTypes = await response.Content.ReadFromJsonAsync<IEnumerable<LookupDataType>>();
            return lookupDataTypes ?? Enumerable.Empty<LookupDataType>();
        }

        public async Task<LookupDataType?> GetLookupDataTypeByIdAsync(int id)
        {
            var response = await httpClient.GetAsync($"LookupDataTypes/{id}");
            response.EnsureSuccessStatusCode();

            var lookupDataType = await response.Content.ReadFromJsonAsync<LookupDataType>();

            if (lookupDataType is null)
                return null;

            return lookupDataType;
        }
    }
}
