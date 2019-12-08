using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Google;
using BlazorApp1.Areas.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Identity;

namespace BlazorApp1
{
    public class IdentityMiddleware : IMiddleware
    {
        AuthenticationStateProvider myProvider;
        SignInManager<User> _signInManager;

        public IdentityMiddleware(AuthenticationStateProvider authenticationStateProvider, SignInManager<User> signInManager)
        {
            myProvider = authenticationStateProvider as CustomAuthenticationStateProvider;
            _signInManager = signInManager;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (CustomAuthenticationStateProvider.IsAuthentificating == true)
            {
                context.Response.OnStarting(async () =>
                {
                    await context.ChallengeAsync(CustomAuthenticationStateProvider.Provider,
                                                 CustomAuthenticationStateProvider.Properties);
                });
                CustomAuthenticationStateProvider.IsAuthentificating = false;
            }
            await next(context);
        }
    }
}
