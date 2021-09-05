using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace MWALesson_1.Services
{
    public class WeatherForecastService
    {
        private readonly ILogger<WeatherForecastService> _logger;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly List<WeatherForecast> _weatherForecasts = new List<WeatherForecast>();

        public List<WeatherForecast> WeatherForecasts => _weatherForecasts;

        public WeatherForecastService(ILogger<WeatherForecastService> logger)
        {
            _logger = logger;
            _logger.LogDebug($"Create instance {nameof(WeatherForecastService)}");

            var rnd = new Random();
            _weatherForecasts.AddRange(
                Enumerable.Range(1, 10).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rnd.Next(-20, 50),
                    Summary = Summaries[rnd.Next(Summaries.Length)]
                })
            );
        }

        public void AddWeather(WeatherForecast weatherForecast)
        {
            _weatherForecasts.Add(weatherForecast);
        }

        public WeatherForecast? UpdateWeatherByDate(DateTime date, WeatherForecast weatherForecast)
        {
            var result = _weatherForecasts.Find(item => item.Date.ToString() == date.ToString());

            if (result == null)
            {
                return null;
            }

            result.Date = weatherForecast.Date;
            result.TemperatureC = weatherForecast.TemperatureC;
            result.Summary = weatherForecast.Summary;

            return result;
        }

        public bool Delete(DateTime date)
        {
            var index = _weatherForecasts.FindIndex(item => item.Date.ToString() == date.ToString());

            if (index == -1)
            {
                return false;
            }

            _weatherForecasts.RemoveAt(index);

            return true;
        }

        public IEnumerable<WeatherForecast> FindBetween(DateTime startDate, DateTime endDate)
        {
            return _weatherForecasts.Where(item =>
                item.Date.CompareTo(startDate) > 0 && item.Date.CompareTo(endDate) < 0);
        }
    }
}