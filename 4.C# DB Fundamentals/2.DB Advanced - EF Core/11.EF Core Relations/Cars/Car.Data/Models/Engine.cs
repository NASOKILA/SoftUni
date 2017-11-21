namespace Car.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Engine
    {
        public int Id { get; set; }

        public double  Capacity { get; set; }

        public int Cyllinders { get; set; }

        public int HorsePower { get; set; }

        public FuelType FuelType { get; set; }
        
        public ICollection<Car> Cars { get; set; }
            = new List<Car>();
    }
}
