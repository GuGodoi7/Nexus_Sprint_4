using _Nexus.Models;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace _Nexus.Services.SecurityService
{
    public class TokenAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _token;

        public TokenAuthenticationMiddleware(RequestDelegate next, string token)
        {
            _next = next;
            _token = token;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue("Authorization", out var tokenHeader))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Authorization header missing.");
                return;
            }

            if (tokenHeader != $"Bearer {_token}")
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized; 
                await context.Response.WriteAsync("Unauthorized.");
                return;
            }

            await _next(context);
        }
    }

}
