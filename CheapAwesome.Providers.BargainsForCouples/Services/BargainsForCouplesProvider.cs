using CheapAwesome.Providers.BargainsForCouples.Models;
using CheapAwesome.Providers.BargainsForCouples.Services.Interfaces;
using CheapAwesome.Providers.Base.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheapAwesome.Providers.BargainsForCouples.Services
{
    public class BargainsForCouplesProvider : IBargainsForCouplesProvider
    {
        private const string FindBargainEndpoint = "/findBargain";
        private const string ApiUrl = "ProviderUrl:BargainsForCouples";
        private const string ApiKey = "ApiKey:BargainsForCouples";
        private string _apiCode;
        private BaseHttpClient _httpClient;

        public BargainsForCouplesProvider(IConfiguration configuration)
        {
            var baseUrl = configuration[ApiUrl];
            _apiCode = configuration[ApiKey]; // don't forget to register the User Secret
            _httpClient = new BaseHttpClient(baseUrl);
        }

        public async Task<List<HotelInfo>> Find(int destinationId, int nights)
        {
            var queryParameters = new[] { ("destinationId", destinationId.ToString()), ("nights", nights.ToString()), ("code", _apiCode) };
            string content = await _httpClient.GetAsync(FindBargainEndpoint, queryParameters);
            var model = JsonSerializer.Deserialize<List<HotelInfo>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return model;
        }
    }
}
