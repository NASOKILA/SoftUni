using FindMyPet.Data;
using FindMyPet.Models;
using FindMyPet.Web.Models.BindingModels;
using FindMyPet.Web.Models.ViewModels;
using FindMyPet.Web.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindMyPet.Web.Controllers
{

    [Authorize]
    public class PetsController : Controller
    {
        [BindProperty]
        public List<Comment> CommentsForPetDetails { get; set; }

        private const int fifty = 50;
        private const int oneHundred = 100;
        private const int twoHundred = 200;
        private const int threeHundred = 300;

        private const int DefaultPage = 1;
        private const int DefaultResultsPerPage = 3;

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
        public IActionResult All(int? page, int? count)
        {
            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                isLoggedIn = true;

                isAdmin = currentUser.Claims.Any(c => c.Value == StaticConstants.AdminRole);

                if (isAdmin == true)
                {
                    return new RedirectToActionResult(StaticConstants.Index, StaticConstants.Home, new { @area = StaticConstants.AdminRole });
                }
            }

            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();
            

            if (!page.HasValue)
                page = DefaultPage;


            if (!count.HasValue)
                count = DefaultResultsPerPage;
            
            if (page < 1)
                page = DefaultPage;


            if (count < 1)
                count = DefaultResultsPerPage;


            var allPets = context.Pets.ToList();
            if (allPets.Count < 4)
            {
                ViewData["allPetsLessThanThree"] = "True";
            }
            else
            {
                ViewData["allPetsLessThanThree"] = "False";
            }

            List<ListPetsBindingModel> pets = this.context.Pets
                .Include(p => p.Owner)
                .Include(p => p.Founder)
                .OrderByDescending(a => a.Status)
                .ThenBy(a => a.TimeLost)
                .Skip((page.Value - DefaultPage) * count.Value)
                .Take(count.Value)
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
                .ToList();


            if (pets.Count == 0)
            {
                page = (allPets.Count % DefaultResultsPerPage) + DefaultResultsPerPage;

                if (allPets.Count < 4)
                {
                    page = 1;
                }
                else if (allPets.Count < 7)
                {
                    page = 2;
                }

                return new RedirectToActionResult(StaticConstants.All, StaticConstants.Pets, new { @area = StaticConstants.Empty, @page = page });
            }

            PaginationViewModel pagination = new PaginationViewModel()
            {
                Page = page.Value,
                Count = count.Value,
                Pets = pets
            };

            return View(pagination);
        }
        
        [HttpGet]
        public IActionResult Previous(int page)
        {
            page = page - DefaultPage;
            return new RedirectToActionResult(StaticConstants.All, StaticConstants.Pets, new { @area = StaticConstants.Empty, @page = page });
        }
        
        [HttpGet]
        public IActionResult Next(int page)
        {
            page = page + DefaultPage;
            return new RedirectToActionResult(StaticConstants.All, StaticConstants.Pets, new { @area = StaticConstants.Empty, @page = page });
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

            foreach (var currentComment in pet.Comments) {

                int likesCountByUserForCurrentComment = currentComment.Likes.Where(l => l.Creator.Email == this.User.Identity.Name).Count();

                if (likesCountByUserForCurrentComment > 0)
                    currentComment.LikeDisabled = true;
                else
                    currentComment.LikeDisabled = false;
            }
            
            this.CommentsForPetDetails = pet.Comments.ToList();
            ViewBag.Comments = CommentsForPetDetails;
            ViewData["CurrentUserId"] = context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name).Id;
            ViewData[StaticConstants.CurrentId] = id;

            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                isLoggedIn = true;

                isAdmin = currentUser.Claims.Any(c => c.Value == StaticConstants.AdminRole);

                if (isAdmin == true)
                {
                    return new RedirectToActionResult(StaticConstants.Index, StaticConstants.Home, new { @area = StaticConstants.AdminRole });
                }
            }

            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

            return View(pet);
        }

        [HttpGet]
        public void AddCommentToPet(int id, string Description)
        {
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
        }

        [HttpGet]
        public void RemoveCommentFromPet(int petId, int commentId) {

            Comment comment = this.context.Comments
                .Include(c => c.Likes)
                .FirstOrDefault(c => c.Id == commentId);

            foreach (Like like in comment.Likes)
            {
                this.context.Likes.Remove(like);
            }

            this.context.Comments.Remove(comment);
            this.context.SaveChanges();
        }

        [HttpGet]
        public IActionResult PetFound(int id)
        {
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
                return RedirectToAction(StaticConstants.All, StaticConstants.Pets, new { Id = id });

            return View(petFoundBindingModel);
        }

        [HttpPost]
        public IActionResult PetFoundPost(int id)
        {
            Pet pet = context.Pets
                .Include(p => p.Owner).FirstOrDefault(p => p.Id == id);

            User currentUser = this.context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name);
            
            if (pet.Status == StaticConstants.Found)
            {
                return RedirectToAction(StaticConstants.All, StaticConstants.Pets);
            }

            string content = "Your pet " + pet.Name + " was found by " + this.User.Identity.Name + " at " + DateTime.Now + ".";
            
            Message foundMessage = new Message()
            {
                CreationDate = DateTime.Now,
                Content = content,
                LikeDisabled = false,
                Likes = new List<Like>(),
                ReceverId = pet.Owner.Id,
                SenderId = currentUser.Id
            };

            string contentForFounder = "You found pet " + pet.Name + " of type " + pet.Type + " on " + DateTime.Now + ".";

            Message foundMessageForFounder = new Message()
            {
                CreationDate = DateTime.Now,
                Content = contentForFounder,
                LikeDisabled = false,
                Likes = new List<Like>(),
                ReceverId = currentUser.Id,
                SenderId = currentUser.Id
            };

            this.context.Messages.Add(foundMessageForFounder);
            this.context.Messages.Add(foundMessage);
            this.context.SaveChanges();

            pet.Status = StaticConstants.Found;
            pet.TimeFound = DateTime.Now;
            context.Pets.Update(pet);
            context.SaveChanges();

            if (pet == null)
                return RedirectToAction(StaticConstants.All, StaticConstants.Pets, new { Id = id });
            
            currentUser.PetsFound.Add(pet);
            
            switch (pet.Type)
            {
                case StaticConstants.Other:
                    currentUser.FeedBack = currentUser.FeedBack + fifty;
                    break;
                case StaticConstants.Dog:
                    currentUser.FeedBack = currentUser.FeedBack + oneHundred;
                    break;
                case StaticConstants.Cat:
                    currentUser.FeedBack = currentUser.FeedBack + twoHundred;
                    break;
                case StaticConstants.Bird:
                    currentUser.FeedBack = currentUser.FeedBack + threeHundred;
                    break;
                default:
                    break;
            }
            
            currentUser.PetsFound.Add(pet);
            context.Users.Update(currentUser);
            context.SaveChanges();
            
            return View(StaticConstants.PetFoundCompleted);
        }
    }
}
