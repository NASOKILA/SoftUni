using Microsoft.AspNetCore.Mvc;

namespace SoftUniClone.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}