using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsRentalSystem.Models.Cars
{
    public class CarRentModel
    {
        public int CarId { set; get; }

        public string CarName { set; get; }

        public int Days { set; get; }

        public decimal Price { set; get; }

        public decimal TotalPrice { set; get; }

    }
}