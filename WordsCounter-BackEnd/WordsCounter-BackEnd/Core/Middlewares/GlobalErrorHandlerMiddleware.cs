using System;
using System.Net;
using System.Threading.Tasks;
using Application.Core.ErrorHandling.Constants;
using Application.Core.ErrorHandling.Exceptions;
using Application.Core.ErrorHandling.Models;
using Application.Core.StaticValues.ContentTypes;
using Application.Core.StaticValues.ContentTypes.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Web.Core.Middlewares
{
    public class GlobalErrorHandlerMiddleware
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly RequestDelegate _next;

        private readonly ILogger<GlobalErrorHandlerMiddleware> _logger;

        public GlobalErrorHandlerMiddleware(IWebHostEnvironment webHostEnvironment, RequestDelegate next, ILogger<GlobalErrorHandlerMiddleware> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException ex)
            {
                _logger.LogWarning(ex, $"Exception Code: {(int)ex.ExceptionCode}");

                ApiErrorModel payload = new ApiErrorModel
                {
                    ExceptionCode = ex.ExceptionCode,
                    Message = ex.Message,
                    Exception = _webHostEnvironment.IsDevelopment() ? ex.ToString() : ApiErrorConstants.NON_DEVELOPMENT_EXCEPTION_MESSAGE
                };

                await WriteAsJsonAsync(context, HttpStatusCode.BadRequest, payload);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                InternalServerErrorModel payload = new InternalServerErrorModel
                {
                    Message = ex.Message,
                    Exception = _webHostEnvironment.IsDevelopment() ? ex.ToString() : InternalServerErrorConstants.NON_DEVELOPMENT_EXCEPTION_MESSAGE
                };

                await WriteAsJsonAsync(context, HttpStatusCode.InternalServerError, payload);
            }
        }

        private static async Task WriteAsJsonAsync(HttpContext context, HttpStatusCode httpStatusCode, object payload, bool clearResponseBeforeWrite = true)
        {
            if (clearResponseBeforeWrite)
            {
                context.Response.Clear();
            }

            context.Response.StatusCode = (int)httpStatusCode;
            context.Response.ContentType = ContentTypes.GetContentType(ContentType.Json);

            string jsonText = JsonConvert.SerializeObject(payload);

            await context.Response.WriteAsync(jsonText);
        }
    }
}
