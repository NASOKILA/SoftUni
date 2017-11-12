using System;
using System.Collections.Generic;

namespace IntroDotNetCoreEF.Data.Models
{
    //mahame partial
    public class Town
    {
        public Town()
        {
            //ostavqme go prazno
        }

        public int TownId { get; set; }
        public string Name { get; set; }

        //dobvqme si spisuka
        public ICollection<Address> Addresses { get; set; }
        = new List<Address>();
    }
}
