namespace Car.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DealershipConfiguration : IEntityTypeConfiguration<Dealership>
    {
        public void Configure(EntityTypeBuilder<Dealership> builder)
        {
            //Dealership
            //ManyToMany Dealership - CarDealership

            builder
                .HasMany(d => d.CarDealership)
                .WithOne(cd => cd.Dealership)
                .HasForeignKey(cd => cd.DealershipId);

            /*VAJNO !!! :
                MOJEM DA OPISHEM TAZI VRUZKA I PO OBRATNQ NACHIN OBACHE V DRUG KLAS:
            
            modelBuilder.Entity<CarDelership>()
                .HasOne(c => c.Dealership)
                .WithMany(cd => cd.CarDealership)
                .HasForeignKey(cd => cd.DealershipId); // foreign key-a e sushtiq !!!
             */

        }
    }
}
