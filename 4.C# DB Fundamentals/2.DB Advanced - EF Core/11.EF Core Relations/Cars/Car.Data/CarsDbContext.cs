namespace Car.Data
{
    using Microsoft.EntityFrameworkCore;
    using Data.Models;
    using Car.Data.Models.Configuration;

    public class CarsDbContext : DbContext
    {
        //01.Konstruktorite

        public CarsDbContext()
        {

        }

        public CarsDbContext(DbContextOptions options)
            :base(options)
        {

        }


        //02.Dobavqme si Db Setovete

        public DbSet<Make> Makes { get; set; }

        public DbSet<Engine> Engine { get; set; }

        public DbSet<LicencePlate> LicencePlates { get; set; }

        public DbSet<Dealership> Dealerships { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarDealership> CarDealerships { get; set; }


        //Klasovete ot tip enum ne gi slagame v DbSet<>
        //Dobra praktika e da gi izkarvame v otdelna papka !


        //Opravqme si Connection Stringa

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server = HAL\MSSQLSERVER2; Database = Car; Integrated Security = True");
            }
        }

        //Relacii i proeprtita ot tablici
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relacii:

            /*
            VAJNO !!! :
            Ima i drug nachin za pravene na relacii:
            Prosto ne pishem nishto tuk i to samo shte si gi napravi po default
            bez nie da sme go pipali.
            */

            //Car
                //Vikame si propertitata definirani v CarCoufiguration KLASA
            modelBuilder.ApplyConfiguration(new CarConfiguration());

            
            //Dealership
            modelBuilder.ApplyConfiguration(new DealershipConfiguration());
            

            //CarDealership
            //VIKAME SI METODITE OT KLASA CarDealershipConfiguration KOITO NAPRAVIHME !
            modelBuilder.ApplyConfiguration(new CarDealershipConfiguration());
            

            //Engine
            modelBuilder.ApplyConfiguration(new EngineConfiguration());
            

            //Make
            //OneToMany Make - Car
            modelBuilder.ApplyConfiguration(new MakeConfiguration());


            modelBuilder.Entity<LicencePlate>(entity =>
            {
            });
            

        }
    }
}







