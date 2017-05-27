
namespace CarsRentalSystem.Models.Cars
{
    public class ListCarModel
    {
        // tok kazvame kakvo iskame da vizualizirame ot purvite 4 koli :

        public int Id { set; get; } // tova ni trqbva samo za da gnerirame link kum kokretnata stanica

        public string Brand { set; get; }

        public string Model { set; get; }

        public int Year { set; get; }

        public decimal PricePerDay { set; get; }

        public bool IsRented { set; get; }

        public string ImageUrl { set; get; }

    }
}