using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FindMyPet.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;
using SoftUniClone.Web.Areas.Identity.Services;
using System.Diagnostics;
using FindMyPet.Web.Filters;
using FindMyPet.Web.Static;
using FindMyPet.Models;
using FindMyPet.Web.Common;

namespace FindMyPet.Web
{
    public class Startup
    {
        private const string findMyPetConnection = "FindMyPetConnection";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            
            services.AddDbContext<FindMyPetDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString(findMyPetConnection)));
            
            services.AddIdentity<User, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<FindMyPetDbContext>();
            
            services
                .AddAuthentication()
                .AddFacebook(options =>
                {
                    options.AppId = ExternalLoginIds.FacebookAppId;
                    options.AppSecret = ExternalLoginIds.FacebookAppSecret;
                })
                .AddGoogle(options =>
                {
                    options.ClientId = ExternalLoginIds.GoogleClientId;
                    options.ClientSecret = ExternalLoginIds.GoogleClientSecret;
                });
                
            services.AddSingleton<IEmailSender, EmailSender>();
            
            services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1; 
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);

            });
            
            services.AddSession();
            
            services.AddScoped<Stopwatch>();
            
            services.AddMvc(options => {
                options.Filters.Add<LogExecutionFIlter>();
            });
            
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Identity/Account/LogIn");
            
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();
            app.SeedDatabase(); 

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
