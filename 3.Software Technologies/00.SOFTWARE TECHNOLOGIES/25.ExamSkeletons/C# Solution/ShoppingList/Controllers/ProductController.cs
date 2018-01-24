using System.Linq;
using System.Web.Mvc;
using ShoppingList.Models;
using System.Collections.Generic;

namespace ShoppingList.Controllers
{
    [ValidateInput(false)]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new ShoppingListDbContext())
            {
                List<Product> products = db.Products.ToList();
                return View(products);

            }

        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            using (var db = new ShoppingListDbContext())
            {
                if(ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            using (var db = new ShoppingListDbContext())
            {
                Product product = db.Products.Find(id);

                if (product == null)
                {
                    return RedirectToAction("Index");
                }

                return View(product);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Product productModel)
        {
            using (var db = new ShoppingListDbContext())
            {
                if (ModelState.IsValid)
                {
                    Product product = db.Products.Find(id);

                    product.Name = productModel.Name;
                    product.Priority = productModel.Priority;
                    product.Quantity = productModel.Quantity;
                    product.Status = productModel.Status;

                    db.SaveChanges();

                    return Redirect("/");
                }

                return RedirectToAction("Index");
            }
            
        }
    }
}