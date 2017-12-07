namespace ProductsShop.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {

        public User()
        {}

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte? Age { get; set; }

        public ICollection<Product> ProductsBought { get; set; }
            = new HashSet<Product>();

        public ICollection<Product> ProductsSold { get; set; }
            = new HashSet<Product>();

    }
}
