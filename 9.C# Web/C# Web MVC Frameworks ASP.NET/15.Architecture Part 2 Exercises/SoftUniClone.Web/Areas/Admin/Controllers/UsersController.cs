using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftUniClone.Common.Admin.ViewModels;
using SoftUniClone.Data;
using SoftUniClone.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUniClone.Web.Areas.Admin.Controllers
{
    public class UsersController : AdminController
    {
        private readonly SoftUniCloneContext context;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public UsersController(
            SoftUniCloneContext context,
            IMapper mapper,
            UserManager<User> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);
            var users = this.context.Users
                .Where(u => u.Id != currentUser.Id)
                .ToList();

            // TODO: Fill in "Is lecturer" -> whether user is in role "Lecturer"?
            // TODO: Is admin
            // If lecturer -> hide button "Make lecturer"
            // If administrator -> only "Details"
            var model = this.mapper.Map<IEnumerable<UserConciseViewModel>>(users);
            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            // TODO: If administrator -> disable editing
            var currentUser = await this.userManager.GetUserAsync(this.User);
            if (id == currentUser.Id)
            {
                return Unauthorized();
            }

            var user = await this.context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await this.userManager.GetRolesAsync(user);
            var model = this.mapper.Map<UserDetailsViewModel>(user);
            model.Roles = roles;
            return View(model);
        }
    }
}