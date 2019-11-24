using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BlazorApp1
{
    public class IdentityMiddleware
    {
        private RequestDelegate _next;
        public IdentityMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Cookies.ContainsKey("token"))
            {
                context.Response.Cookies.Append("token", Guid.NewGuid().ToString());
            }
            await _next.Invoke(context);
        }
    }
}
