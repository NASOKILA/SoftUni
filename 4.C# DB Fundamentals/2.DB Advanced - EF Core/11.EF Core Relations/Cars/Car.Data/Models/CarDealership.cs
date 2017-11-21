namespace Car.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CarDealership
    {

        //TOVA E MAPPING TABLICA ZA MANY TO MANY VRUZKA SUS Car I Dealership

        //Sega EFCore se useshta che CarId e property na klasa Car
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int DealershipId { get; set; }
        public Dealership Dealership { get; set; }
    }
}
