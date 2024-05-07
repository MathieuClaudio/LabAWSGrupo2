using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System;
using System.Text;

namespace NetWebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log de la excepción
                _logger.LogError($"Se ha producido una excepción: {ex}");

                // Devuelve una respuesta al cliente
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Error interno del servidor.");
            }
        }

    }    
}
