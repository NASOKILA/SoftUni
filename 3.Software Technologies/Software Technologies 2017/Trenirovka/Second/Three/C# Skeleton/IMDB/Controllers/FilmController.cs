using System.Linq;
using System.Net;
using System.Web.Mvc;
using IMDB.Models;
using System.Collections.Generic;

namespace IMDB.Controllers
{
    [ValidateInput(false)]
    public class FilmController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            // Otvarqme si bazovo prozorche sus using
            using (var db = new IMDBDbContext())
            {

                // vzimame vsichki filmi ot bazata
                List<Film> films = db.Films.ToList();

                // po davam gi na viewto kato spisuk zashtoto taka ochakva viewto
                return View(films);

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
        public ActionResult Create(Film film)
        {
            if (ModelState.IsValid)
            {
                
                using (var db = new IMDBDbContext())
                {
                    db.Films.Add(film);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

            }

            // AKO NESHTO NE E NARED OSTAVQME NA TAZI STRANICA
            return View();
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            using (var db = new IMDBDbContext())
            {
                Film film = db.Films.Find(id);

                if (film != null) // AKO NE E NULEVO
                {
                    return View(film);
                }

            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Film filmModel)
        {
            using (var db = new IMDBDbContext())
            {

                if (filmModel.Name == null || filmModel.Genre == null || filmModel.Director == null
                    || filmModel.Year == 0)
                {
                    return RedirectToAction("Edit");
                }

                Film film = db.Films.Find(id);

                if (!ModelState.IsValid)
                {
                    return View(film);
                }

                film.Name = filmModel.Name;
                film.Genre = filmModel.Genre;
                film.Director = filmModel.Director;
                film.Year = filmModel.Year;

                db.SaveChanges();

                return Redirect("/");
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            using (var db = new IMDBDbContext())
            {
                Film film = db.Films.Find(id);

                if (film != null) // AKO NE E NULEVO
                {
                    return View(film);
                }

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Film filmModel)
        {
            using (var db = new IMDBDbContext())
            {

                Film film = db.Films.Find(id);

                if (film == null)
                {
                    return Redirect("/");
                }

                db.Films.Remove(film);
                db.SaveChanges();

                return Redirect("/");
            }
        }
    }
}