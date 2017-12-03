using forum.data.models;
using Forum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Forum.Data
{

    public class ForumDbContext : DbContext
    {
        

        public ForumDbContext()
        {

        }

        public ForumDbContext(DbContextOptions options)
            :base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Reply> Replies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString); 
            }
            
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Posts)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Replies)
                .WithOne(p => p.Post)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            

            modelBuilder.Entity<User>()
                .HasMany( u => u.Posts)
                .WithOne(u => u.Author)
                .HasForeignKey(u => u.AuthorId);


            modelBuilder.Entity<User>()
                .HasMany(u => u.Replies)
                .WithOne(u => u.Author)
                .HasForeignKey(u => u.AuthorId);
            

            modelBuilder.Entity<PostTags>()
                .HasKey(pt => new
                {
                    pt.PostId,
                    pt.TagId
                });



        }
    }
}
