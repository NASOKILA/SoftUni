namespace Car.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {


            //OneToOne  Car - LicencePlate
            builder
                .HasOne(c => c.LicencePlate)
                .WithOne(l => l.Car)
                .HasForeignKey<LicencePlate>(lp => lp.CarId);
            /*
                VAJNO !!!
                TOVA E ONE-TO-ONE VRUZKA, ZADULJITELNO TRQBVA DA OPISHEM 
                ZA KOI TIP REFERIRAME, V SLUCHAQ E (LicencePlate)
            */

            //ManyToMany Car - DealerShips

            //POLZVAME MAPPING TABLICA CarDealerhips Koqto ima Many-To-One VRUZKA
            //SUS KLASA Car I KLASA Dealerships !!!!!!!!!

            builder
                .HasOne(c => c.Make)
                .WithMany(m => m.Cars)
                .HasForeignKey(c => c.MakeId);

            
          
            /*VAJNO !!! :
                MOJEM DA OPISHEM VRUZKA v CarDealership() PO SLEDNIQ NACHIN :

            modelBuilder.Entity<CarDelership>()
                .HasOne(c => c.Car)
                .WithMany(cd => cd.Dealership)
                .HasForeignKey(cd => cd.CarId); // foreign key-a e sushtiq !!!
             */
        }
    }
}
