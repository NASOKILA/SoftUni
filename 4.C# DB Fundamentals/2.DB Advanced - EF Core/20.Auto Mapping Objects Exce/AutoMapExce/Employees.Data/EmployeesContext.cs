namespace Employees.Data
{
    using Employees.Data.Configuration;
    using Employees.Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class EmployeesContext : DbContext
    {


        public EmployeesContext()
        {}

        //Toq konstruktor shte e za service
        public EmployeesContext(DbContextOptions options)
                :base(options)
        {}

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationStr.connectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

    }
}
