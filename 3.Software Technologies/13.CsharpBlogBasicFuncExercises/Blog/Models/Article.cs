using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
       
        public string ImagePath { get; set;}

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        // Proverqvame dali daden user e avtor na artikula
        // ima i druga funkciq koqto otiva v kontrolera
        public bool IsAuthor(string name) {
            return this.Author.UserName.Equals(name);
        }


    }
}
