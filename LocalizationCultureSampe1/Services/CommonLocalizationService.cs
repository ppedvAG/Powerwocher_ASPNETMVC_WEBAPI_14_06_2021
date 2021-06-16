﻿using LocalizationCultureSampe1.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LocalizationCultureSampe1.Services
{
    public class CommonLocalizationService
    {
        private readonly IStringLocalizer localizer;
        public CommonLocalizationService(IStringLocalizerFactory factory)
        {
            var assemblyName = new AssemblyName(typeof(CommonResources).GetTypeInfo().Assembly.FullName);
            localizer = factory.Create(nameof(CommonResources), assemblyName.Name);
        }

        public string Get(string key)
        {
            return localizer[key];
        }
    }
}
