using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Serilog;
using Serilog.Formatting.Json;

namespace SF.API.ExceptionHandling
{
    /// <summary>
    /// Handles all the exception in the request
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public sealed class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private const string _template = "{@dto}{NewLine}{@dto.url}";

        static CustomExceptionFilterAttribute()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.RollingFile(@"D:\Install\log-{Date}.txt", 
                retainedFileCountLimit: 2,
                shared: true)
                .CreateLogger();
        }


        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext == null)
            {
                throw new ArgumentNullException(nameof(actionExecutedContext));
            }

            var exceptionType = actionExecutedContext.Exception.GetType();
            if (exceptionType == typeof(InControllerException))
            {
                actionExecutedContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NoContent,
                    ReasonPhrase = ErrorMessages.NoRecordsFoundFilter.ToString(),
                    Content = new StringContent(ErrorMessages.UnhandledException.ToString())
                };
            }
            else
            {
                actionExecutedContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = ErrorMessages.UnhandledException.ToString(),
                    Content = new StringContent(ErrorMessages.TechnicalIssue.ToString())
                };
            }
            var dto =
                new
                {
                    url = actionExecutedContext.Request.RequestUri.AbsoluteUri,
                    parameters = actionExecutedContext.ActionContext.ActionArguments,
                    date = DateTime.Now.ToShortDateString(),
                    stacktrace = actionExecutedContext.Exception.StackTrace
                };
            Log.Error("",dto);
            
        }
    }

    public enum ErrorMessages
    {
        NoRecordsFoundFilter,
        UnhandledException,
        TechnicalIssue
    }

    public class InControllerException : Exception
    {
    }
}