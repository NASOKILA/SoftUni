using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FindMyPet.Data;
using FindMyPet.Models;
using FindMyPet.Web.Models.BindingModels;
using FindMyPet.Web.Static;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindMyPet.Web.Pages.PetsPages
{
    public class EditModel : PageModel
    {

        public FindMyPetDbContext context { get; set; }

        public EditModel(FindMyPetDbContext context)
        {
            this.context = context;
        }


        private const int zero = 0;
        private const int three = 3;
        private const int oneHundred = 100;

        public int Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = ValidationConstants.TypeRequired)]
        [MinLength(three, ErrorMessage = ValidationConstants.TypeAtleastThreeSymbols)]
        public string Type { get; set; }

        [BindProperty]
        [Required(ErrorMessage = ValidationConstants.NameRequired)]
        [MinLength(three, ErrorMessage = ValidationConstants.NameAtleastThreeSymbols)]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = ValidationConstants.AgeRequired)]
        [Range(zero, oneHundred, ErrorMessage = ValidationConstants.AgeRangeBetweenZeroAndOnehundred)]
        public int? Age { get; set; }

        [BindProperty]
        [DataType(DataType.Url)]
        [Required(ErrorMessage = ValidationConstants.ImageUrlRequired)]
        public string ImageUrl { get; set; }

        [BindProperty]
        [Required(ErrorMessage = ValidationConstants.LocationRequired)]
        [MinLength(three, ErrorMessage = ValidationConstants.LocationAtleastThreeSymbols)]
        public string LocationLost { get; set; }

        [BindProperty]
        [Required(ErrorMessage = ValidationConstants.TimeLostRequired)]
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

            ViewData[StaticConstants.PetExists] = false;

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

            if (!ModelState.IsValid)
            {
                ViewData[StaticConstants.PetExists] = false;
                return Page();
            }

            var petsExists = context.Pets.Any(p => p.Name == this.Name && p.Type == this.Type && p.ImageUrl == this.ImageUrl);

            if (petsExists)
            {
                ViewData[StaticConstants.PetExists] = true;
                return Page();
            }

            ViewData[StaticConstants.PetExists] = false;

            Pet pet = context.Pets.FirstOrDefault(p => p.Id == id);

                if (pet == null)
                    return RedirectToAction(StaticConstants.All, StaticConstants.Pets);

                pet.Type = this.Type;
                pet.Name = this.Name;
                pet.Age = this.Age;
                pet.ImageUrl = this.ImageUrl;
                pet.LocationLost = this.LocationLost;
                pet.TimeLost = this.TimeLost;
                pet.Gender = this.Gender;
                pet.Breed = this.Breed;
                pet.Color = this.Color;
                
                context.Pets.Update(pet);
                context.SaveChanges();
                
                return RedirectToAction(StaticConstants.Details, StaticConstants.Pets, new { Id = pet.Id });
            
        }
    }
}