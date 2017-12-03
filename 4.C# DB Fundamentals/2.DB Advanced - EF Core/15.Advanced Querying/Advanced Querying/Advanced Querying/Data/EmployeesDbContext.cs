namespace AdvancedQuerying.Data
{
    using AdvancedQuerying.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EmployeesDbContext : DbContext
    {
      
        public DbSet<Employee> Employees{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=HAL\MSSQLSERVER2;Database=Employees2;Integrated Security=True");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .IsConcurrencyToken(); //Setvame go da e koncuttency obekt

            /*
             Sega ako imame dva kontexta koito da Rabotat s edno property trqbva da se 
             ni hvurli DbUpdateConcurrencyException.

            SEGA VECHE NE MOJE DA POLZVAME POVECHE OT EDIN KONTEXT !!!

            MOJEM DA GO NAPRAVIM CHREZ ANNOTACIQTA [ConcurrencyCheck]
            */
        }



    }
}
