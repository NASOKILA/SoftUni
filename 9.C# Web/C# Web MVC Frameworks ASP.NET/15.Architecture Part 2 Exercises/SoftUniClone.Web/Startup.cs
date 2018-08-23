using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniClone.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;
using SoftUniClone.Web.Areas.Identity.Services;
using SoftUniClone.Models;
using SoftUniClone.Web.Common;
using AutoMapper;
using SoftUniClone.Services.Admin.Interfaces;
using SoftUniClone.Services.Admin;
using Microsoft.AspNetCore.Routing;
using SoftUniClone.Services.Lecturer;
using SoftUniClone.Services.Lecturer.Interfaces;

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

            services.AddDbContext<SoftUniCloneContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("SoftUniClone")));

            services
                .AddIdentity<User, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<SoftUniCloneContext>();

            /*
            services.AddAuthentication()
                .AddFacebook(options =>
                {
                    options.AppId = this.Configuration.GetSection("Facebook:AppId").Value;
                    options.AppSecret = this.Configuration.GetSection("Facebook:AppSecret").Value;
                })
                .AddGoogle(options =>
                {
                    options.ClientId = this.Configuration.GetSection("Google:ClientId").Value;
                    options.ClientSecret = this.Configuration.GetSection("Google:ClientSecret").Value;
                })
                .AddGitHub(options =>
                {
                    options.ClientId = this.Configuration.GetSection("GitHub:ClientId").Value;
                    options.ClientSecret = this.Configuration.GetSection("GitHub:ClientSecret").Value;
                });
                */
            services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions()
                {
                    RequiredLength = 4,
                    RequiredUniqueChars = 1,
                    RequireLowercase = true,
                    RequireDigit = false,
                    RequireUppercase = false,
                    RequireNonAlphanumeric = false
                };

                // options.SignIn.RequireConfirmedEmail = true;
            });

            services.AddSingleton<IEmailSender, SendGridEmailSender>();
            services.Configure<SendGridOptions>(this.Configuration.GetSection("EmailSettings"));

            services.AddAutoMapper();

            RegisterServiceLayer(services);

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env)
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

            if (env.IsDevelopment())
            {
                app.SeedDatabase();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "area",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void RegisterServiceLayer(IServiceCollection services)
        {
            services.AddScoped<IAdminCoursesService, AdminCoursesService>();
            services.AddScoped<IAdminCourseInstancesService, AdminCourseInstancesService>();

            services.AddScoped<ILecturerCourseInstancesService, LecturerCourseInstancesService>();
        }
    }
}