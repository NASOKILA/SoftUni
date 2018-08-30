using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindMyPet.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using FindMyPet.Data;
using FindMyPet.Models;
namespace FindMyPet.Web.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Authorize(Roles = "Admin")] 
    public class HomeController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly FindMyPetDbContext context;
        public HomeController(
            UserManager<User> userManager,
            FindMyPetDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public IActionResult Index()
        {  

            ViewData["LoggedIn"] = "True";
            ViewData["IsAdmin"] = "True";

            return new RedirectToActionResult("All", "Pets", new { @area = "Admin" });
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Your application description page.";

            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            if (currentUser != null)
            {
                isLoggedIn = true;

                isAdmin = await this.userManager.IsInRoleAsync(currentUser, "Admin");
            }


            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();
            
            return View();
        }

        public async Task<IActionResult> Contact()
        {
            ViewData["Message"] = "Your contact page.";

            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            if (currentUser != null)
            {
                isLoggedIn = true;

                isAdmin = await this.userManager.IsInRoleAsync(currentUser, "Admin");

                if (isAdmin == true)
                {
                    return new RedirectToActionResult("Index", "Home", new { @area = "Admin" });
                }
            }


            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();

            return new RedirectToActionResult("Index", "Home", new { @area = "" });
        }

        public async Task<IActionResult> Privacy()
        {
            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            if (currentUser != null)
            {
                isLoggedIn = true;

                isAdmin = await this.userManager.IsInRoleAsync(currentUser, "Admin");
            }


            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            if (currentUser != null)
            {
                isLoggedIn = true;

                isAdmin = await this.userManager.IsInRoleAsync(currentUser, "Admin");
            }


            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
