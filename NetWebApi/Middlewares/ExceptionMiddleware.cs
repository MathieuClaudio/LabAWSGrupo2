using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System;
using System.Text;

namespace NetWebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ExceptionMiddleware> logger)
        {
            try
            {
                context.Request.EnableBuffering();
                await _next(context);
            }
            catch (Exception ex)
            {


            }
        }

    }    
}
