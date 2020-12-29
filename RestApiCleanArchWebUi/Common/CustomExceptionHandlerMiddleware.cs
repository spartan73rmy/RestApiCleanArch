using RestApiCleanArch.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
namespace RestApiCleanArch.WebUi.Common
{
    public class CustomExceptionHandlerMiddleware
    {
        private class ErrorResult
        {
            public ErrorResult(string error)
            {
                this.Error = error;
            }
            public string Error { get; private set; }
            public IDictionary<string, string[]> Details { get; set; } = new Dictionary<string, string[]>();
        }

        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string message = exception.Message;
            IDictionary<string, string[]> details = new Dictionary<string, string[]>();
            var code = HttpStatusCode.InternalServerError;

            switch (exception)
            {
                case ValidationException exceptionA:
                    code = HttpStatusCode.BadRequest;
                    details = exceptionA.Failures;
                    break;
                case NotAuthorizedException exceptionA:
                    int index = 0;
                    foreach (var fallo in exceptionA.Failures)
                    {
                        details.Add(index.ToString(), new string[] { fallo });
                        index++;
                    }
                    code = HttpStatusCode.Unauthorized;
                    break;
                case ForbiddenException exceptionA:
                    code = HttpStatusCode.Forbidden;
                    break;
                case BadRequestException exceptionA:
                    code = HttpStatusCode.BadRequest;
                    break;
                case NotFoundException exceptionA:
                    code = HttpStatusCode.NotFound;
                    message = "No encontrado, compruebe su información";
                    break;
                // Ninguna excepcion conocida, error en el servidor
                default:
                    message = "Ha ocurrido un error desconocido, inténtelo más tarde";
                    logger.LogError(exception, "Error Desconocido");
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            var error = new ErrorResult(message)
            {
                Details = details
            };
            return context.Response.WriteAsync(JsonConvert.SerializeObject(error,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }));
        }
    }
}