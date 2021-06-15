using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVCSamples.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult ViewDataSample()
        {
            ViewData["abc"] = "Hallo liebe Teilnehmer!";
            ViewData["def"] = "Auch das wir mit übergeben";
            return View();
        }

        public IActionResult ViewBagSample()
        {
            ViewBag.Haribo = "Die mit den Goldbären";
            //ViewData["Haribo"]  = "Die mit den Goldbären";
            ViewBag.Volvic = "2,5 Liter trinken";

            return View();
        }

        public IActionResult FirstTempDataSample()
        {
            TempData["EmailAddress"] = "KevinW@ppedv.de";
            TempData["Id"] = 123;


            return View();
        }

        public IActionResult SecondTempDataSample()
        {
            return View();
        }
        public IActionResult ThirdTempDataSample()
        {
            return View();
        }
    }
}
