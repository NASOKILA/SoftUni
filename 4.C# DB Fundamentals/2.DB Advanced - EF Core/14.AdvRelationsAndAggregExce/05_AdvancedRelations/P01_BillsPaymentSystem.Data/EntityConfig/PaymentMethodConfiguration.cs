namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            //Properties

            builder.HasKey(p => p.Id);

            //KAK DA NAPRAVIM UNIKALNA KOMBINACIQ ?
            builder.HasIndex(e => new { e.UserId, e.BankAccountId, e.CreditCardId}).IsUnique();
            

            //Connections and keys
            builder
                .HasOne(p => p.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(p => p.UserId)
                .HasConstraintName("FK_PaymentMethod_User");

            
            //VAJNO !!! Pri OneToOne vruzka Trqbva da opredelim Pri PRAVENETO NA FOREIGN KEY !
            builder
                .HasOne(p => p.BankAccount)
                .WithOne(u => u.PaymentMethod)
                .HasForeignKey<PaymentMethod>(p => p.BankAccountId)
                .HasConstraintName("FK_PaymentMethod_BankAccount");
            

            //VAJNO !!! Pri OneToOne vruzka Trqbva da opredelim Pri PRAVENETO NA FOREIGN KEY !
            builder
                .HasOne(p => p.CreditCard)
                .WithOne(u => u.PaymentMethod)
                .HasForeignKey<PaymentMethod>(p => p.CreditCardId)
                .HasConstraintName("FK_PaymentMethod_CreditCard");

        }
    }
}
