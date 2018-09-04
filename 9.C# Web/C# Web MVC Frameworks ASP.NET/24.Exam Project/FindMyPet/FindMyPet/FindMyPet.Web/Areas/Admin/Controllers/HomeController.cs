using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindMyPet.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using FindMyPet.Data;
using FindMyPet.Models;
using FindMyPet.Web.Static;

namespace FindMyPet.Web.Areas.Admin.Controllers
{
    
    [Area(StaticConstants.AdminRole)]
    [Authorize(Roles = StaticConstants.AdminRole)] 
    public class HomeController : Controller
    {
        private const string descriptionMessage = "Your application description page.";
        private const string contactMessage = "Your contact page.";

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

            ViewData[StaticConstants.LoggedIn] = StaticConstants.True;
            ViewData[StaticConstants.IsAdmin] = StaticConstants.True;

            return new RedirectToActionResult(StaticConstants.All, StaticConstants.Pets, new { @area = StaticConstants.AdminRole });
        }

        public async Task<IActionResult> About()
        {
            ViewData[StaticConstants.Message] = descriptionMessage;

            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            if (currentUser != null)
            {
                isLoggedIn = true;

                isAdmin = await this.userManager.IsInRoleAsync(currentUser, StaticConstants.AdminRole);
            }


            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();


            return View();
        }

        public async Task<IActionResult> Contact()
        {
            ViewData[StaticConstants.Message] = contactMessage;

            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            if (currentUser != null)
            {
                isLoggedIn = true;

                isAdmin = await this.userManager.IsInRoleAsync(currentUser, StaticConstants.AdminRole);

                if (isAdmin == true)
                {
                    return new RedirectToActionResult(StaticConstants.Index, StaticConstants.Home, new { @area = StaticConstants.AdminRole });
                }
            }


            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

            return new RedirectToActionResult(StaticConstants.Index, StaticConstants.Home, new { @area = StaticConstants.Empty });
        }

        public async Task<IActionResult> Privacy()
        {
            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            if (currentUser != null)
            {
                isLoggedIn = true;

                isAdmin = await this.userManager.IsInRoleAsync(currentUser, StaticConstants.IsAdmin);
            }


            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

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

                isAdmin = await this.userManager.IsInRoleAsync(currentUser, StaticConstants.AdminRole);
            }
            
            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();

            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
