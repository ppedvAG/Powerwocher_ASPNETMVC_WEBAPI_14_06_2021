using ASPNETCORE_MVCSamples.Models;
using DependencyInjectionSampleLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVCSamples.Controllers
{

    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly ICar _car;


        public HomeController(ILogger<HomeController> logger, IConfiguration config, ICar car)//Schaue in IOC Container nach ICAr und verwende dessen Implementierung (MockCar)
        {
            _logger = logger;
            _config = config;

            _car = car;
        }

        //[HttpGet]
        public IActionResult Index() 
        {
            _logger.LogInformation("Willkommen auf Startseite");
            return View(); //->liefert er den HTML Code der Index-View
        }


        //Hat benutzer die Role Admin
        //[Authorize("Admin")]
        //[Authorize("Support")]
        public IActionResult Privacy()
        {
            _logger.LogInformation("Willkommen auf Startseite");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
