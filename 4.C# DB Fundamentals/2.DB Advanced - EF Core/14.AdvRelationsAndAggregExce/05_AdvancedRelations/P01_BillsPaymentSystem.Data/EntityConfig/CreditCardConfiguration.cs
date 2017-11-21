namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {

            //Properties

            builder.HasKey(c => c.CreditCardId);


            //Ignorirame LimitLeft za da ne vlezne v bazata.
            builder.Ignore(c => c.LimitLeft);

            //Ne iskame navigacionni propertita v bazata atova gi ignorirame
            //kato ignorirame Id-to i paymenta ne vliza v bazata !!!
            builder.Ignore(c => c.PaymentMethodId);

            builder.
                Property(c => c.ExpirationDate)
                .IsRequired();

            builder.
                Property(c => c.Limit)
                .IsRequired();
            
            builder.
                Property(c => c.MoneyOwed)
                .IsRequired();

        }
    }
}
