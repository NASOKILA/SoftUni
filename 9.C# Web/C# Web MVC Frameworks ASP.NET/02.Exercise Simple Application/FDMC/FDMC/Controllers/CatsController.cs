
namespace FDMC.Controllers
{
    using FDMC.BindingModels;
    using FDMC.Data;
    using FDMC.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class CatsController : Controller
    {
        public FdmcContext Context { get; private set; }

        public CatsController()
        {
            this.Context = new FdmcContext();
        }

        public IActionResult Index() {

            List<Cat> cats = this.Context.Cats.ToList();
               
            return View(model:cats);
        }

        [HttpGet]
        public IActionResult Add() {
            
            return View();
        }

        [HttpPost]
        public IActionResult Add(CatBindingModel catBindingModel)
        {

            if (catBindingModel.Name == "" || catBindingModel.Name == null) {
                this.ViewData["message"] = "Name cannot be null or empty string!";
                return this.View();
            }
            else if (catBindingModel.Breed == "" || catBindingModel.Breed == null)
            {
                this.ViewData["message"] = "Breed cannot be null or empty string!";
                return this.View();
            }
            else if (catBindingModel.Age < 0 || catBindingModel.Age.ToString() == "") {
                this.ViewData["message"] = "Age cannot be less than 0!";
                return this.View();
            }
            else if (catBindingModel.ImageUrl == "" || catBindingModel.ImageUrl == null)
            {
                this.ViewData["message"] = "Image cannot be null or empty string!";
                return this.View();
            }

            Cat newCat = new Cat()
            {
                Name = catBindingModel.Name,
                Age = catBindingModel.Age,
                Breed = catBindingModel.Breed,
                ImageUrl = catBindingModel.ImageUrl
            };

            this.Context.Cats.Add(newCat);

            this.Context.SaveChanges();

            return this.RedirectToAction("Details", new { id = newCat.Id});
        }

        public IActionResult Details() {

            var id = int.Parse(this.Request.Path.Value.Split("/").Last());

            Cat cat = this.Context.Cats.Find(id);

            //we hass the CatBindingModel to the view because it does not need the Id
            var catModel = new CatBindingModel() {
                Age = cat.Age,
                Name = cat.Name,
                Breed = cat.Breed,
                ImageUrl = cat.ImageUrl
            }; 

            return View(model:catModel);
        }
    }
}











