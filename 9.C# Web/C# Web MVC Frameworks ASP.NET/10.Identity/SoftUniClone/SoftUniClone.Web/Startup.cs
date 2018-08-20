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
using SoftUniClone.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoftUniClone.Web.Filters;
using System.Diagnostics;

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
            //We add Facebook and Google Authentication !!!!!!!!!!!!!!!!!!!!!!!
            services.AddAuthentication()
            .AddFacebook(options => {

                //Facebook neds to know the AppId and AppSecret, if someone else knows them he can login
                options.AppId = "";
                options.AppSecret = "";

            })
            .AddGoogle();
            */

            services.AddDefaultIdentity<IdentityUser>(config =>
            {

                //We can say that to login we need the email of the user to be confirmed
                    //config.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            



            //We can override the default configuration of anything here :
            //We will change the passsword requirements of the registration form :
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
