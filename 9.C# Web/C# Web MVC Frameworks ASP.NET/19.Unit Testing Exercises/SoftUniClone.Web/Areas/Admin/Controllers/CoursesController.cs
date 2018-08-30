using Microsoft.AspNetCore.Mvc;
using SoftUniClone.Common.Admin.BindingModels;
using SoftUniClone.Services.Admin.Interfaces;
using SoftUniClone.Web.Helpers.Messages;
using System.Threading.Tasks;

namespace SoftUniClone.Web.Areas.Admin.Controllers
{
    public class CoursesController : AdminController
    {
        private readonly IAdminCoursesService coursesService;

        public CoursesController(
            IAdminCoursesService coursesService)
        {
            this.coursesService = coursesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var courses = await this.coursesService.GetCoursesAsync();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreationBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await this.coursesService.AddCourseAsync(model);

            this.TempData["__Message"] = new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Course created successfully."
            };

            return RedirectToAction("Details");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await this.coursesService.GetCourseDetailsAsync(id);
            return View(model);
        }
    }
}