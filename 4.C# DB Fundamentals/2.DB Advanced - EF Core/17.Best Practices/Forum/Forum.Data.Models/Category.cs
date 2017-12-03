using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum.Data.Models
{
    public class Category
    {
        public Category()
        {

        }

        public Category(string name)
        {
            this.Name = name;
        }

        
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
