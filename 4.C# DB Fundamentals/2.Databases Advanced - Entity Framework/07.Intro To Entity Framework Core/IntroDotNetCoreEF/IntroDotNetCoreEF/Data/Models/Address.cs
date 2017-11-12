using System;
using System.Collections.Generic;

namespace IntroDotNetCoreEF.Data.Models
{
    //Mahame partial
    public class Address
    {
        public Address()
        {
            //Ostavqme go prazno
        }

        public int AddressId { get; set; }
        public string AddressText { get; set; }
        public int? TownId { get; set; }

        public Town Town { get; set; }

        //Dobavqme si spiuka
        public ICollection<Employee> Employees { get; set; }
         = new List<Employee>();
    }
}
