using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace wasm.Data
{
    public class WeatherForecastService
    {
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private readonly HttpClient _client;

        public WeatherForecastService(HttpClient client)
        {
            _client = client;
        }

        public async Task<WeatherForecast[]> GetWeatherAsync()
        {
            HttpResponseMessage responseMessage = await _client.GetAsync("/weatherforecast");
            Stream stream = await responseMessage.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<WeatherForecast[]>(stream, _options);
        }
    }
}
