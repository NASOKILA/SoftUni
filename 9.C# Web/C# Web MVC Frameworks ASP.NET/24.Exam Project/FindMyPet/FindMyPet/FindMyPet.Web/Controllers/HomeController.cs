using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindMyPet.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using FindMyPet.Data;
using FindMyPet.Models;
using FindMyPet.Web.Static;
using Microsoft.AspNetCore.Http;

namespace FindMyPet.Web.Controllers
{

    [AllowAnonymous]
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
            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                isLoggedIn = true;
                isAdmin = currentUser.Claims.Any(c => c.Value == StaticConstants.AdminRole);

                if (isAdmin == true)
                {
                    return new RedirectToActionResult(StaticConstants.Index, StaticConstants.Home, new { @area = StaticConstants.AdminRole });
                }


                ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
                ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

                return RedirectToAction(StaticConstants.All, StaticConstants.Pets);
            }

            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

            //sevices.AddSession()   app.UseSession()  we can save models
            this.HttpContext.Session.SetString("SessionKey", "String to test the session.");

            return View();
        }
        
        public async Task<IActionResult> About()
        {

            string strFromSession = this.HttpContext.Session.GetString("SessionTest");

            ViewData[StaticConstants.Message] = descriptionMessage;


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

                isAdmin = await this.userManager.IsInRoleAsync(currentUser, StaticConstants.AdminRole);
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
