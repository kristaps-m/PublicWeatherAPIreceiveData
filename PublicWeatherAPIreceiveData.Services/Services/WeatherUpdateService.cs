using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PublicWeatherAPIreceiveData.Core.Interfaces;
using PublicWeatherAPIreceiveData.DataBase.DataBase;

namespace PublicWeatherAPIreceiveData.Services.Services
{
    public class WeatherUpdateService : BackgroundService
    {
        private readonly IWeatherApiService _weatherApiService;
        private readonly IServiceScopeFactory _scopeFactory;

        public WeatherUpdateService(IWeatherApiService weatherApiService, IServiceScopeFactory scopeFactory)
        {
            _weatherApiService = weatherApiService;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var cities = new List<string> { "53.1,-0.13", "48.8566,2.3522", "40.7128,-74.0060" };
                foreach (var city in cities)
                {
                    var data = await _weatherApiService.GetWeatherDataAsync(city);

                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var context = scope.ServiceProvider.GetRequiredService<WeatherContext>();
                        context.WeatherDatas.Add(data);
                        await context.SaveChangesAsync();
                    }
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
