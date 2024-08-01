using Microsoft.EntityFrameworkCore;
using PublicWeatherAPIreceiveData.Core.Models;

namespace PublicWeatherAPIreceiveData.Core.Interfaces
{
    public interface IWeatherContext
    {
        DbSet<WeatherData> WeatherDatas { get; set; }
    }
}
