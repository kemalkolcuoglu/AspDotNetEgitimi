using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIGiris.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public WeatherForecast Get(int? id)
        {
            var rng = new Random();
            WeatherForecast wf = new WeatherForecast()
            {
                Date = DateTime.Now,
                Summary = Summaries[rng.Next(Summaries.Length)],
                TemperatureC = 14
            };
            return wf;
        }

        [HttpPut("{id}")]
        public OkResult Update(int? id)
        {
            WeatherForecast wf = new WeatherForecast()
            {
                Date = DateTime.Now,
                Summary = Summaries[0],
                TemperatureC = 14
            };
            return Ok();
        }
    }
}
