using P01_HospitalDatabase;
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {

        //Konstruktori
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {

        }

        //Pravim si DbSetovete NE MOJE DA NE SA PUBLICHNI !
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }

        public DbSet<Doctor> Doctors { get; set; }



        //PREZAPISVAME SI METODITE OT DbContext KLASA ZA CONNECTION STRINGA I VRUZKITE MEJDU BAZITE !

        //Opravqme connection stringa
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.connectionString);
            }
        }


        //Relacii:
        protected override void OnModelCreating(ModelBuilder builder)
        {

            //NE VSICHKO TUK E ZDULJITELNO 

            //Patient
            builder.Entity<Patient>(entity =>
            {

                entity.HasKey(e => e.PatientID);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(250);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(80);

                entity.Property(e => e.HasInsurance)
                    .HasDefaultValue(true);


            });


            //Visitations
            builder.Entity<Visitation>(entity =>
            {

                entity.HasKey(e => e.VisitationID);

                entity.Property(e => e.Date)
                    .HasColumnType("DATETIME2")
                    .HasDefaultValueSql("GETDATE()") //SEGASHNATA DATA MU E PO DEFAULT
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                entity.Property(e => e.Comments)
                    .IsRequired(false)
                    .IsUnicode()
                    .HasMaxLength(250);

                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Visitations) //Edin pacient ima mnogo vizitacii
                    .HasForeignKey(e => e.PatientId)
                    .HasConstraintName("FK_Visitation_Patient");

                entity.HasOne(v => v.Doctor)
                    .WithMany(d => d.Visitations)
                    .HasForeignKey(v => v.DoctorId)
                    .HasConstraintName("FK_Vosotation_Doctor");

            });


            //Diagnose
            builder.Entity<Diagnose>(entity =>
            {

                entity.HasKey(e => e.DiagnoseID);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(50);

                entity.Property(e => e.Comments)
                    .IsRequired(false)
                    .IsUnicode()
                    .HasMaxLength(250);

                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Diagnoses) //Edin pacient ima mnogo vizitacii
                    .HasForeignKey(e => e.PatientId)
                    .HasConstraintName("FK_Diagnose_Patient");
            });


            //Medicaments
            builder.Entity<Medicament>(entity => {

                entity.HasKey(p => p.MedicamentID);

                entity.Property(e => e.Name)
                    .IsUnicode()
                    .HasMaxLength(50);
                
            });


            //PatirntMedicament MAPPING TABLICA
            builder.Entity<PatientMedicament>(entity => {

                entity.HasKey(pe => new
                {
                    pe.PatientId,
                    pe.MedicamentId
                });

                entity.HasOne(e => e.Medicament)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(e => e.MedicamentId);

                entity.HasOne(e => e.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(e => e.PatientId);

            });
       

            //Doctor
            builder.Entity<Doctor>(entity => {

                entity.HasKey(d => d.DoctorID);

                entity.HasMany(e => e.Visitations)
                    .WithOne(v => v.Doctor);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired()
                    .IsUnicode();

                entity.Property(e => e.Speciality)
                    .HasMaxLength(100)
                    .IsRequired()
                    .IsUnicode(); 

            });

            /*
                Za da vkarame NOVATA doktor tabicata v bazata si pravim 
                nova migraciq i posle updeitvame bazata !!!
             */
        
        }




    }
}
