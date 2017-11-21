using forum.data.models;
using Forum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Forum.Data
{
    //ZADULJITELNO NASLEDQVAME KLASA DbContext ZA DA MOJEM DA POLZVAME NESHTATA V NEGO
    public class ForumDbContext : DbContext
    {
        /*Tuk ima edin ili mnogo DbSets<>

        DbSet-a e tablica v bazata koqto MOJEM DA DOSTUPIM PRI IZVIKVANE
        NA DbContext klasa.


        DbSet-a ima metodi, Add, Attach, Remove, Find koito mojem da polzvame i 
        da efektirame bzata. 
        Raboti malko kato list, mojem da go foreachvame.
        MOJEM DA FOREACHVAME VSICHKO KOETO E INumerable


       Add - Dobavq sled kato napishem DbChanges() 
       Remove - Premahva sled kato napishem DbChanges()
       Find - Namira
       Attach - Ako sme otkachili dadeno entity ot DbContexta posle mojem da go zakachim pak.

        */

        /*PRAVIM SI KONSTRUKTORI ZA DA MOJEM DA INSTANCIRAME PO LESNO KLASA:*/
        public ForumDbContext()
        {
            //Prazen
        }

        public ForumDbContext(DbContextOptions options)
            :base(options)
        {
            /*  Tozi go vzehme ot metadannite na DbContext klasa i si go prekrastihme na 
                na 'ForumDbContext' koito nasledqva bazoviq konstriktor 
                I SEGA NQKOI MOJE DA NI GO INSTANCIRA S NQKAKVI SI NEGOVI OPCII.
                SLEDOVATELNO SHTE MOJE DA POLZVA NEGOV CONNECTION STRING, NEGOVA BAZA I T.N.
             */
        }

            /*PRAVIM SI DbSet-ovete :*/
        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Reply> Relies { get; set; }
        /*
        public DbSet<Tag> Tags{ get; set; }

        public DbSet<PostTags> PostTags { get; set; }
        */

        /*
            Trqbva da konfigurirame Connection Stringa.
            Trqbva da implementirame slednoto:
         */

        //Overridvame sledniq metod zashtoto trqbva da si slojim connection stringa v nego
        //za da go polzva nego kato default
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //DOBRA PRAKTIKA E PRI OVERRIDVANE NA METOD DA NAPRAVIM SLEDNOTO !
            //Kazvame mu da si pravi tova koeto pravi i posle da gleda nashata logika.
            base.OnConfiguring(optionsBuilder);

            //Tuk trqbva da si configurirame connectionStringa inache ne znae s koq baza da raboti


            //KONFIGURIRAME SI DA POLZVAME CONNECTION STRING
            if (!optionsBuilder.IsConfigured)
            {
                //Ako NE e konfiguriran t.e. ako nikoi ne mu e podal connection stringa.
                //Mu podavame Connection Stringa koito go slojihme v klasa Configuraton.
                optionsBuilder.UseSqlServer(Configuration.ConnectionString); 
            }


        }
        


        /*
            Fluent API:
                Metoda OnModelCreating ni pozvolqva da polzvame FLUENT API chrez koeto
                si opisvame tablicite za bazata i tehnite vruzki.
         
            MOJEM DA POLZVAME ANNOTACII.     
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {




            //TUK KAZVAME CHE IMAME ONE-TO-MANY RELACIQ MEJDU Category I Posts 
            //i Foreign KEY 
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Posts)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            //I Produljavame na dolo da si opisvame vruzkite

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Replies)
                .WithOne(p => p.Post)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            //PRI SUZDAVANE NA BAZATA GURMI ZASHTOTO REPLIES PRAVI CIKLI S PostId 
            //ZATOVA SLAGAME .OnDelete(DeleteBehavior.Restrict); SEGA KATO IZTRIEM EDIN REPLY
            //DA NE TRIEM I NEGOVITE POSTOVE.
          
            modelBuilder.Entity<User>()
                .HasMany( u => u.Posts)
                .WithOne(u => u.Author)
                .HasForeignKey(u => u.AuthorId);

            //Opisvame che edin User ima i mnogo Replies
            modelBuilder.Entity<User>()
                .HasMany(u => u.Replies)
                .WithOne(u => u.Author)
                .HasForeignKey(u => u.AuthorId);
            



            //TRQBVA DA OPISHEM MANY TO MANY VRUZKA MEJDU Posts i Tags !!!
            modelBuilder.Entity<PostTags>()
                .HasKey(pt => new
                {
                    //Tuk selektirame i dvete Id-ta da sa Primary key
                    pt.PostId,
                    pt.TagId
                });
            //S .ToTable("NovoIme");    MOJEM DA SMENIM IMETO NA TABLICATA !!!   



            //SLED KATo KLASOVETE SA DOBAVENI MOJEM DA SI DOBAVIM MIGRACIQTA !!! 
            // S Add-Migration MigrationName


            //.Entity metdoda mojem da go polzvame za opisvane na nqkakvi relacii
            //.Ignore metoda izkluchva ot bazata dadeno property ot dadeno entity
            //Ima i drugi neshta, vijdame gi kato natisnem .
        }






    }
}
