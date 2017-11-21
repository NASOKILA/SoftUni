namespace P03_SalesDatabase.Data.Models
{

    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Sale
    {
        public Sale()
        {

        }

        public int SaleId { get; set; }

        public DateTime Date { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public int StoreID { get; set; }
        public Stores Store { get; set; }
    }
}
