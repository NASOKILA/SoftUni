using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Data.Models
{
    public class Dealership
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Inicializirame si go !
        public ICollection<Car> Cars { get; set; }
            = new List<Car>();

        //Inicializirame si go !
        public ICollection<CarDealership> CarDealership { get; set; }
            = new List<CarDealership>();
    }
}
