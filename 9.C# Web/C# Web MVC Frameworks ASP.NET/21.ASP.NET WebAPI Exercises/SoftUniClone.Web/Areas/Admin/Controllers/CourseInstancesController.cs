using Microsoft.AspNetCore.Mvc;
using SoftUniClone.Common.Admin.BindingModels;
using SoftUniClone.Services.Admin.Interfaces;
using System;
using System.Threading.Tasks;

namespace SoftUniClone.Web.Areas.Admin.Controllers
{
    public class CourseInstancesController : AdminController
    {
        private readonly IAdminCourseInstancesService courseInstancesService;

        public CourseInstancesController(IAdminCourseInstancesService courseInstancesService)
        {
            this.courseInstancesService = courseInstancesService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var model = await this.courseInstancesService.PrepareInstanceForCreationAsync(courseId: id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InstanceCreationBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            int instanceId = await this.courseInstancesService.CreateInstanceAsync(model);
            // TODO: redirect to details
            return RedirectToAction("Details", new { id = instanceId });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            // TODO: Implement this
            throw new NotImplementedException();
        }
    }
}