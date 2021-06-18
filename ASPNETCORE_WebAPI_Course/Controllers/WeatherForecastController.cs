using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI_Course.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //Normaler Fall: https://localhost:12345/api/Employee 
    //WeatherForecast: https://localhost:12345/WeatherForecast 
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

        [HttpGet] //Http-Verb
        [ResponseCache (Duration =30, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new [] {"impactlevel", "pii"})]
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


        [HttpPost] //HTTP-Verbs kann man auch kombinieren (POST/PATCH)
        [HttpPatch]
        public IActionResult InsertOrUpdate(WeatherForecast obj)
        {
            //prüfung ob obj.ID belegt ist = Update
            //ID ist leer = Insert
            return Ok();
        }
    }
}
