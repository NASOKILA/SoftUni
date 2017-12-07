namespace ProductsShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Category
    {
        public Category()
        {}

        public int Id { get; set; }

        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<CategoryProduct> CaegoryProducts { get; set; }
            = new HashSet<CategoryProduct>();
    }
}
