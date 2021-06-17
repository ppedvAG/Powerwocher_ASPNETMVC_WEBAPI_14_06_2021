using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SharedLibrary.Entities;

namespace WebAPI_Samples.Controllers
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
        public IEnumerable<Movie> Get()
        {

            List<Movie> movieList = new List<Movie>();

            movieList.Add(new Movie { Id = 1, Title = "Jurassic Park", Description = "Streichel nicht den T-Rex", Price = 12.99m });
            movieList.Add(new Movie { Id = 2, Title = "Jurassic Park 2", Description = "Streichel nicht den T-Rex",  Price = 12.99m });
            movieList.Add(new Movie { Id = 3, Title = "Jurassic Park 3", Description = "Streichel nicht den T-Rex",  Price = 12.99m });


            return movieList;
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToList();
        }
    }
}
