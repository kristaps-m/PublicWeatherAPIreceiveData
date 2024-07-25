using PublicWeatherAPIreceiveData.DataBase;

namespace PublicWeatherAPIreceiveData.Services
{
    public class WeatherUpdateService : BackgroundService
    {
        private readonly WeatherApiService _weatherApiService;
        //private readonly WeatherContext _context;
        private readonly IServiceScopeFactory _scopeFactory;

        public WeatherUpdateService(WeatherApiService weatherApiService, IServiceScopeFactory scopeFactory)
        {
            _weatherApiService = weatherApiService;
            //_context = context;
            _scopeFactory = scopeFactory;
        }

        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        var cities = new List<string> { "53.1,-0.13", "48.8566,2.3522" }; // Example coordinates
        //        foreach (var city in cities)
        //        {
        //            var data = await _weatherApiService.GetWeatherDataAsync(city);
        //            _context.WeatherDatas.Add(data);
        //            await _context.SaveChangesAsync();
        //        }

        //        await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        //    }
        //}
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var cities = new List<string> { "53.1,-0.13", "48.8566,2.3522", "40.7128,-74.0060" }; // Example coordinates
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
