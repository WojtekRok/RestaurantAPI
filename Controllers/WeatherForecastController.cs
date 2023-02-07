using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IWeatherForecastService weatherForecastService, ILogger<WeatherForecastController> logger)
        {
            _weatherForecastService = weatherForecastService;
            _logger = logger;   
        }

        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery] int count, [FromBody] TemperatureRequest request)
        {
            if (count < 0 || request.Max < request.Min)
                return BadRequest();

            var result = _weatherForecastService.GetForecasts(count, request.Min, request.Max);
            return Ok(result);

        }
    }
}