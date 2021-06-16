using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomFilterSample.Filters
{
    public class MyCustomFilter : IActionFilter
    {
        private readonly ILogger<MyCustomFilter> _logger;

        

        public MyCustomFilter (ILogger<MyCustomFilter> logger)
        {
            _logger = logger;
        }

        
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogDebug("MyCustomFilter.OnActionExecuted - Hello From Response Bye Bye!");

            //context.HttpContext.User
            //context.HttpContext.Session
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogDebug("MyCustomFilter.OnActionExecuting - Hello to incoming Request");
        }
    }
}
