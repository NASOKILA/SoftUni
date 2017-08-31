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
		    // TODO: Implement me...
		}

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
		{
		    // TODO: Implement me...
		}

		[HttpPost]
		[Route("create")]
        [ValidateAntiForgeryToken]
		public ActionResult Create(Task task)
		{
			// TODO: Implement me...
        }

		[HttpGet]
		[Route("edit/{id}")]
        public ActionResult Edit(int id)
		{
			// TODO: Implement me...
        }

		[HttpPost]
		[Route("edit/{id}")]
        [ValidateAntiForgeryToken]
		public ActionResult EditConfirm(int id, Task taskModel)
		{
			// TODO: Implement me...
		}
	}
}