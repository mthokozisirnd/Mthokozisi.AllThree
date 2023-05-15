using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ExerciseThree.Api.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var problemDetails = new ProblemDetails
            {
                Type = exception.GetType().FullName,
                Title = "An error occured while processing your request",
                Status = (int)HttpStatusCode.InternalServerError,
                Detail = exception.Message
            };

            context.Result = new ObjectResult(problemDetails);

            context.ExceptionHandled = true;
        }
    }
}
