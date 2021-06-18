using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI_Course.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReceptionController : ControllerBase
    {

        //https://localhost:44305/Reception/ -> (GET-Methode - GetPatientList) 

        [HttpGet("/Reception/GetPatientList/{MandantId}/{HospitalId}")]
        public IActionResult GetPatientList(int MandantId, int HospitalId)
        {
            IList<string> stringList = new List<string>();
            
            if (MandantId == 4)
            {

            }


            if (HospitalId == 123)
            {
                stringList.Add("1");
                stringList.Add("2");
            }
            
            stringList.Add("eins");
            stringList.Add("zwei");
            stringList.Add("drei");

            return Ok(stringList);
        }

        [HttpGet("/Reception/GetDoctorList")]
        public IActionResult GetDoctorList(int MandantId, int HospitalId) ///Reception/GetDoctorList?MandantId=4&HospitalId=123
        {
            IList<string> stringList = new List<string>();
            stringList.Add("eins");
            stringList.Add("zwei");
            stringList.Add("drei");

            return Ok(stringList);
        }

        [Route("[action]/{country}")]
        [HttpGet]
        public IActionResult GetByCountry(string country)
        {
            IList<string> stringList = new List<string>();
            stringList.Add("eins");
            stringList.Add("zwei");
            stringList.Add("drei");

            return Ok(stringList);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetByStates(string state)
        {
            if (string.IsNullOrEmpty(state))
                return NotFound();


            IList<string> stringList = new List<string>();
            stringList.Add("eins");
            stringList.Add("zwei");
            stringList.Add("drei");

            return Ok(stringList);
        }


    }
}
