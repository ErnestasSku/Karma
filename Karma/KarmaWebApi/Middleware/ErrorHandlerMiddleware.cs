using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http.Extensions;
using Backend;

namespace KarmaWebApi.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IHostingEnvironment _environment;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger logger, IHostingEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessException ex)
            {
                await LogErrorExceptionWithRequestBody(context, ex);
                await HandleBuisnessExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await LogErrorExceptionWithRequestBody(context, ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorMessage = (_environment.IsDevelopment()) ? JsonConvert.SerializeObject("Internal server error happened.") : JsonConvert.SerializeObject(exception, Formatting.Indented);

            return context.Response.WriteAsync(new
            {
                Message = errorMessage
            }.ToString());
            
        }
        private Task HandleBuisnessExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorMessage = (_environment.IsDevelopment()) ? JsonConvert.SerializeObject("An error happened with Business code.") : JsonConvert.SerializeObject(exception, Formatting.Indented);

            return context.Response.WriteAsync(new
            {
                Message = errorMessage
            }.ToString());

        }


        private async Task LogErrorExceptionWithRequestBody(HttpContext context, Exception exception)
        {
            context.Request.EnableBuffering();
            context.Request.Body.Seek(0, SeekOrigin.Begin);
            using (var reader = new StreamReader(context.Request.Body))
            {
                var body = await reader.ReadToEndAsync();

                _logger.Error(
                    exception,
                    $"WebApi exception, Method: {{method}}, Content: {{faultMessage}}",
                    $"{context.Request.Method} {context.Request.GetDisplayUrl()}", JsonConvert.SerializeObject(body));
                context.Request.Body.Seek(0, SeekOrigin.Begin);

            }
        }

    }
}
