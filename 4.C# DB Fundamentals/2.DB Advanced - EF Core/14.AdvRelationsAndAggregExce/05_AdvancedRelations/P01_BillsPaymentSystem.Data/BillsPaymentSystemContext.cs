namespace P01_BillsPaymentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data.EntityConfig;
    using P01_BillsPaymentSystem.Data.Models;
    using System;

    public class BillsPaymentSystemContext : DbContext
    {


        public BillsPaymentSystemContext()
        {

        }


        public BillsPaymentSystemContext(DbContextOptions options)
            :base(options)
        {

        }


        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfiguration(new BankAccountConfiguration());

            model.ApplyConfiguration(new CreditCardConfiguration());

            model.ApplyConfiguration(new UserConfiguration());

            model.ApplyConfiguration(new PaymentMethodConfiguration());
        }

        
    }
}
