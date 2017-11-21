namespace P03_SalesDatabase.Data.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Product
    {
        public Product()
        {
            this.Sales = new List<Sale>();
        }

        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        //Tova e ot zdacha 4
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
