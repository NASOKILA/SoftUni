using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniClone.Data;
using SoftUniClone.Models;
using SoftUniClone.Web.Areas.Admin.Models.BindingModels;
using SoftUniClone.Web.Areas.Admin.Models.ViewModels;
using SoftUniClone.Web.Helpers.Messages;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniClone.Web.Areas.Admin.Controllers
{
    //controller for courses and its only for admins
    public class CoursesController : AdminController
    {
        //inject the things needed

        private readonly SoftUniCloneContext context;
        private readonly IMapper mapper;

        public CoursesController(
            SoftUniCloneContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var courses = this.context.Courses.ToList();
            var model = this.mapper.Map<IEnumerable<CourseConciseViewModel>>(courses);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CourseCreationBindingModel model)
        {
            //check if the model is valid
            if (!ModelState.IsValid)
            {
                return View();
            }

            //we map CourseCreationBindingModel class to the Course class by using the automapper and save it to the DB
            var course = this.mapper.Map<Course>(model);
            this.context.Courses.Add(course);
            context.SaveChanges();

            //we save a message 
           this.TempData["__Message"] = new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Course created successfully."
            };

            //redirect to Details page
            return RedirectToAction("Details", new { id = course.Id });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            // TODO: Add lecturer
            var course = this.context.Courses
                .Include(c => c.Instances)
                .FirstOrDefault(c => c.Id == id);
            var model = this.mapper.Map<CourseDetailsViewModel>(course);
            return View(model);
        }
    }
}