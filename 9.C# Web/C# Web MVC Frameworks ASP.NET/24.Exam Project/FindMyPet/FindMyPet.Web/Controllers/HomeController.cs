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
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using FindMyPet.Models.Interfaces;

namespace FindMyPet.Web.Controllers
{


    //works with users
    //.getRolesAsync()     // roles of user
    // thi.User.IsInRole("Administrator")
    //.getUserAsync()    //current user
    //.AddToRoleAsync(user, roleName)    //add user to a role     //WE HAVE TO SEED THE ROLES
    //this.User.Identity.IsAuthenticated       //if user is logged in



    //[Authorize] //ako ne sme lognati ni vrushta v login stranicata
    //[Authorize(roles = "Administrator")] //ako ne admini ni othvurlq
    [AllowAnonymous]
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
            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                isLoggedIn = true;
                isAdmin = currentUser.Claims.Any(c => c.Value == "Admin");

                if (isAdmin == true)
                {
                    return new RedirectToActionResult("Index", "Home", new { @area = "Admin" });
                }


                ViewData["LoggedIn"] = isLoggedIn.ToString();
                ViewData["IsAdmin"] = isAdmin.ToString();

                return RedirectToAction("All", "Pets");
            }

            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();

            return View();
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

                if (isAdmin == true)
                {
                    return new RedirectToActionResult("Index", "Home", new { @area = "Admin" });
                }
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

            return View();
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
