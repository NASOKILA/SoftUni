namespace Cars
{
    using Car.Data;
    using Car.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            //Za da polzvame ClassDbContext() koeto e ot drugiq proekt 
            //trqbva da go instancirame purvo.
            using (var db = new CarsDbContext())
            {

                /*
                   VAJNO !!! 
                   Ako imame baza s migracii i dadem .EnsureCreated() shte ni q 
                   napravi, obache ako imame migracii nqma da ni nalee tablicite.
                   V takuv sluchai polzvame .Migrate() !!!!!!

                   Ako obache Nqmame migracii i dadem .Migrate() shte ni napravi 
                   bazata bez tablicite zashtoto nqmame migraciq tablici !
                   V takuv sluchai si polzvame .EnsureCreated();
                */

                /*

              Migracii:
                  Ako iskame da updeitnem bazata dobvqiki migraciq 
                  Pishem: 
                  Add-MIgration ImeNaMigraciq(PURVIQ PUT MOJE DA E Initial)
                  POSLE AKO DADEM update-Database shte grumne zashtoto VECHE IMAME DABLICI VUTRE.
                  Prosto pishem 'drop-database' i 'update-database' poluchavame novata versiq na bazata.
                  POSLE V BAZATA IMAME TABLICA MigrationHistory KOQTO NI KAZVA KOQ MIGRACIQ KOGA E BILA SUZDADENA 
                */


                //Suzdavame si bazata 
                //db.Database.EnsureCreated();



                //Risetvame si bazata s migraciite !
                ResetDatabase(db);



                var cars = db.Cars
                    .Include(c => c.CarDealerships)
                    .ThenInclude(cd => cd.Dealership);


                foreach (var car in cars)
                {
                    Console.WriteLine($"-Model: {car.Model} - DealershipsCount: {car.CarDealerships.Count}");

                    foreach (var dealer in car.CarDealerships)
                    {
                        Console.WriteLine($"---Dealership Name{dealer.Dealership.Name}");
                    }

                }


                
            }

        }

        //S TOZI METOD SI RISETVAME BAZATA
        private static void ResetDatabase(CarsDbContext db)
        {
            //Triem bazata
            db.Database.EnsureDeleted();

            //Migrirame q zashtoto veche imame migracii
            db.Database.EnsureCreated();

            //S TOZI METOD SLAGAME DANNI PO TABLICITE
            Seed(db);
        }

        private static void Seed(CarsDbContext db)
        {
            //Tuk si suzdavame dannite i gi vkarvame v bazata chrez CarsDbContext klasa :

            var Makes = new[]
            {
                new Make() { Name = "Ford"},
                new Make() { Name = "Mercedes"},
                new Make() { Name = "Audi"},
                new Make() { Name = "BMW"},
                new Make() { Name = "Лада"},
                new Make() { Name = "Трабант"}
            };
            db.Makes.AddRange(Makes);

            var Engines = new[]
            {
                new Engine()
                {
                    Capacity = 1.6,
                    Cyllinders = 4,
                    FuelType = FuelType.Petrol,
                    HorsePower = 95
                },

                new Engine()
                {
                    Capacity = 3.0,
                    Cyllinders = 8,
                    FuelType = FuelType.Diesel,
                    HorsePower = 318
                },

                new Engine()
                {
                    Capacity = 1.2,
                    Cyllinders = 3,
                    FuelType = FuelType.Gas,
                    HorsePower = 60
                }

            };
            db.Engine.AddRange(Engines);

            var LicencePlates = new[]
            {
                new LicencePlate()
                {
                    Number = "CB1235AB"
                },
                new LicencePlate()
                {
                    Number = "BG8856CD"
                },
                new LicencePlate()
                {
                    Number = "BR6732BG"
                }
            };
            db.LicencePlates.AddRange(LicencePlates);

            var Dealerships = new[]
            {
                new Dealership()
                {
                    Name = "SoftUniAuto",
                },

                new Dealership()
                {
                    Name = "FastAndFurious Auto"
                },

                new Dealership()
                {
                    Name = "AutoHera"
                }
            };
            db.Dealerships.AddRange(Dealerships);        

            var Cars = new[]
            {
                new Car()
                {
                    Engine = Engines[2],
                    Make = Makes[3],
                    Doors = 4,
                    Model = "Кашон",
                    LicencePlate = LicencePlates[0],
                    YearOfProduction = new DateTime(1958, 1, 1),
                    Transmission = Transmission.Manual,
                    FuelType = FuelType.Diesel
                },

                new Car()
                {
                    Engine = Engines[1],
                    Make = Makes[4],
                    Doors = 2,
                    Model = "Кашон-432",
                    LicencePlate = LicencePlates[1],
                    YearOfProduction = new DateTime(1954, 1, 1),
                    Transmission = Transmission.Automatic,
                    FuelType = FuelType.Gas
                },

                new Car()
                {
                    Engine = Engines[0],
                    Make = Makes[0],
                    Doors = 4,
                    Model = "Escort",
                    LicencePlate = LicencePlates[2],
                    YearOfProduction = new DateTime(1955, 1, 1),
                    Transmission = Transmission.Automatic,
                    FuelType = FuelType.Electric
                }
            };
            db.Cars.AddRange(Cars);

            //populvame si Mapping tablicata s danni
            var CarDealerships = new[]
            {
                new CarDealership()
                {
                    Car = Cars[0], Dealership = Dealerships[0]
                },

                new CarDealership()
                {
                    Car = Cars[1], Dealership = Dealerships[1]
                },

                new CarDealership()
                {
                    Car = Cars[2], Dealership = Dealerships[2]
                },
            };
            db.CarDealerships.AddRange(CarDealerships);

            //Seivame si dannite v bazata
            db.SaveChanges();
        }
    }
}
