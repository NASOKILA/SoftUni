namespace CarsRentalSystem.Migrations
{
    using DataModels;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<CarsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "CarsRentalSystem.DataModels.CarsDbContext";
        }

        protected override void Seed(CarsDbContext context)
        {


            // TOZI SEED METOD NI POZVOLQVA DA DOBAVQM NOVI KOLI

            // HTE NAPRAVIM EDIN PRIMER

            
            if (context.Cars.Any())
            {
                return; //ako ima nqkukvi da se vurnat I IZLIZAME OT TUK
            }
            // ako li ne:


            var user = context.Users.FirstOrDefault();
            // vzimame nqkakuv user

            if (user == null)
            {
                return; //ako usera e null t.e. ako nqma useri si trugvame ot tuka 
            }
            // ako li ne:

            
            
            
            //SHTE DOBAVIM NQKOLKO KOLI :


            context.Cars.Add( new Car {

                Brand = "Reno",
                Model = "Megane",
                Year = 2006,
                Color = "black",
                Engine = 5.0,
                Power = 177,
                PricePerDay = 80,
                ImageUrl = "http://autopazar.co.uk/media/11602/Used_Renault_Megane_2005_Black_Hatchback_Petrol_Manual_for_Sale_in_London_UK.jpg" ,
                EngineType = EngineType.Diesel,
                OwnerId = user.Id // zatova nie usera za da mu vzemem IDto

            });



            context.Cars.Add(new Car
            {
                Brand = "Peugeot",
                Model = "307",
                Year = 2004,
                Color = "White",
                Engine = 4.0,
                Power = 130,
                PricePerDay = 60,
                ImageUrl = "http://www.roadsmile.com/images/peugeot-307_white_3.jpg",
                EngineType = EngineType.Hybrid,
                OwnerId = user.Id // zatova nie usera za da mu vzemem IDto

            });


            context.Cars.Add(new Car
            {
                Brand = "Mercedes",
                Model = "220",
                Year = 2007,
                Color = "Silver",
                Engine = 7.0,
                Power = 230,
                PricePerDay = 100,
                ImageUrl = "https://i.ebayimg.com/00/s/NTc2WDEwMjQ=/z/0Z8AAOSwCU1Yvuqz/$_86.JPG",
                EngineType = EngineType.Gasoline,
                OwnerId = user.Id // zatova nie usera za da mu vzemem IDto

            });


            // MOJEM DA POLZVAME EDNA BIBLIOTEKA BODUS C# KOQTO NI GENERIRA RANDOM NESHTA 
            // KOITO NIE MU VUVEDEM


        }
    }
}
