using Blog.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: Article
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        //
        // GET: Article/List
        public ActionResult List()
        {
            using (var database = new BlogDbContext())
            {
                var articles = database.Articles
                    .Include(a => a.Author)
                    .ToList();

                return View(articles);
            }
        }

        //
        // GET: Article/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                var article = database.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();

                if (article == null)
                {
                    return HttpNotFound();
                }

                return View(article);
            }
        }





        [Authorize]
        [HttpGet]
        public ActionResult Delete(int? id) {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                // get article from database
                var article = database.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .FirstOrDefault();


                // WE CHECK IF THE DELETE REQUESTS ARE VALID
                if (!IsUserAuthorizedToEdit(article))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }



                // check if article exists
                if (article == null)
                {
                    return HttpNotFound();
                }

                //pass article to view
                return View(article);

            }
            

        }



        [Authorize]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using(var database = new BlogDbContext())
            {
                // get article from database
                var article = database.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .FirstOrDefault();

                // check if the article exists
                if(article == null)
                {
                    return HttpNotFound();
                }

                // delete the article from database
                database.Articles.Remove(article);
                database.SaveChanges();


                
            }

            // redirect to action index
                return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id) {

            using(var database = new BlogDbContext()) {

                // get the article
                var article = database.Articles
                    .Where(a => a.Id == id)
                    .FirstOrDefault();


                // WE CHECK IF THE EDIT REQUESTS ARE VALID
                if (!IsUserAuthorizedToEdit(article)) {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }


                // check if it exists
                if (article == null)
                {
                    return HttpNotFound();
                }


                //create the model
                var model = new ArticleViewModel();
                model.Id = article.Id;
                model.Title = article.Title;
                model.Content = article.Content;

                // pass to the viewModel to the View
                return View(model);
            }
            
        }

        [Authorize]
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(ArticleViewModel model) {

            if(ModelState.IsValid) {
                // ako tozi model e validen

                using (var database = new BlogDbContext()) {

                    //get article from databse
                    var article = database.Articles
                        .Where(a => a.Id == model.Id)
                        .FirstOrDefault();

                    //set articles properties
                    article.Title = model.Title;
                    article.Content = model.Content;

                    //save article state in database
                    database.Entry(article).State = EntityState.Modified;
                    database.SaveChanges();

                    //redirect to the index page
                    return RedirectToAction("Index");
                }

            }
            //If it is invalid, return the same view
            return View();
        }



        // GET: Article/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: Article/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Article article, HttpPostedFileBase image)
        {// OCHAKVA SE I FAIL KOITO SHTE SE KAZVA IMAGE, TRQBVA IMENATA DA SUVPADAT S TOVA VUV VIUTO
            if (ModelState.IsValid)
            {
                using (var database = new BlogDbContext())
                {
                    var authorId = database.Users
                        .Where(u => u.UserName == this.User.Identity.Name)
                        .First()
                        .Id;

                    article.AuthorId = authorId;

                    if(image != null) {

                        var allowedContentTypes = new[] { "image/jpg", "image/jpeg", "image/png" };

                        if(allowedContentTypes.Contains(image.ContentType)) {
                            var imagesPath = "/Content/Images/";
                            var fileName = image.FileName;

                            var uploadPath = imagesPath + fileName;
                            
                            var physicalPath = Server.MapPath(uploadPath);
                            // Sus Server.MapPath() nie mu kazvame che moje avtomatichno a vliza v nashiq proekt
                            // inache shte trqbva da pishe mceliq put C/Desctop/....
                            

                            // trqbva da zapishem snimkata vuv survera !!!
                            image.SaveAs(physicalPath);


                            // sega samo trqbva da setnem samiq imagePath na artikula
                            article.ImagePath = uploadPath;


                        }
                        
                    }

                    database.Articles.Add(article);
                    database.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(article);
        }


        private bool IsUserAuthorizedToEdit(Article article) {
            //podavame mu artikula
            bool isAdmin = this.User.IsInRole("Admin"); // proverqvame dali e admin
            bool isAuthor = article.IsAuthor(this.User.Identity.Name); // dali e avtora na artikula

            return isAdmin || isAuthor;
        }

    }
}