using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublicWeatherAPIreceiveData.Core.Interfaces;
using PublicWeatherAPIreceiveData.Core.Models;

namespace PublicWeatherAPIreceiveData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherContext _context;
        private readonly IWeatherApiService _weatherApiService;

        public WeatherController(IWeatherContext context, IWeatherApiService weatherApiService)
        {
            _context = context;
            _weatherApiService = weatherApiService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherData>> Get()
        {
            return await _context.WeatherDatas.ToListAsync();
        }

        [HttpGet("min-max-temperatures")]
        public async Task<IActionResult> GetMinMaxTemperatures()
        {
            var weatherDataList = await _context.WeatherDatas.ToListAsync();
            var result = _weatherApiService.GetMinMaxTemperaturesAsync(weatherDataList);

            return Ok(result); 
        }
    }
}
