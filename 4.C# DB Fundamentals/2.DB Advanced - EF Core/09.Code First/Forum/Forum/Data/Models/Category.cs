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


        //Vsqka kategoriq trqbva da ima edin ili poveche postove
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //Tova sa vsichki postove ZA TAQ KATEGORIQ
        public ICollection<Post> Posts { get; set; }

    }
}
