using System;
using System.Linq;
using System.Web.Mvc;
using TeisterMask.Models;

namespace TeisterMask.Controllers
{
        [ValidateInput(false)]
	public class TaskController : Controller
	{
	    [HttpGet]
            [Route("")]
	    public ActionResult Index()
	    {
            using (var db = new TeisterMaskDbContext())
            {
                var tasks = db.Tasks.ToList();
                return View(tasks);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
		{
            return View();
		}

		[HttpPost]
		[Route("create")]
        [ValidateAntiForgeryToken]
		public ActionResult Create(Task task)
		{
            if (ModelState.IsValid)
            {
                using (var db = new TeisterMaskDbContext())
                {
                    db.Tasks.Add(task);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            // AKO NESHTO NE E NARED OSTAVQME NA TAZI STRANICA
            return View();
        }

		[HttpGet]
		[Route("edit/{id}")]
        public ActionResult Edit(int id)
		{
            using (var db = new TeisterMaskDbContext())
            {
                Task task = db.Tasks.Find(id);

                if (task != null) // AKO NE E NULEVO
                {
                    return View(task);
                }

            }

            return RedirectToAction("Index");
        }

		[HttpPost]
		[Route("edit/{id}")]
        [ValidateAntiForgeryToken]
		public ActionResult EditConfirm(int id, Task taskModel)
		{

            using (var db = new TeisterMaskDbContext())
            {

                Task task = db.Tasks.Find(id);

                if (taskModel.Title == null || taskModel.Status == null)
                {
                    return RedirectToAction("Edit");
                }

                task.Title = taskModel.Title;
                task.Status = taskModel.Status;

                db.SaveChanges();

                return Redirect("/");

            }
        }
	}
}