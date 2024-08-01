using Microsoft.EntityFrameworkCore;
using PublicWeatherAPIreceiveData.Core.Interfaces;
using PublicWeatherAPIreceiveData.Core.Models;

namespace PublicWeatherAPIreceiveData.DataBase.DataBase
{
    public class WeatherContext : DbContext, IWeatherContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options)
        : base(options)
        {
        }

        public DbSet<WeatherData> WeatherDatas { get; set; }
    }
}
