using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoftUniClone.Web.Filters;
using System.Diagnostics;
using SoftUniClone.Data;
using AspNet.Security.OAuth.GitHub;
using SoftUniClone.Web.Areas.Identity.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using SoftUniClone.Models;
using Microsoft.Extensions.FileProviders;

namespace SoftUniClone.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            /*
             
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            */



            //We set it to use out User class and not the default one.
            //We can say that to login we need the email of the user to be confirmed
            //config.SignIn.RequireConfirmedEmail = true;
            services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            

            //Add google 
            services.AddAuthentication()
                .AddGoogle(options => {

                    options.ClientId = "303515638916-cns6mv23v2q29qsb0eevtvm0k98nlkvs.apps.googleusercontent.com";
                    options.ClientSecret = "7EJAVz4lCFGvCxMzmqk-SkSi";

                });

            

            //Add gitHub
            services.AddAuthentication()
                   .AddGitHub(options =>
                   {
                       options.ClientId = "5b19bf9587ff7b455a62";
                       options.ClientSecret = "7b2c7157e8c21067021cb18e95ee316bf196f5a7";
                   });

        /*
            //We add Facebook and Google Authentication !!!!!!!!!!!!!!!!!!!!!!!
            services.AddAuthentication()
            .AddFacebook(options =>
            {

                //Facebook neds to know the AppId and AppSecret, if someone else knows them he can login
                //te sa kato username i password
                options.AppId = "";
                options.AppSecret = "";

            });
        */





            //Add EmailService that sends real Emails
            services.AddSingleton<IEmailSender, EmailSender>();
            

            //We can override the default configuration of anything here :
            //We will change the passsword requirements
            services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions()
                {
                    RequiredLength = 3,
                    RequireUppercase = false,
                    RequireDigit = false,
                    RequiredUniqueChars = 0,
                    RequireLowercase = false,
                    RequireNonAlphanumeric = false
                };

                
                //we allow it for new users
                options.Lockout.AllowedForNewUsers = true;

                //logijn failed attemps by default is 5, we will change that to 3
                options.Lockout.MaxFailedAccessAttempts = 3;

                //we change the default time in which the account is locked, we set it to 1 minute
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);

            });


            services.Configure<StaticFileOptions>(config => {
                config.FileProvider = new PhysicalFileProvider("C:\\Users\\Asus\\SoftUni\\9.C# Web\\C# Web MVC Frameworks ASP.NET\\12.Architecture Part 1\\SoftUniClone\\SoftUniClone.Web\\wwwroot\\");
            });

            //add the stopWatch so tou can pass it true the constructor
            services.AddScoped<Stopwatch>();


            services.AddMvc(options => {
                options.Filters.Add<LogExecution>();
                //options.Filters.Add(new LogExecution());   THIS WORKS JUST THE SAME
            });

            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
