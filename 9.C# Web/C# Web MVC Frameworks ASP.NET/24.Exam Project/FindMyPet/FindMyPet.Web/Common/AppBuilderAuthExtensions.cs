using FindMyPet.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace FindMyPet.Web.Common
{
    public static class AppBuilderAuthExtensions
    {
        public const string DefaultAdminPassword = "123123";

        public static IdentityRole[] roles = {
            new IdentityRole("Admin")
        };

        public static async void SeedDatabase(
            this IApplicationBuilder App
            )
        {

            var serviceFactory = App.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();

            using (scope)
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name))
                    {
                        await roleManager.CreateAsync(role);
                    }
                }
                
                var user = await userManager.FindByNameAsync("admin@abv.bg");
                if (user == null)
                {
                    
                    user = new User()
                    {
                        UserName = "admin@abv.bg",
                        FullName = "Administrator",
                        Email = "admin@abv.bg"
                        
                    };

                    await userManager.CreateAsync(user, DefaultAdminPassword);
                }

                await userManager.AddToRoleAsync(user, roles[0].Name);
            }
        }
    }
}
