using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FindMyPet.Data;
using FindMyPet.Models;
using FindMyPet.Web.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindMyPet.Web.Admin.Pages.Pets
{

    [Area(StaticConstants.AdminRole)]
    [Authorize(Roles = StaticConstants.AdminRole)]
    public class CreateModel : PageModel
    {
        private const int numberZero = 0;
        private const int numberThree = 3;
        private const int numberOnehundred = 100;

        [BindProperty]
        [Required(ErrorMessage = ValidationConstants.TypeRequired)]
        [MinLength(numberThree, ErrorMessage = ValidationConstants.TypeAtleastThreeSymbols)]
        public string Type { get; set; }

        [BindProperty]
        [Required(ErrorMessage = ValidationConstants.NameRequired)]
        [MinLength(numberThree, ErrorMessage = ValidationConstants.NameAtleastThreeSymbols)]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = ValidationConstants.AgeRequired)]
        [Range(numberZero, numberOnehundred, ErrorMessage = ValidationConstants.AgeRangeBetweenZeroAndOnehundred)]
        public int Age { get; set; }

        [BindProperty]
        [DataType(DataType.Url)]
        [Required(ErrorMessage = ValidationConstants.ImageUrlRequired)]
        public string ImageUrl { get; set; }

        [BindProperty]
        [Required(ErrorMessage = ValidationConstants.LocationRequired)]
        [MinLength(numberThree, ErrorMessage = ValidationConstants.LocationAtleastThreeSymbols)]
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

        [HttpGet]
        public IActionResult OnGet()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Redirect(StaticConstants.LoginRedirect);
            }

            ViewData[StaticConstants.PetExists] = false;
            return Page();
        }


        [HttpPost]
        public IActionResult OnPost()
        {
            if (!this.User.Identity.IsAuthenticated)
                return Redirect(StaticConstants.LoginRedirect);


            if (!ModelState.IsValid) {

                ViewData[StaticConstants.PetExists] = false;
                return Page();
            }


            using (var context = new FindMyPetDbContext())
            {
                var petsExists = context.Pets.Any(p => p.Name == this.Name && p.Type == this.Type && p.ImageUrl == this.ImageUrl);

                if (petsExists)
                {
                    ViewData[StaticConstants.PetExists] = true;
                    return Page();
                }

                ViewData[StaticConstants.PetExists] = false;

                User currentUser = context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name);

                Pet pet = new Pet()
                {
                    Type = this.Type,
                    Name = this.Name,
                    Age = this.Age,
                    ImageUrl = this.ImageUrl,
                    LocationLost = this.LocationLost,
                    TimeLost = this.TimeLost,
                    TimeFound = this.TimeFound,
                    Gender = this.Gender,
                    Breed = this.Breed,
                    Color = this.Color,
                    Status = StaticConstants.Lost,
                    Comments = new List<Comment>(),
                    OwnerId = currentUser.Id
                };

                context.Pets.Add(pet);
                context.SaveChanges();
                
                return RedirectToAction(StaticConstants.Details, StaticConstants.Pets, new { Id = pet.Id });
            }
        }
    }
}