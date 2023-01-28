using System;
using System.Net;
using System.Text.Json;

namespace project.api.Middleware
{
	public class ErrorHandlingMiddleware
	{
		private readonly RequestDelegate _next;

		public ErrorHandlingMiddleware(RequestDelegate requestDelegate)
		{
			_next = requestDelegate;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch(Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
			var code = HttpStatusCode.InternalServerError; // erreur 500
			var result = JsonSerializer.Serialize(new { error = "Une erreur à eu lieu pendant la requête !" });
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)code;
			return context.Response.WriteAsync(result);
        }
    }
}

