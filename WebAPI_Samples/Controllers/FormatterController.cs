using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Samples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatterController : ControllerBase
    {
        // GET api/authors/about
        [HttpGet("About")]
        public ContentResult About()
        {
            return Content("An API listing authors of docs.asp.net.");
        }

        // GET api/authors/version
        [HttpGet("version")]
        public string Version()
        {
            return "Version 1.0.0";
        }



        //IActionResult kann 2 Informationen übergeben 
        // 1) HttpStatus Code
        // 2) Eine Datenmenge

        // GET api/authors/version
        [HttpGet("version")]
        public IActionResult VersionBetter()
        {
            return Ok("Version 1.0.0");
        }

        // GET: api/authors/search?namelike=th
        [HttpGet("Search")]
        public IActionResult Search(string namelike)
        {
            
            //IActionResult sollte verwendet werden, wenn man mehere returns in einer Methode verwendet. Man bei fehler, dem Client einen Fehlcode definiert zusenden. 
            //(Siehe auskommentiertes Beipspiel)

            //var result = _authors.GetByNameSubstring(namelike);
            //if (!result.Any())
            //{
            //    return NotFound(namelike);
            //}
            //return Ok(result);


            return Ok();
        }


    }
}
