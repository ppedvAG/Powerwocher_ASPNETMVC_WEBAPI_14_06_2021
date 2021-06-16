using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationFilterSample.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var modelState = context.ModelState;

            if (!modelState.IsValid)
            {
                var errors = modelState.Values.SelectMany(v => v.Errors).Select(m => m.ErrorMessage).ToList();
                var stringBuilder = new StringBuilder();
                
                errors.ForEach(m => stringBuilder.AppendLine(m));
                context.Result = new BadRequestObjectResult(stringBuilder.ToString());
                
                return base.OnActionExecutionAsync(context, next);
            }

            return base.OnActionExecutionAsync(context, next);
        }
    }
}
