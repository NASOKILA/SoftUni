using System;
using System.Linq;
using FindMyPet.Data;
using FindMyPet.Models;
using FindMyPet.Web.Models.BindingModels;
using FindMyPet.Web.Static;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FindMyPet.Web.Pages.PetsPages
{
    public class DeleteModel : PageModel
    {

        public int Id { get; set; }

        [BindProperty]
        public string Type { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public int? Age { get; set; }

        [BindProperty]
        public string ImageUrl { get; set; }

        [BindProperty]
        public string LocationLost { get; set; }

        [BindProperty]
        public DateTime TimeLost { get; set; }

        [BindProperty]
        public DateTime TimeFound { get; set; }

        [BindProperty]
        public string Gender { get; set; }

        [BindProperty]
        public string Breed { get; set; }

        [BindProperty]
        public string Color { get; set; }


        public IActionResult OnGet(int id)
        {
            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                isLoggedIn = true;
                isAdmin = currentUser.Claims.Any(c => c.Value == StaticConstants.AdminRole);
            }

            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

            if (!this.User.Identity.IsAuthenticated)
            {
                return Redirect(StaticConstants.LoginRedirect);
            }
            

            using (var context = new FindMyPetDbContext())
            {
                CreatePetBindingModel pet = context.Pets
                    .Select(p => new CreatePetBindingModel()
                    {
                        Id = p.Id,
                        Type = p.Type,
                        Name = p.Name,
                        Age = p.Age,
                        ImageUrl = p.ImageUrl,
                        LocationLost = p.LocationLost,
                        TimeLost = p.TimeLost,
                        Gender = p.Gender,
                        Breed = p.Breed,
                        Color = p.Color,
                    })
                    .FirstOrDefault(p => p.Id == id);

                if (pet == null)
                    return RedirectToAction(StaticConstants.All, StaticConstants.Pets);

                this.Id = pet.Id;
                this.Type = pet.Type;
                this.Name = pet.Name;
                this.Age = pet.Age;
                this.ImageUrl = pet.ImageUrl;
                this.LocationLost = pet.LocationLost;
                this.TimeLost = pet.TimeLost;
                this.Gender = pet.Gender;
                this.Breed = pet.Breed;
                this.Color = pet.Color;
            }

            return Page();
        }


        public IActionResult OnPost(int id)
        {

            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                isLoggedIn = true;
                isAdmin = currentUser.Claims.Any(c => c.Value == StaticConstants.AdminRole);
            }

            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

            if (!this.User.Identity.IsAuthenticated)
            {
                return Redirect(StaticConstants.LoginRedirect);
            }

            using (var context = new FindMyPetDbContext())
            {
                Pet pet = context.Pets
                    .Include(p => p.Comments)
                    .ThenInclude(c => c.Likes)
                    .FirstOrDefault(p => p.Id == id);


                foreach (Comment comm in pet.Comments)
                {

                    foreach (Like like in comm.Likes)
                    {
                        context.Likes.Remove(like);
                    }
                    context.SaveChanges();

                    context.Comments.Remove(comm);
                }

                context.SaveChanges();

                if (pet == null)
                    return RedirectToAction(StaticConstants.All, StaticConstants.Pets);

                context.Pets.Remove(pet);
                context.SaveChanges();

                return RedirectToAction(StaticConstants.All, StaticConstants.Pets);
            }
        }
    }
}