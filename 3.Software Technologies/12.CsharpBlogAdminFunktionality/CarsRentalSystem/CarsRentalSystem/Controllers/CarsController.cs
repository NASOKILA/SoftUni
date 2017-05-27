
namespace CarsRentalSystem.Controllers
{
    using DataModels;
    using Microsoft.AspNet.Identity;
    using Models.Cars;
    using Models.Renting;
    using System;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;   // S TOVA STAVA MVC KONTROLLER

    public class CarsController : Controller
    {
        // ACTION ZA SUZDAVANE NA KOLA
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }



        // ACTION ZA POLUCHAVANE NA KOLA OT USERA
        [HttpPost]
        [Authorize]
        public ActionResult Create(CreateCarModel carModel)
        {
            //KOGATO IMAME POST ZADULJITELNO TRQBVA DA PROVERIM DALI POSTA E VALIDEN
            if (carModel != null || this.ModelState.IsValid) {
                // AKO VSICHKO E NARED POCHVAME DA PRAVIM PROMQNI KUM model

                var ownerId = this.User.Identity.GetUserId();
                // SEGA TRQBVA DA SI OPISHEM SAMATA KOLA:

                var car = new Car
                {
                    //Tuk setvame tova koeto usera veche e populnil
                    // PO PRINCIP IMA BIBLIOTEKI KOITO GO PRAVQT TOVA AVTOMATICHNO

                    Brand = carModel.Brand,
                    Model = carModel.Model,
                    Year = carModel.Year,
                    Color = carModel.Color,
                    Engine = carModel.Engine,
                    Power = carModel.Power,
                    PricePerDay = carModel.PricePerDay,
                    ImageUrl = carModel.ImageUrl,
                    EngineType = carModel.EngineType,
                    OwnerId = ownerId

                };


                // SEGA NI TRQBVA BAZATA ZA DA ZAPISHEM NOVATA NI KOLA:
                var db = new CarsDbContext();
                db.Cars.Add(car); // dobavqme kolata




                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }




                return RedirectToAction("Details", new { id = car.id });
                // redirectvame kum Details i PODAVAME IDto NA KOLATA
                /*Nie ne setvame Id nikade, nito usera ni go dava, no SavaChanges go 
                 dobavq i ni go setva avtomatichno !!! VAJNO !!!*/
            }

