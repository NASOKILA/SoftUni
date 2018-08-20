using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Director
    {

        public Director()
        {
            this.Movies = new List<Movie>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
