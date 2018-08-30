using FindMyPet.Data;
using FindMyPet.Models;
using FindMyPet.Web.Models.BindingModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyPet.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PetsController : Controller
    {
        [BindProperty]
        public List<Comment> CommentsForPetDetails { get; set; }
        

        private readonly UserManager<User> userManager;
        private readonly FindMyPetDbContext context;

        public PetsController(
            UserManager<User> userManager,
            FindMyPetDbContext context)
        {   
            this.userManager = userManager;
            this.context = context;
        }

        [HttpGet]
        public IActionResult All()
        {
            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                isLoggedIn = true;
                isAdmin = currentUser.Claims.Any(c => c.Value == "Admin");
            }
            
            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();
            
            List<ListPetsBindingModel> pets = this.context.Pets
                .Select(p => new ListPetsBindingModel()
                {
                    Id = p.Id,
                    Age = p.Age,
                    ImageUrl = p.ImageUrl,
                    LocationLost = p.LocationLost,
                    Name = p.Name,
                    Type = p.Type,
                    TimeLost = p.TimeLost,
                    TimeFound = p.TimeFound,
                    Status = p.Status,
                    OwnerId = p.OwnerId,
                    Owner = p.Owner,
                    Founder = p.Founder,
                    FounderId = p.FounderId
                })
                .Include(p => p.Owner)
                .Include(p => p.Founder)
                .OrderByDescending(a => a.Status)
                .ThenByDescending(a => a.TimeLost)
                .ToList();


            return View(pets);

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            
            Pet pet = this.context.Pets
                .Include(p => p.Owner)
                .Include(p => p.Founder)
                .Include(p => p.Comments)
                .ThenInclude(c => c.Creator)
                .Include(p => p.Comments)
                .ThenInclude(c => c.Likes)
                .ThenInclude(l => l.Creator)
                .FirstOrDefault(p => p.Id == id);
            
            var allLikes = context.Likes
                .Include(l => l.Creator)
                .ToList();

            foreach(var currentComment in pet.Comments) {
                
                int likesCountByUserForCurrentComment = currentComment.Likes.Where(l => l.Creator.Email == this.User.Identity.Name).Count();
                if (likesCountByUserForCurrentComment > 0)
                    currentComment.LikeDisabled = true;
                else
                    currentComment.LikeDisabled = false;
            }


            this.CommentsForPetDetails = pet.Comments.ToList();
            ViewBag.Comments = CommentsForPetDetails;
            ViewData["CurrentId"] = id;


            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                isLoggedIn = true;

                isAdmin = currentUser.Claims.Any(c => c.Value == "Admin");
            }

            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();

            return View(pet);
        }
        
        [HttpPost]
        public IActionResult AddCommentToPet(int id, string Description)
        {

            bool isLoggedIn = false;
            bool isAdmin = false;
            
            if (this.User.Identity.IsAuthenticated)
            {
                isLoggedIn = true;

                isAdmin = this.User.Claims.Any(c => c.Value == "Admin");
            }

            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();


            int petId = id;

            var currentUser = context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name);

            Comment comment = new Comment()
            {
                Content = Description,
                CreationDate = DateTime.Now,
                CreatorId = currentUser.Id,
                LikeDisabled = false,
                Likes = new List<Like>(),
                PetId = petId,
            };

            this.context.Comments.Add(comment);

            this.context.SaveChanges();

            return RedirectToAction("Details", "Pets", new { Id = petId });
        }

        [HttpGet]
        public IActionResult RemoveCommentFromPet(int petId, int commentId) {

            bool isLoggedIn = false;
            bool isAdmin = false;

            if (this.User.Identity.IsAuthenticated)
            {
                isLoggedIn = true;

                isAdmin = this.User.Claims.Any(c => c.Value == "Admin");
            }

            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();


            Comment comment = this.context.Comments
                .Include(c => c.Likes)
                .FirstOrDefault(c => c.Id == commentId);

            foreach (Like like in comment.Likes)
            {
                this.context.Likes.Remove(like);
            }
            this.context.SaveChanges();


            this.context.Comments.Remove(comment);
            this.context.SaveChanges();

            return RedirectToAction("Details", "Pets", new { Id = petId });
        }

        [HttpGet]
        public IActionResult PetFound(int id)
        {

            bool isLoggedIn = false;
            bool isAdmin = false;

            if (this.User.Identity.IsAuthenticated)
            {
                isLoggedIn = true;

                isAdmin = this.User.Claims.Any(c => c.Value == "Admin");
            }

            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();

            PetFoundBindingModel petFoundBindingModel = context.Pets.Select(p => new PetFoundBindingModel()
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                LocationLost = p.LocationLost,
                Name = p.Name,
                TimeLost = p.TimeLost,
                Type = p.Type

            }).FirstOrDefault(p => p.Id == id);

            if (petFoundBindingModel == null)
                return RedirectToAction("All", "Pets", new { Id = id });
            
            return View(petFoundBindingModel);
        }
         
        [HttpPost]
        public IActionResult PetFoundPost(int id)
        {

            bool isLoggedIn = false;
            bool isAdmin = false;

            if (this.User.Identity.IsAuthenticated)
            {
                isLoggedIn = true;

                isAdmin = this.User.Claims.Any(c => c.Value == "Admin");
            }

            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();

            Pet pet = context.Pets.Find(id);

            if (pet.Status == "Found")
            {
                return RedirectToAction("All", "Pets");
            }

            pet.Status = "Found";
            pet.TimeFound = DateTime.Now;
            context.Pets.Update(pet);
            context.SaveChanges();

            if (pet == null)
                return RedirectToAction("All", "Pets", new { Id = id });

            var currentUser = context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name);

            currentUser.PetsFound.Add(pet);
            
            switch (pet.Type)
            {
                case "Dog":
                    currentUser.FeedBack = currentUser.FeedBack + 100;
                    break;
                case "Cat":
                    currentUser.FeedBack = currentUser.FeedBack + 200;
                    break;
                case "Bird":
                    currentUser.FeedBack = currentUser.FeedBack + 300;
                    break;
                default:
                    break;
            }
            

            currentUser.PetsFound.Add(pet);
            context.Users.Update(currentUser);
            context.SaveChanges();



            return View("PetFoundCompleted");
        }
    }
}
