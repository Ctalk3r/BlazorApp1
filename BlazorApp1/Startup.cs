using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorApp1.Areas.Identity;
using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using MatBlazor;
using EmbeddedBlazorContent;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using BlazorChatSample.Server.Hubs;

namespace BlazorApp1
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));
			services.AddIdentity<User, IdentityRole>(options =>
			{
				options.Password.RequiredLength = 6;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireDigit = false;
				options.SignIn.RequireConfirmedAccount = true;
			})
				.AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

			services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
			services.AddSingleton<IEmailSender, EmailSender>();
			services.AddRazorPages();
			services.AddServerSideBlazor();
			services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
			services.AddSingleton<WeatherForecastService>();

			services.AddHttpContextAccessor();
			services.AddScoped<HttpContextAccessor>();

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie();
			services.AddAuthentication()
				.AddGoogle(options =>
				{
					options.ClientId = Configuration["Google:ClientId"];
					options.ClientSecret = Configuration["Google:ClientSecret"];
					options.CallbackPath = "/Index";
					options.ClaimActions.MapJsonKey("urn:google:profile", "link");
					options.ClaimActions.MapJsonKey("urn:google:image", "picture");
				})
				.AddVkontakte(options =>
				{
					options.ClientId = Configuration["Vk:ClientId"];
					options.ClientSecret = Configuration["Vk:ClientSecret"];
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// app.UseMiddleware<IdentityMiddleware>();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}


			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEmbeddedBlazorContent(typeof(BaseMatComponent).Assembly);

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapBlazorHub();
				endpoints.MapFallbackToPage("/_Host");
				endpoints.MapHub<ChatHub>("/chathub");
			});
		}
	}
}
