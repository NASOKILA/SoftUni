namespace FDMC.Controllers
{
    using FDMC.Data;
    using FDMC.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeController : Controller
    {
        public FdmcContext Context { get; private set; }

        public HomeController()
        {
            this.Context = new FdmcContext();
        }

        public IActionResult Index()
        {
            List<Cat> cats = this.Context.Cats.ToList();
            ViewData["Cats"] = cats;
            return View();
        }
    }
}
