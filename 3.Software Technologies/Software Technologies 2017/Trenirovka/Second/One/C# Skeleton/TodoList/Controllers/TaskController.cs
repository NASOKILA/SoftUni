using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
        [ValidateInput(false)]
	public class TaskController : Controller
	{
	    [HttpGet]
        [Route("")]
	    public ActionResult Index()
	    {
            using (var db = new TodoListDbContext())
            {
                List<Task> tasks = db.Tasks.ToList();
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
                using (var db = new TodoListDbContext())
                {

                    db.Tasks.Add(task);
                    db.SaveChanges();

                    return Redirect("/");
                }

            }

            return View(task);

        }

		[HttpGet]
		[Route("delete/{id}")]
        public ActionResult Delete(int id)
		{
            using (var db = new TodoListDbContext())
            {
                Task task = db.Tasks.Find(id);
                return View(task);
            }
            
        }

		[HttpPost]
		[Route("delete/{id}")]
        [ValidateAntiForgeryToken]
		public ActionResult DeleteConfirm(int id)
		{
            using (var db = new TodoListDbContext())
            {
                Task task = db.Tasks.Find(id);

                if (task == null)
                {
                    return Redirect("/");
                }

                db.Tasks.Remove(task);
                db.SaveChanges();


                return Redirect("/");
            }
            
        }
	}
}