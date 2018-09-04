using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FindMyPet.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FindMyPet.Web.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using SoftUniClone.Web.Areas.Identity.Services;
using System.Diagnostics;
using FindMyPet.Web.Filters;
using FindMyPet.Web.Static;
using FindMyPet.Models;
using Microsoft.Extensions.FileProviders;
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


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            
            services.AddDbContext<FindMyPetDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString(findMyPetConnection)));
            
            
            //Change the User for the Context  and we add roles to the users and we can use the Role Manager
            services.AddIdentity<User, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<FindMyPetDbContext>();
            

            //external authentication
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
                
            
            //Add EmailService that sends real Emails
            services.AddSingleton<IEmailSender, EmailSender>();


            //change password configurations
            services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1; 
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;


                //lock user account for 10 minutes if 3 times login fails
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);

            });


            //add session if we need it
            services.AddSession();


            //add the stopWatch so tou can pass it true the constructor
            services.AddScoped<Stopwatch>();


            services.AddMvc(options => {
                options.Filters.Add<LogExecutionFIlter>();
                //options.Filters.Add(new LogExecution());   THIS WORKS JUST THE SAME
            });

            
            //Change path for Unauthorized redirection
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Identity/Account/LogIn");
            

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }





        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.SeedDatabase();   //Seed the database with roles

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
