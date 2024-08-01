using Microsoft.EntityFrameworkCore;
using PublicWeatherAPIreceiveData.Core.Models;

namespace PublicWeatherAPIreceiveData.DataBase.DataBase
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
