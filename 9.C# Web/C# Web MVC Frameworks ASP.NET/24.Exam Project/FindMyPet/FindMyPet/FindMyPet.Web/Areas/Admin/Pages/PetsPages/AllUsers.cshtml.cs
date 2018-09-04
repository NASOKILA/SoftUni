using System.Collections.Generic;
using System.Linq;
using FindMyPet.Data;
using FindMyPet.Models;
using FindMyPet.Web.Static;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindMyPet.Web.Areas.Admin.Pages.PetsPages
{
    public class AllUsersModel : PageModel
    {
        public List<User> AllUsers { get; set; }

        public IActionResult OnGet()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Redirect(StaticConstants.LoginRedirect);
            }

            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                isLoggedIn = true;
                isAdmin = currentUser.Claims.Any(c => c.Value == StaticConstants.AdminRole);
                if (!isAdmin)
                {
                    return new RedirectToActionResult(StaticConstants.All, StaticConstants.Pets, new { @area = StaticConstants.Empty });
                }
            }

            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();


            using (var context = new FindMyPetDbContext())
            {
                var users = context.Users
                    .ToList();
                
                this.AllUsers = users.Where(u => u.Email != this.User.Identity.Name).ToList();
                ViewData[StaticConstants.UserList] = users;
                return Page();
            }
        }
    }
}
