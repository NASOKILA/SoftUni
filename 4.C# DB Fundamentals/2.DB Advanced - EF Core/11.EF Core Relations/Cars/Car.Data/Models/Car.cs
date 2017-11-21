namespace Car.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        public int Id { get; set; }

        public int MakeId { get; set; }
        public Make Make { get; set; }

        public string Model { get; set; }

        public int EngineId { get; set; }
        public Engine Engine { get; set; }

        public int Doors { get; set; }

        //FuelType she e ENUM
        public FuelType FuelType { get; set; }

        //Skorostite(Transmission) shte sa klas ot tip ENUM
        public Transmission Transmission { get; set; }

        public DateTime YearOfProduction{ get; set; }

        //Inicializirame si go !
        public ICollection<CarDealership> CarDealerships { get; set; }
            = new List<CarDealership>();    

        public int LicencePlateId { get; set; }
        public LicencePlate LicencePlate { get; set; }
    
    }
}
