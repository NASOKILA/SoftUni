using System;
using System.ComponentModel.DataAnnotations;

namespace HTTPServer.GameStoreApplication.Models
{
    public class Game
    {
        public Game()
        {   
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Trailer { get; set; }

        [Required]
        public string ImageThumbnail { get; set; }

        [Required]
        public decimal Size { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public User Creator { get; set; }

        public int CreatorId { get; set; }

    }
}