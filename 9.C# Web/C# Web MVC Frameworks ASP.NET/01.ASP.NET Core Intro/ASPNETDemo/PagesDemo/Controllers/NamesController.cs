namespace PagesDemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class NamesController: Controller
    {
        public IActionResult All() {
            string[] names = new[] { "Nasko", "Asi", "Toni" };
            return View(model:names);
        }
    }
}
