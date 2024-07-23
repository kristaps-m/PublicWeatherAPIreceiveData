using Newtonsoft.Json;
using PublicWeatherAPIreceiveData.Models;

namespace PublicWeatherAPIreceiveData.Services
{
    public class WeatherApiService
    {
        private readonly HttpClient _httpClient;

        public WeatherApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherData> GetWeatherDataAsync(string query)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://weatherapi-com.p.rapidapi.com/current.json?q={query}"),
                Headers =
            {
                { "x-rapidapi-host", "weatherapi-com.p.rapidapi.com" },
                { "x-rapidapi-key", "my_api_key" },
            },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                dynamic json = JsonConvert.DeserializeObject(body);
                return new WeatherData
                {
                    Country = json.location.country,
                    City = json.location.name,
                    Temperature = json.current.temp_c,
                    LastUpdateTime = DateTime.Now
                };
            }
        }
    }
}
