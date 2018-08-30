using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FindMyPet.Data;
using FindMyPet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindMyPet.Web.Views.Pages.Pets
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Type is required.")]
        [MinLength(3, ErrorMessage = "Type must be atleast 3 symbols.")]
        public string Type { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be atleast 3 symbols.")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Age is required.")]
        [Range(0, 100, ErrorMessage = "Age must be in range between 0 and 100.")]
        public int Age { get; set; }

        [BindProperty]
        [DataType(DataType.Url)]
        [Required(ErrorMessage = "Image Url is required.")]
        public string ImageUrl { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Location is required.")]
        [MinLength(3, ErrorMessage = "Location must be atleast 3 symbols.")]
        public string LocationLost { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Time Lost is required.")]
        public DateTime TimeLost { get; set; }

        [BindProperty]
        public DateTime TimeFound { get; set; }
        
        [BindProperty]
        public string Gender { get; set; }
        
        [BindProperty]
        public string Breed { get; set; }
        
        [BindProperty]
        public string Color { get; set; }

        
        public IActionResult OnGet()
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


            //USER
            if (!this.User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }


            ViewData["petExists"] = false;
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

                isAdmin = this.User.Claims.Any(c => c.Value == "Admin");
            }

            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();

            if (!this.User.Identity.IsAuthenticated)
                return Redirect("/Identity/Account/Login");


            if (!ModelState.IsValid){
                ViewData["petExists"] = false;
                return Page();
            }



            using (var context = new FindMyPetDbContext())
            {
                var petsExists = context.Pets.Any(p => p.Name == this.Name && p.Type == this.Type && p.ImageUrl == this.ImageUrl);

                if (petsExists)
                {
                    ViewData["petExists"] = true;
                    return Page();
                }

                ViewData["petExists"] = false;

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
                    Status = "Lost",
                    Comments = new List<Comment>(),
                    OwnerId = currentUser.Id
                };

                context.Pets.Add(pet);
                context.SaveChanges();
                
                return RedirectToAction("Details", "Pets", new { Id = pet.Id });
            }
        }
    }
}