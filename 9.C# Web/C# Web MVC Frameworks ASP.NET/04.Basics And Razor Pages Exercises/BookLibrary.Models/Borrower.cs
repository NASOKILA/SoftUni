using System.Collections.Generic;

namespace BookLibrary.Models
{
    public class Borrower
    {
        public Borrower()
        {
            this.BorrowedBooks = new List<BorrowersBooks>();
            this.BorrowersMovies = new List<BorrowersMovies>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<BorrowersBooks> BorrowedBooks { get; set; }

        public ICollection<BorrowersMovies> BorrowersMovies { get; set; }
    }
}
