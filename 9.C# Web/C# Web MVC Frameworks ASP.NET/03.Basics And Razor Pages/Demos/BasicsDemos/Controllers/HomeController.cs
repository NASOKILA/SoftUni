namespace BasicsDemos.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using BasicsDemos.Models;
    
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";

            return View();
        }

        [Route("About")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        
        [Route("Privacy")]
        [Route("About/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
        
        //We can change the route of a given action
        //We can have many routs for on action
        [Route("Home/ContactNasko")]
        [Route("Home/NaskoContact")]
        [Route("Home/ContactNaskoContact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
