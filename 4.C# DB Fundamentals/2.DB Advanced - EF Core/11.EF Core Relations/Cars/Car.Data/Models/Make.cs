namespace Car.Data.Models
{

    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Make
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
            = new List<Car>();
    }
}
