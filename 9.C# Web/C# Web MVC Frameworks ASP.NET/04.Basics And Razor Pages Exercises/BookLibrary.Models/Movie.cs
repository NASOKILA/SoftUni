using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Movie
    {

        public Movie()
        {
            this.Borrowers = new List<BorrowersMovies>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string CoverImage { get; set; }

        public string Status { get; set; }

        [Required]
        public int DirectorId { get; set; }

        public Director Director { get; set; }

        public ICollection<BorrowersMovies> Borrowers { get; set; }
    }
}
