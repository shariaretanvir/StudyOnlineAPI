using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudyOnlineAPI.Middlewares
{
    public class GlobalException
    {
        public RequestDelegate next { get; }
        public ILogger<GlobalException> logger { get; }

        public GlobalException(RequestDelegate next,ILogger<GlobalException> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
                if(context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    await PrepareUnAuthorizeResponse(context);
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                await PrepareGlobalErrorResponse(context, e);
            }
        }

        private async Task PrepareGlobalErrorResponse(HttpContext context, Exception e)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var resposne = JsonSerializer.Serialize(new
            {
                StatusCode = statusCode,
                Message = e.Message
            });
            await context.Response.WriteAsync(resposne);
        }

        private async Task PrepareUnAuthorizeResponse(HttpContext context)
        {
            //var statusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var resposne = JsonSerializer.Serialize(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Invalid Credential. Please give proper credential to authorize"
            });
            await context.Response.WriteAsync(resposne);
        }
    }
}
