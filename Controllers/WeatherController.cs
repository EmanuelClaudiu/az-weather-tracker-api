using Microsoft.AspNetCore.Mvc;
using OpenMeteo;

namespace Azure_Weather_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        public WeatherController(ILogger<WeatherController> logger) { }

        [HttpGet("{locationString}")]
        public async Task<IActionResult> Get([FromRoute] string locationString)
        {
            OpenMeteoClient client = new ();

            WeatherForecast weatherData = await client.QueryAsync(locationString);

            return Ok(weatherData);
        }
    }
}
