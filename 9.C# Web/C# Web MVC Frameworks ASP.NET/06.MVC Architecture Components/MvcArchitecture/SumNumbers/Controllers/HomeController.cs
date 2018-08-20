using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SumNumbers.Models;

namespace SumNumbers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            //HttpContext holds alot of usefull information.
            var path = this.HttpContext.Request.Path.Value;

            //With ViewData and ViewBag we can pass data to the view.   
            this.ViewData["NewTitle"] = "NASKO TITLE";
            
            

            return View();
        }

        public IActionResult About()
        {
            
            this.TempData["Message"] = "MESSAGE KEPT AFTER REDIRECT !";
            return RedirectToAction("Index", "Home");
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
