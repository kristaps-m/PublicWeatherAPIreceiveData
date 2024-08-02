using PublicWeatherAPIreceiveData.Core.Models;

namespace PublicWeatherAPIreceiveData.Core.Interfaces
{
    public interface IWeatherApiService
    {
        Task<WeatherData> GetWeatherDataAsync(string cityCoordinatesQuery, DateTime timeForCitiesInLoop);
        List<MinMax> GetMinMaxTemperaturesAsync(List<WeatherData> weatherDataList);
    }
}
