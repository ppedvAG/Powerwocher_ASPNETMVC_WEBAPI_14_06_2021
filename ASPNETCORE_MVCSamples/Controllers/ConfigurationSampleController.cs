using ASPNETCORE_MVCSamples.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVCSamples.Controllers
{
    public class ConfigurationSampleController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly SampleWebSettings _settings;
        public ConfigurationSampleController(IConfiguration configuration, IOptions<SampleWebSettings> settingOptions)
        {
            _configuration = configuration;
            _settings = settingOptions.Value;
        }

        public IActionResult Sample1()
        {
            PositionOptions positionOptions = new();
            _configuration.GetSection(PositionOptions.stringPosition).Bind(positionOptions);

            return View();
        }
    }
}
