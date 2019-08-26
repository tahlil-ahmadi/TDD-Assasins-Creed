using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using FlightSchedule.Persistence.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace FlightSchedule.RestApi.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static void UseSandbox(this IApplicationBuilder app)
        {
            app.UseMiddleware<SandboxMiddleware>();
        }
    }
    public class SandboxMiddleware
    {
        private readonly RequestDelegate _next;

        public SandboxMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConnectionManager connectionManager)
        {
            if (context.Request.Headers.ContainsKey("Sandbox"))
            {
                var dbName = context.Request.Headers["Sandbox"];
                connectionManager.Override(dbName); //Create full connection here
            }
            await _next(context);
        }
    }
}
