using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MWALesson_1.Services;

namespace MWALesson_1.Controllers
{
    [ApiController]
    [Route("weather-forecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastService _weatherForecastService;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            WeatherForecastService weatherForecastService
        )
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
            _logger.LogDebug($"Create instance {nameof(WeatherForecastController)}");
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForecastService.WeatherForecasts;
        }

        /// <summary>
        ///     Добавлять информацию о погоде
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] WeatherForecast weatherForecast)
        {
            _weatherForecastService.AddWeather(weatherForecast);
            return Ok(weatherForecast);
        }

        /// <summary>
        ///     Обновлять информацию о погоде
        /// </summary>
        [HttpPut("{date}")]
        public IActionResult Update([FromRoute] DateTime date, [FromBody] WeatherForecast weatherForecast)
        {
            var result = _weatherForecastService.UpdateWeatherByDate(date, weatherForecast);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        ///     Удалить информацию о погоде
        /// </summary>
        [HttpDelete("{date}")]
        public IActionResult Delete([FromRoute] DateTime date)
        {
            if (_weatherForecastService.Delete(date) == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        ///     Получить инфморацию о погоде за конкретный промежуток времени
        /// </summary>
        [HttpGet("/from/{startDate}/to/{endDate}")]
        public IActionResult GetBetween([FromRoute] DateTime startDate,
            [FromRoute] DateTime endDate)
        {
            return Ok(_weatherForecastService.FindBetween(startDate, endDate));
        }
    }
}