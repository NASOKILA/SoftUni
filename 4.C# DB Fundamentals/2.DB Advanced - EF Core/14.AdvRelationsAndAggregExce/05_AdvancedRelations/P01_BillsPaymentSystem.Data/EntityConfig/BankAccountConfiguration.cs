namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {

            //Properties

            builder.HasKey(b => b.BankAccountId);

            builder
                .Property(b => b.BankName)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(b => b.SwiftCode)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(b => b.Balance)
                .IsRequired();


            //Ne iskame navigacionni propertita v bazata atova gi ignorirame
            builder.Ignore(b => b.PaymentMethodId); //Samo klucha e dostatuchno

        }
    }
}
