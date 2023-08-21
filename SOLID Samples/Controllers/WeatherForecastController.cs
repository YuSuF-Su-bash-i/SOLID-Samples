using Microsoft.AspNetCore.Mvc;
using SOLID_Samples.Interfaces;
using SOLID_Samples.Models;

namespace SOLID_Samples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherRepository _weatherRepository;

        public WeatherForecastController(IWeatherRepository weatherRepository, ILogger<WeatherForecastController> logger)
        {
            _weatherRepository = weatherRepository;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var weatherData = await _weatherRepository.GetAllAsync();
                return Ok(weatherData);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Weather weather)
        {
            try
            {
                Console.WriteLine($"Received Weather Data: Date - {weather.Date}, TemperatureCelsius - {weather.TempCelcius}, Summary - {weather.WeatherSummary}, TemperatureFahrenheit - {weather.TempFahrenheit}");

                await _weatherRepository.AddAsync(weather);

                return Ok("Weather data received.");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}