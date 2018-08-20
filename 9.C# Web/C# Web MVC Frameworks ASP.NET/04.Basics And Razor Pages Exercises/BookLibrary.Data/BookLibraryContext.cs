using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data
{
    public class BookLibraryContext : DbContext
    {
        public BookLibraryContext(DbContextOptions<BookLibraryContext> options)
            : base(options)
        {}

        public BookLibraryContext()
        {}

        public DbSet<Book> Books { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Borrower> Borrowers { get; set; }

        public DbSet<BorrowersBooks> BorrowedBooks { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<BorrowersMovies> BorrowersMovies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(Connection.ConnectionString);
            }
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(book => book.Borrowers)
                .WithOne(borrower => borrower.Book)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<Borrower>()
                .HasMany(borrower => borrower.BorrowedBooks)
                .WithOne(book => book.Borrower)
                .HasForeignKey(b => b.BorrowerId);

            modelBuilder.Entity<BorrowersBooks>()
                .HasKey(b => new { b.BookId, b.BorrowerId });


            modelBuilder.Entity<Movie>()
                .HasMany(movie => movie.Borrowers)
                .WithOne(borrower => borrower.Movie)
                .HasForeignKey(b => b.MovieId);

            modelBuilder.Entity<Borrower>()
                .HasMany(borrower => borrower.BorrowersMovies)
                .WithOne(movie => movie.Borrower)
                .HasForeignKey(b => b.BorrowerId);

            modelBuilder.Entity<BorrowersMovies>()
                .HasKey(m => new { m.MovieId, m.BorrowerId });

            //we create a unique Username
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
                


            base.OnModelCreating(modelBuilder);
        }
    }
}
