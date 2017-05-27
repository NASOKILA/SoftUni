

namespace CarsRentalSystem.DataModels
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;


    // TUK NIE KAZVAME KAKVO TRQBVA DA IMA V BAZATA
    public class CarsDbContext : IdentityDbContext<User>
    {
        public CarsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        // SHTE KAJEM NA BAZATA CHE TRQBVA DA IMA I RENTINGI
        public virtual IDbSet<Renting> Rentings { get; set; }


        //Kazvame na bazata che trqbva da ima i koli
        public virtual IDbSet<Car> Cars { get; set; }

        public static CarsDbContext Create()
        {
            return new CarsDbContext();
        }
    }
}