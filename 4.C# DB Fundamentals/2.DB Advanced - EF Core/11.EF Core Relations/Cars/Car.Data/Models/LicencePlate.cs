namespace Car.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LicencePlate
    {
        public int Id { get; set; }

        public string Number { get; set; }

        //Pravim go da e nullable v sluchai che ne slojim nishto
        public int CarId { get; set; } 
        public Car Car { get; set; }
    }
}
