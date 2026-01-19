using Microsoft.AspNetCore.Mvc;
using OpenMeteo;

namespace Azure_Weather_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{locationString}")]
        public async Task<IActionResult> Get([FromRoute] string locationString)
        {
            _logger.LogInformation($"Info on {locationString} requested by ip: {HttpContext?.Connection?.RemoteIpAddress}");

            OpenMeteoClient client = new ();

            WeatherForecast weatherData = await client.QueryAsync(locationString);

            return Ok(weatherData);
        }
    }
}
