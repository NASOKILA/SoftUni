using System.Linq;
using System.Net;
using System.Web.Mvc;
using IMDB.Models;
using System.Collections.Generic;

namespace IMDB.Controllers
{
    [ValidateInput(false)]
    public class EventController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            // Otvarqme si bazovo prozorche sus using
            using (var db = new IMDBDbContext())
            {

                // vzimame vsichki eventi ot bazata
                List<Event> events = db.Events.ToList();

                // podavam gi na viewto kato spisuk zashtoto taka gi ochakva 
                return View(events);
            }
        }


        //SUZDAVANE NA EVENTI

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            // prosto vushtame create viewto
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event currentEvent)
        {
            //TUK VALIDIRAME
            // Ako populnenoto e validno
            if (ModelState.IsValid)
            {
                //PROVERQVAME DALI DATATA NA STARTIRANE E PO MALKA OT TAZI NA ZAVURSHAVNE NA EVENTA.
                //INACHE NQMA MNOGO SMISUL.
                if (currentEvent.StartDateAndTime < currentEvent.EndDateAndTime)
                {
                    using (var db = new IMDBDbContext())
                    {
                        //dobavqme eventa i zapazvame promenite v bazata
                        db.Events.Add(currentEvent);
                        db.SaveChanges();

                        // redirktvame kum index
                        return RedirectToAction("Index");
                    }
                }
            }

            return View(); // Ako populnenoto ne e validno ostavqme na sushtata stranica !
            
        }



        //UPDEITVANE NA EVENTI

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            
            // Ako ni podadat id koeto e null vrushtame greshka
            if (id == null)
            {
                return HttpNotFound();
            }


            using (var db = new IMDBDbContext())
            {

                // vzimame si eventa chrez id-to
                Event eve = db.Events.Find(id);

                // Ako eventa e null se vrushtame kum index stranicata
                if (eve == null)
                {
                    return Redirect("/");
                }

                // podavame eventa na viewto
                return View(eve);
            }


            
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Event eventModel)
        {

            // Ako ni podadat id koeto e null vrushtame greshka
            if (id == null)
            {
                return HttpNotFound();
            }


            using (var db = new IMDBDbContext())
                {
                    // Vzimame si eventa chrez id-to
                    Event currentEvent = db.Events.Find(id);


                // Ako podadenoto ot formata NE e validno ostavqme na sushtata stranica
                if (!ModelState.IsValid)
                {
                    // polzvame actiona edit
                    return RedirectToAction("edit");
                }


                // ako filma ne e validen se vrushtame kum "/"
                if (currentEvent == null)
                {
                    return Redirect("/");
                }

                //setvame mu stoinostite da sa ravni na tazi ot eventModel
                currentEvent.Name = eventModel.Name;
                currentEvent.Location = eventModel.Location;
                currentEvent.StartDateAndTime = eventModel.StartDateAndTime;
                currentEvent.EndDateAndTime = eventModel.EndDateAndTime;

                    //zapazvame promenite v bazata
                    db.SaveChanges();

                    // nakraq redirektvame kum index page-a
                    return Redirect("/");

                }
           
        }



        //TRIENE NA EVENTI:

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {

            // Ako ni podadat id koeto e null vrushtame greshka
            if (id == null)
            {
                return HttpNotFound();
            }


            using (var db = new IMDBDbContext())
            {
                // Vzimame eventa 
                Event @event = db.Events.Find(id);

                // Ako eventa e null se vrushtame ku index page-a
                if (@event == null)
                {
                    return Redirect("/");
                }

                // i go podavame na viewto
                return View(@event);
            }


        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Event filmModel)
        {
            // Ako ni podadat id koeto e null vrushtame greshka
            if (id == null)
            {
                return HttpNotFound();
            }



            // MODELA SHTE E VALIDEN ZASHTOTO NE MOJME DA GO PROMENQME!

            using (var db = new IMDBDbContext())
            {
                // NAMIRAME EVENTA, PREMAHVAME GO, ZAPAZVAME BAZATA
                Event @event = db.Events.Find(id);
                db.Events.Remove(@event);
                db.SaveChanges();

                //Redirektvame kum Index stranicata !
                return Redirect("/");

            }


        }
    }
}