using Microsoft.EntityFrameworkCore;
using PublicWeatherAPIreceiveData.Models;

namespace PublicWeatherAPIreceiveData.DataBase
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options)
        : base(options)
        {
        }

        public DbSet<WeatherData> WeatherDatas { get; set; }
    }
}
