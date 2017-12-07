namespace Employees.Data.Configuration
{
    using Employees.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(60);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(60);
            
            entity.Property(e => e.Salary)
                .IsRequired();

            entity.Property(e => e.BirthDay)
                .IsRequired(false);

            entity.Property(e => e.Address)
                .IsRequired(false);
        }
    }
}
