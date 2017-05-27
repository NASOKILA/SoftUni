
using CarsRentalSystem.DataModels;
using System.ComponentModel.DataAnnotations;

namespace CarsRentalSystem.Models.Cars
{
    public class CarDetailModel
    {

        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public decimal PricePerDay { get; set; }

        public int? Power { get; set; }

        public double Engine { get; set; }

        public EngineType EngineType { get; set; }

        public string ImageUrl { get; set; }

        public bool IsRented { get; set; }

        //Trqbva ni owner za da ne vizualizirame butona ako nie sme owneri 
        public string CarOwner { get; set; }

        public string Color { get; set; }

        public string ContactInformation { get; set; }

        public int TotalRents { get; set; }

    }
}