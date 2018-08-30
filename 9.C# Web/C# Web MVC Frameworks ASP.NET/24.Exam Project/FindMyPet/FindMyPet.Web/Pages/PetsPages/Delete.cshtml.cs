using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FindMyPet.Data;
using FindMyPet.Models;
using FindMyPet.Web.Models.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindMyPet.Web.Pages.PetsPages
{
    public class DeleteModel : PageModel
    {

        public int Id { get; set; }

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
        public int? Age { get; set; }

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


        public IActionResult OnGet(int id)
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

            if (!this.User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
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
                    return RedirectToAction("All", "Pets");

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
                isAdmin = currentUser.Claims.Any(c => c.Value == "Admin");
            }

            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();

            if (!this.User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            using (var context = new FindMyPetDbContext())
            {
                Pet pet = context.Pets.FirstOrDefault(p => p.Id == id);

                if (pet == null)
                    return RedirectToAction("All", "Pets");

                context.Pets.Remove(pet);
                context.SaveChanges();

                return RedirectToAction("All", "Pets");
            }
        }
    }
}