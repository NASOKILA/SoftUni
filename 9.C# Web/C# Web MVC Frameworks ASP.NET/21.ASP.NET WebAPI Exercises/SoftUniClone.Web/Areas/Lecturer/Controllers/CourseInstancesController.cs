using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftUniClone.Services.Lecturer.Interfaces;

namespace SoftUniClone.Web.Areas.Lecturer.Controllers
{
    public class CourseInstancesController : LecturerController
    {
        private readonly ILecturerCourseInstancesService courseInstancesService;

        public CourseInstancesController(
            ILecturerCourseInstancesService courseInstancesService)
        {
            this.courseInstancesService = courseInstancesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, CourseInstanceEditingModel model)
        //{
        //    await this.courseInstancesService.Edit(id, this.User);
        //    return View();
        //}
    }
}