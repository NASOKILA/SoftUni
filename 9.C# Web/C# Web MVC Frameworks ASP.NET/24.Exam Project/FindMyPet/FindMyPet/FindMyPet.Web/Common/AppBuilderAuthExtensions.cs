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


                //check if role exists
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name))
                    {
                        await roleManager.CreateAsync(role);
                    }
                }


                //create admin by default user if it does not exist
                var user = await userManager.FindByNameAsync("admin@abv.bg");
                if (user == null)
                {

                    //we create a new user
                    user = new User()
                    {
                        UserName = "admin@abv.bg",
                        Email = "admin@abv.bg"
                    };

                    //we create the new user with the userManager and set default password
                    await userManager.CreateAsync(user, DefaultAdminPassword);
                }

                //add the role to the user
                await userManager.AddToRoleAsync(user, roles[0].Name);

            }
        }
    }
}
