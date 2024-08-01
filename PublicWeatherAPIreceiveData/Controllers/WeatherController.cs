using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublicWeatherAPIreceiveData.DataBase.DataBase;
using PublicWeatherAPIreceiveData.Core.Models;

namespace PublicWeatherAPIreceiveData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherContext _context;

        public WeatherController(WeatherContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherData>> Get()
        {
            return await _context.WeatherDatas.ToListAsync();
        }
    }
}
