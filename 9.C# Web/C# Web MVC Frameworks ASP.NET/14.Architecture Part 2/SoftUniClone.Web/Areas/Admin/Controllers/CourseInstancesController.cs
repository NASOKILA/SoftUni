using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniClone.Data;
using SoftUniClone.Models;
using SoftUniClone.Web.Areas.Admin.Models.BindingModels;
using SoftUniClone.Web.Areas.Admin.Models.ViewModels;
using System;
using System.Linq;

namespace SoftUniClone.Web.Areas.Admin.Controllers
{
    public class CourseInstancesController : AdminController
    {
        private readonly SoftUniCloneContext context;
        private readonly IMapper mapper;

        public CourseInstancesController(
            SoftUniCloneContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var course = this.context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            var model = new InstanceCreationBindingModel()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1),
                CourseId = course.Id
            };

            this.ViewData["course"] = course.Name;
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(InstanceCreationBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var instance = this.mapper.Map<CourseInstance>(model);
            this.context.CourseInstances.Add(instance);
            this.context.SaveChanges();

            // TODO: redirect to details
            return RedirectToAction("Details", new { id = instance.Id});
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            // TODO: Add lecturer
            var course = this.context.CourseInstances
                .Include(c => c.Course)
                .FirstOrDefault(c => c.Id == id);

            var model = this.mapper.Map<CourseInstanceDetailsViewModel>(course);
            return View(model);
        }
    }
}