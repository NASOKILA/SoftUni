
namespace CarsRentalSystem.Controllers
{

    using CarsRentalSystem.DataModels;
    using Models.Cars;
    using System.Linq;
    using System.Web.Mvc;


    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //TRQBVA DA POKAJEM PURVITE 3 KOLI 
            //NI PURVO TRQBVA D GI VZEMEM

            var db = new CarsDbContext();

            var cars = db.Cars
                .Where(c => !c.IsRented) // kolata da ne e rentnata
                .OrderByDescending(c => c.id) // poslednite dobaveni
                .Take(3)// vzimame 3
                .Select(c => new ListCarModel {

                    Id = c.id,
                    ImageUrl = c.ImageUrl,
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year

                    // pravim si specialen model za viewto koito da ni kazva kakvo tochno da vizualizirame
                    //KZVAME SELEKTIRAI MI NOV HomeIndexModule SUS SLEDNITE DANNI : 
                });


            return View();
        }
        
    }
}