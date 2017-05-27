

namespace CarsRentalSystem.DataModels
{

    using System.Data.Entity;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;


    public class User : IdentityUser
    {

        public User() {
            this.Cars = new HashSet<Car>();
            this.Rentings = new HashSet<Renting>(); 
        }
        
        // edin user moje da ima poveche koli za davane
        public virtual ICollection<Car> Cars { get; set; }


        // TRQBVA V CARS I V USERS DA KAJEM N BAZATA KOI E RENTNAL DADENA KOLA I KOLKO PUTI E RENTNATA!
        public virtual ICollection<Renting> Rentings { get; set; }

        // TRQBVA I DA GO DOBAVIM V BAZATA T.E. V CarsDbContext.cs  : public virtual IDbSet<Renting> Rentings  {get; set;}



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
 
        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            return userIdentity;
        } 
    }
 }   
