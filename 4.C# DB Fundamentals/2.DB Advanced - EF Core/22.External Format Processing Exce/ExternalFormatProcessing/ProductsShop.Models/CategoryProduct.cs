namespace ProductsShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CategoryProduct
    {
        public CategoryProduct()
        {}

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
        
    }
}