            return View(carModel); // AKO NE, VRUSHTAME modela NA USERA ZA DA SI VIDI GRESHITE
        }


        //SHte SUZDADE Details ZA VSQKA KOLA

        public ActionResult Details(int id) {
            var db = new CarsDbContext();

            var car = db.Cars
                .Where(c => c.id == id) // vzimame kolata kiito id suvpada
                .Select(c => new CarDetailModel {
                    // ot taq kola selectirame  CarDetailModel

                    Id = c.id,
                    Brand = c.Brand,
                    Color = c.Color,
                    Engine = c.Engine,
                    EngineType = c.EngineType,
                    Year = c.Year,
                    Model = c.Model,
                    ImageUrl = c.ImageUrl,
                    IsRented = c.IsRented,
                    Power = c.Power,
                    PricePerDay = c.PricePerDay,
                    TotalRents = c.Rentings.Count, // Vkarvame si i TotalRents NO TRQBVA PURVO V MODULA DA GO SUZDADEM
                    ContactInformation = c.Owner.Email
                })
                .FirstOrDefault(); // vzimame purvata namerena





            if (car == null)
            {
                return HttpNotFound(); // ako nqma takava kola da vurne tazi greshka 
            }

            return View(car);
        }


        public ActionResult All(int page = 1, string user = null, string search = null) {
            /* 
              TOVA SEARCH IDVA OT SEARCH BARA I TRQBVA DA E SUS 
              SUSHTOTO IME KOETO SME KAZALI VUV FORMICHKATA T.E. "search" SETVAME GO DA E NULL
            
             */


            // mojem da podadem user a moje i da ne go podadem
            var db = new CarsDbContext();

            var carsQuery = db.Cars.AsQueryable();

            if(search != null){ // AKO SURCHA NE E NULL T.E. SME POLUCHILI NESHTO
                carsQuery = carsQuery
                    .Where(c => c.Brand.ToLower().Contains(search.ToLower()) ||
                    c.Model.ToLower().Contains(search.ToLower()));

                /*Iskame kato napishem markata ili modela na kolata da namira kolata
                 T.E. brand to lower da sudurja search to lower ili model to lower da sudurja search to lower
                 
                 */
            }


            if (user != null) {
                // ako nie podaden user

                carsQuery = carsQuery
                    .Where(c => c.Owner.Email == user);
            }

            var pageSize = 5;


            // AKO NQMAME USER GI VZIMAME VSICHKITE !

            var allCars = carsQuery
                .OrderByDescending(c => c.id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new ListCarModel {

                    Id = c.id,
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year,
                    ImageUrl = c.ImageUrl,
                    PricePerDay = c.PricePerDay,
                    IsRented = c.IsRented


                }).ToList();

            ViewBag.CurrentPage = page;

            if (allCars == null)
            {
                return HttpNotFound(); // ako nqma takava kola da vurne tazi greshka 
            }

            return View(allCars);
        }


        [Authorize]
        [HttpGet]
        public ActionResult Rent(RentCarModel rentCarModel)
        {
            // TRQBVA DA SI NAPRAVIM MODEL PURVO





            if(rentCarModel.Days < 1 || rentCarModel.Days > 10)
            {
                // ako dnite sa po malko ot 1 ili poveche ot 10 da vruhta greshka
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            } 




            // vzimme kolata:

            var db = new CarsDbContext();
            var car = db.Cars
                .Where(c => c.id == rentCarModel.CarId)
                .Select(c => new {

                    c.IsRented,
                    c.PricePerDay,
                    c.ImageUrl,
                    FullName = c.Brand + " " + c.Model + "(" + c.Year + ")",

                })
                .FirstOrDefault();

            if (car == null && car.IsRented)
            {// ako kolagta q nqma ili e veche rentnata
                return HttpNotFound();
            }


            // ako sushtestvuva kola obache kazvame che :
            rentCarModel.CarImgUrl = car.ImageUrl;
            rentCarModel.CarName = car.FullName;
            rentCarModel.Price = car.PricePerDay;
            rentCarModel.TotalPrice = car.PricePerDay * rentCarModel.Days;

            return View(rentCarModel);  // podavame kolata kum viuto
        }




        [Authorize]
        [HttpPost]
        public ActionResult Rent(int carId, int days)
        {
            var db = new CarsDbContext();
            
            // vzimame kolata 
            var car = db.Cars
                .Where(c => c.id == carId)
                .FirstOrDefault();

            var userId = this.User.Identity.GetUserId();
            //vzimame si userId


            if (car == null || car.IsRented || car.Owner.ToString() == userId)
            {// Ako kolata e rentnata ili e null ili nie sme nein owner ne moje da q vzemem
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                // HVURLQME EXEPTION BAD REQUEST
            }


            // Ako vsichkoe nared suzdavame nov renting

            var renting = new Renting
            {
                CarId = carId,
                Days = days,
                RentedOn = DateTime.Now,  // vzimame tochnata data s chas za da zapishem koga e vzeta kolata
                UserId = userId,
                TotalPrice = days * car.PricePerDay
            };

            car.IsRented = true; // kazvame che veche kolata e rentnata

            // Sega seivame vuv bazata !!!
            db.Rentings.Add(renting);
            db.SaveChanges();




            return RedirectToAction("Details", new { id = car.id});
            //redirektvame kum Details obache mu podavame idto na kolata koqto veche e vzeta !!!!!
        }

        }
    }


