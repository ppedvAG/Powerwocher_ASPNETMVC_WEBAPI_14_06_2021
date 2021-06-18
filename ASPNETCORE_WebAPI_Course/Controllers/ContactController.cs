using ASPNETCORE_WebAPI_SharedLib.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI_Course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public Contact GetContact ()
        {
            Contact contact = new Contact();
            contact.Id = 1;
            contact.Firstname = "Otto";
            contact.Lastname = "Walkes";

            return contact;
        }

        [HttpPost]
        public IActionResult Insert(Contact contact)
        {
            return Ok();
        }
    }
}
