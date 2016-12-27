using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Helpers;
using System.Web.Http.Filters;
using Newtonsoft.Json;
using Serilog;
using Serilog.Formatting.Json;
using SF.API.Infrastructure.Users;

namespace SF.API.ExceptionHandling
{
    /// <summary>
    /// Handles all the exception in the request
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public sealed class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        static CustomExceptionFilterAttribute()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.RollingFile(@"D:\Install\log-{Date}.txt",
                    retainedFileCountLimit: 2,
                    shared: true,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }


        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext == null)
            {
                throw new ArgumentNullException(nameof(actionExecutedContext));
            }

            var exceptionType = actionExecutedContext.Exception.GetType();
            if (exceptionType == typeof (InControllerException))
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

            var url = actionExecutedContext.Request.RequestUri.AbsoluteUri;
            var parameters = actionExecutedContext.ActionContext.ActionArguments["command"] as Command;
            var stacktrace = actionExecutedContext.Exception.StackTrace;

            Log.Error(Environment.NewLine +
                      "url : {0}" + Environment.NewLine +
                      "parameters : {@1}" + Environment.NewLine +
                      "stacktrace : {2}" + Environment.NewLine,
                url, parameters, stacktrace);
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