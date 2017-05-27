using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsRentalSystem.Models.Renting
{
    public class UserRentingModel
    {
        public int Days { set; get; }

        public DateTime RentedOn { set; get; }

        public decimal TotalPrice { set; get; }

        public string CarName { set; get; }

        public string CarImageUrl { set; get; }
    }
}