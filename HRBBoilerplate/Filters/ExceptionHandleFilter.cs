using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace HRBBoilerplate.Filters
{
    public class ExceptionHandleFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var details = new ProblemDetails {
                Title = "An error occured in you request",
                Detail = context.Exception.Message,
                Status = (int)HttpStatusCode.InternalServerError,
            };

            context.Result = new ObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}
