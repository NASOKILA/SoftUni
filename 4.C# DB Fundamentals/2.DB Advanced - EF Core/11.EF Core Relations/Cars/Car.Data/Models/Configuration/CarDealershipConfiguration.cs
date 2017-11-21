namespace Car.Data.Models.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    //Tozi Klas e za konfiguraciq na CarDealership  
    public class CarDealershipConfiguration : IEntityTypeConfiguration<CarDealership>
    {

        //Kato mu dadem CTRL + .  I go implementirame ni izliza tozi metod.
        public void Configure(EntityTypeBuilder<CarDealership> builder)
        {
            //VECHE NE NI TRABVQ .Entity<CarDealership> ZASHTOTO E QSNO CHE SE OTNASQ ZA NEGO !

            builder
                .HasKey(cd  => new { cd.CarId, cd.DealershipId});

            //VAJNO !!!
            //S ToTable() Mojem da promenqme imeto na CarDealerships ku kakvoto si iskame
                //builder.ToTable("CarsDealerships");

            builder
                .HasOne(cd => cd.Car)
                .WithMany(c => c.CarDealerships)
                .HasForeignKey(cd => cd.CarId);

            builder
                .HasOne(cd => cd.Dealership)
                .WithMany(c => c.CarDealership)
                .HasForeignKey(cd => cd.DealershipId);

            
        }
        /*
            TOZI KLAS TRQBVA DA GO IZVIKAME VUV Fluent API !    
        */
    }
}
