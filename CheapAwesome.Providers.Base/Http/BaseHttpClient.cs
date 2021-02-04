using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CheapAwesome.Providers.Base.Http
{
    public class BaseHttpClient
    {
        private readonly string _baseUrl;
        private HttpClient _httpClient;

        public BaseHttpClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }

        public async Task<string> GetAsync(string endpoint, params (string Key, string Value)[] queryParameters)
        {
            string requestUri = $"{_baseUrl}{endpoint}";

            if (queryParameters.Length > 0)
            {
                var queryStrings = queryParameters.Select(x => $"{x.Key}={x.Value}");
                var queryString = string.Join('&', queryStrings);
                requestUri = $"{requestUri}?{queryString}";
            }

            var response = await _httpClient.GetAsync(requestUri);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
