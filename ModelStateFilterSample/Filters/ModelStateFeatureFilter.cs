using Microsoft.AspNetCore.Mvc;
using ModelStateFilterSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelStateFilterSample.Filters
{
    public class ModelStateFeatureFilter : IActionResult
    {
        public Task ExecuteResultAsync(ActionContext context)
        {
            var state = context.ModelState;
            context.HttpContext.Features.Set(new ModelStateFeature(state));
            return Task.CompletedTask;
        }
    }
}
