using System;
using System.ComponentModel.DataAnnotations;

namespace MWALesson_1
{
    public class WeatherForecast
    {
        [Required]
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}