

namespace CarsRentalSystem.Models.Renting
{
    public class RentCarModel
    {
        public int CarId { set; get; }

        public string CarName { set; get; }

        public string CarImgUrl { set; get; }

        public int Days { set; get; }

        public decimal Price { set; get; }
    
        public decimal TotalPrice { set; get; }

    }
}