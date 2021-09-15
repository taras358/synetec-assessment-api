using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SynetecAssessmentApi.Domain.Exceptions;

namespace SynetecAssessmentApi.Middlewares
{
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandleMiddleware> _logger;
        
        public ExceptionHandleMiddleware(RequestDelegate next, 
            ILogger<ExceptionHandleMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (AppException ex)
            {
                var errorContent = JsonSerializer.Serialize(ex.Descriptions);
                context.Response.StatusCode = (int)ex.StatusCode;
                await context.Response.WriteAsync(errorContent);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Message={ex.Message}/StackTrace={ex.StackTrace}");
                
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(HttpStatusCode.InternalServerError.ToString());
            }
        }
    }
}