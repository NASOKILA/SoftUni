namespace HTTPServer.GameStoreApplication.Models
{
    using HTTPServer.ByTheCakeApplication.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class User
    {

        public User()
        {
            this.Games = new List<Game>();
            this.IsAdmin = false;
        }

        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }
        
        public ICollection<Game> Games { get; set; }

        public bool IsAdmin { get; set; }
    }
}
