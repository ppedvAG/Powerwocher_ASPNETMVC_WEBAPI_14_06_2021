using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomFilterSample.Filters
{
    public class MyCustomFilterAsync : IAsyncActionFilter
    {
        private readonly ILogger<MyCustomFilterAsync> _logger;

        

        public MyCustomFilterAsync(ILogger<MyCustomFilterAsync> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _logger.LogInformation("MyCustomFilterAsync.MyCustomFilterAsync");

            // execute any code before the action executes
            var result = await next();
            // execute any code after the action executes
        }
    }
}
