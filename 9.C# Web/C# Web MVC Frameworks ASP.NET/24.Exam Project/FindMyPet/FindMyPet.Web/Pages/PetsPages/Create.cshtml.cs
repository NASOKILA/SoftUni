using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FindMyPet.Data;
using FindMyPet.Models;
using FindMyPet.Web.Static;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindMyPet.Web.Views.Pages.Pets
{
    public class CreateModel : PageModel
    {

        public FindMyPetDbContext context { get; set; }

        public CreateModel(FindMyPetDbContext context)
        {
            this.context = context;
        }


        private const int zero = 0;
        private const int three = 3;
        private const int oneHundred = 100;

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
        public int Age { get; set; }

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

        [HttpGet]
        public IActionResult OnGet()
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
            
            ViewData[StaticConstants.PetExists] = false;
            return Page();
        }
        
        [HttpPost]
        public IActionResult OnPost()
        {
            bool isLoggedIn = false;
            bool isAdmin = false;
            
            if (this.User.Identity.IsAuthenticated)
            {
                isLoggedIn = true;

                isAdmin = this.User.Claims.Any(c => c.Value == StaticConstants.AdminRole);
            }

            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

            if (!this.User.Identity.IsAuthenticated)
                return Redirect(StaticConstants.LoginRedirect);
            
            if (!ModelState.IsValid){
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

                var allUsers = context.Users.ToList();

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