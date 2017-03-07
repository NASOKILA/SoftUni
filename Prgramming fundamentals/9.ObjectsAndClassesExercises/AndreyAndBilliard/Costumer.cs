using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreyAndBilliard
{
    public class Costumer
    {
        public string Name { set; get; }
        public Dictionary<string, int> BougthProductAndQuantity { set; get; }
        public decimal Bill { set; get; }

    }
}
