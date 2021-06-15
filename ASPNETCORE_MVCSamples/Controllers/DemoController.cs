using ASPNETCORE_MVCSamples.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVCSamples.Controllers
{
    [Route("demo")]
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("demo1")]
        public ContentResult Demo1()
        {
            return Content("Hello", "text/plain");
        }

        [Route("demo2/{fullName}")]
        public ContentResult Demo2(string fullName)
        {
            return Content("Hello " + fullName, "text/plain");
        }

        //[Authorize("Support")]
        [Route("demo3")]
        public IActionResult Demo3()
        {
            var product = new Product()
            {
                Id = "p01",
                Name = "name 1",
                Price = 123
            };
            return new JsonResult(product);
        }

        [Route("demo4")]
        public IActionResult Demo4(int continentId)
        {
            //1. Calle WebAPI - Methode mit Id als Parameter
            //2. Erhalte die List<Country> 
            //3. ergebnis wird als Json übermittelt

            var products = new List<Product>()
            {
                new Product() {
                    Id = "p01",
                    Name = "name 1",
                    Price = 123
                },
                new Product() {
                    Id = "p02",
                    Name = "name 2",
                    Price = 456
                },
                new Product() {
                    Id = "p03",
                    Name = "name 3",
                    Price = 789m
                }
            };
            return new JsonResult(products);
        }
    }
}
