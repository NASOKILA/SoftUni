﻿namespace HTTPServer.ByTheCakeApplication.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {

        public Product()
        {
            this.Orders = new List<ProductOrder>();
        }

        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)] // taka mu kazvame che tova e pari
        public decimal Price { get; set; }

        [StringLength(2048, MinimumLength = 0)]
        public string ImageUrl { get; set; }

        public ICollection<ProductOrder> Orders { get; set; }
        
    }
}
