

namespace CarsRentalSystem.DataModels
{
    
    using System;

    public class Renting
    {
        // KAKVO IMA EDIN RENTING

            //Id na rentvane
        public int Id { get; set; }

        public DateTime RentedOn { get; set; }

        // Za kolko dni
        public int Days { get; set; }

        //Cena
        public decimal TotalPrice { get; set; }

        // KOI USER E VZEL KOLATA
        public string UserId { get; set; }
        public virtual User User { get; set; }

        //KOQ KOLA E VZEL
        public int CarId{ get; set; }
        public virtual Car Car { get; set; }

        // TRQBVA V CARS I V USERS DA KAJEM N BAZATA KOI E RENTNAL DADENA KOLA I KOLKO PUTI E RENTNATA!
        // TRQBVA I DA GO DOBAVIM V BAZATA T.E. V CarsDbContext.cs  : public virtual IDbSet<Renting> Rentings  {get; set;}

    }
}