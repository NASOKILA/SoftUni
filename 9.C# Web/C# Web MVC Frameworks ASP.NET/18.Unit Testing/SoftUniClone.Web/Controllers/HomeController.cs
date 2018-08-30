using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SoftUniClone.Models;
using SoftUniClone.Web.Models;

namespace SoftUniClone.Web.Controllers
{
    public class HomeController : Controller
    {
        //we have to make the controller understand deferen languages
        //There is a htmlLocalizer  which does not escape strings but StringLocalizer escapes strings.

        private readonly IStringLocalizer<HomeController> localizer;

        public HomeController()
        {

        }
        
        public IActionResult Index()
        {

            //to use the localizator is easy firt we add stuff to it it has key and value
           // string title = this.localizer["Something"];


            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
