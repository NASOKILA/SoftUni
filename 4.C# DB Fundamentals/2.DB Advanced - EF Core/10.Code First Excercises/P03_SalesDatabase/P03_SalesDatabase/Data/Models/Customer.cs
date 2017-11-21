namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {

        public Customer()
        {
            this.Sales = new List<Sale>();
        }

        [Key]
        public int CustomerId { get; set; }

        public string CreditCardnumber { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }

    }
}
