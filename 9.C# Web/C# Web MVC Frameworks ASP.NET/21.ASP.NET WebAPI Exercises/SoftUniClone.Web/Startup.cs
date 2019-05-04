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
using SoftUniClone.Web.Hubs;

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

            //we can add a folder of resourses to use it
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            //we confidure the localizators
            services.Configure<RequestLocalizationOptions>(options =>
            {
                //we pass the languages that we want to use
                options.AddSupportedCultures("en", "bg");

                //we add the cultires to
                options.AddSupportedUICultures("en", "bg");
            });


            //dobavqme kashing na danni.
            services.AddResponseCaching();
            services.AddResponseCompression();




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



            //SignalR
            services.AddSignalR();

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

            //VkluchvaME SingleR, nqma default konfiguraciq
            app.UseSignalR(opt => {
                opt.MapHub<QuestionsHub>("/questions"); //mapvame QuestionsHub klasa kum "/questions" routa
            });







            //pozvilqva ni da NE izvikvame edin action ili view mnogo na broi puti. Raboti za stranici i za actioni.

            app.UseResponseCaching();  // pozvolqvame keshirane
            app.UseResponseCompression(); //Kompresira vseki edin response


            //vkluchvame lokaclizatora
            app.UseRequestLocalization();


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