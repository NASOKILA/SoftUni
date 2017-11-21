namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            //properties

            builder.HasKey(u => u.UserId);

            builder.Property(u => u.FirstName)
                .IsUnicode()
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.LastName)
                .IsUnicode()
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.Email)
                .IsUnicode(false)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(u => u.Password)
                .IsUnicode(false)
                .HasMaxLength(25)
                .IsRequired();
            
        }
    }
}
