using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Agro.Shared.Api.Common.Middlewares
{
    /// <summary>
    /// Custom exception handler middleware
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        #region Fields

        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        #endregion

        #region Constructor

        public ExceptionHandlerMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        #endregion

        #region Public functions

        public async Task InvokeAsync(HttpContext context, ILogger<ExceptionHandlerMiddleware> logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(exception, context, logger);
            }
        }

        #endregion

        #region Private functions

        private Task HandleExceptionAsync(Exception exception, HttpContext context, ILogger<ExceptionHandlerMiddleware> logger)
        {
            var httpStatusCode = HttpStatusCode.InternalServerError;
            string response;

            switch (exception)
            {
                case RestException restException:
                    logger.LogError(exception, "Rest exception occured");

                    httpStatusCode = restException.StatusCode;
                    response = JsonSerializer.Serialize(Response.Fail<string>(restException.Message, restException.Errors));
                    break;
                default:
                    logger.LogError(exception, "Exception occured");

                    string message = "Internal server error";
                    if (_env.IsDevelopment())
                        message = exception.Message + "; " + exception.StackTrace;

                    response = JsonSerializer.Serialize(Response.Fail<string>(message, null));
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;

            return context.Response.WriteAsync(response);
        }

        #endregion
    }
}
