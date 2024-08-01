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

        public WeatherController(IWeatherContext context)
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
