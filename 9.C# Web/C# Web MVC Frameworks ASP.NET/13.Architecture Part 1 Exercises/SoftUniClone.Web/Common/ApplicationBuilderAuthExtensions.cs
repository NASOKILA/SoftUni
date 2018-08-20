using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SoftUniClone.Models;

namespace SoftUniClone.Web.Common
{
    //we use this class to add the roles
    public static class ApplicationBuilderAuthExtensions
    {
        private const string DefaultAdminPassword = "admin123";

        private static readonly IdentityRole[] roles =
        {
            new IdentityRole("Administrator"),
            new IdentityRole("Lecturer")
        };

        public static async void SeedDatabase(
            this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();
            using (scope)
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name))
                    {
                        var result = await roleManager.CreateAsync(role);
                    }
                }

                var user = await userManager.FindByNameAsync("admin");
                if (user == null)
                {
                    user = new User()
                    {
                        UserName = "admin",
                        Email = "admin@example.com"
                    };

                    var result = await userManager.CreateAsync(user, DefaultAdminPassword);
                    result = await userManager.AddToRoleAsync(user, roles[0].Name);
                }
            }
        }
    }
}
