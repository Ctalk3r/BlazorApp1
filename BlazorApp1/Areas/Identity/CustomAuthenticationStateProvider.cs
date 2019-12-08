using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BlazorApp1.Areas.Identity
{
	public class CustomAuthenticationStateProvider : RevalidatingIdentityAuthenticationStateProvider<User>
	{
        private UserManager<User> context;
        private static string username;

        public CustomAuthenticationStateProvider(ILoggerFactory loggerFactory, IServiceScopeFactory scopeFactory, IOptions<IdentityOptions> optionsAccessor, UserManager<User> context) : base(loggerFactory, scopeFactory, optionsAccessor)
        {
            this.context = context;
        }

        public static bool IsAuthentificating { get; set; }
        public static AuthenticationProperties Properties { get; set; }
        public static string Provider { get; set; }

        private static bool IsAuthorized { get; set; }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (context != null)
            {
                if (IsAuthorized)
                {
                    var user = await context.FindByEmailAsync(username);

                    var identity = new ClaimsIdentity(new[]
{
                        new Claim(ClaimTypes.Name, user.FirstName ?? user.Email),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role ?? "freelancer")
                    }, "Custom authentication type");
                    var claim = new ClaimsPrincipal(identity);
                    return await Task.FromResult(new AuthenticationState(claim));
                }
                else
                {
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }
            }
            else
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }

        public async Task<bool> CanSignIn(string username, string password, UserManager<User> userManager)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user != null && user.PasswordHash != null &&
                userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password) != 
                                                                                PasswordVerificationResult.Failed)
            {
                return true;
            }
            return false;
        }

        public void MarkAsAuthentificated(string username, UserManager<User> context)
        {
            CustomAuthenticationStateProvider.username = username;
            this.context = context;
            IsAuthorized = true;
            base.NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void MarkAsNonAuthentificated()
        {
            IsAuthorized = false;
            base.NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
