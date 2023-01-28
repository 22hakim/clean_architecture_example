using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace project.api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception; // équivalent Ex dans middleware 

        context.Result = new ObjectResult(new { error = "Une erreur géré par filter" })
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}

