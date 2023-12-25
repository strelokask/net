using Data;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly FootballLeageDbContext _footballLeageDbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, FootballLeageDbContext footballLeageDbContext)
        {
            _logger = logger;
            _footballLeageDbContext = footballLeageDbContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<object> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Teams = _footballLeageDbContext.Teams.ToList()
            })
            .ToArray();
        }
    }
}