namespace ProductsShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Product
    {
        public Product()
        {}

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public User Buyer { get; set; }
        public int? BuyerId { get; set; }

        public User Seller { get; set; }
        public int SellerId { get; set; }

        public ICollection<CategoryProduct> CategoriesProducts { get; set; }
            = new HashSet<CategoryProduct>();

    }
}
