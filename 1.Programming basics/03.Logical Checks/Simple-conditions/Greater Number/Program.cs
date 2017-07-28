using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greater_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            var n = double.Parse(Console.ReadLine());
            var n2 = double.Parse(Console.ReadLine());

            if (n > n2)
            {
                Console.WriteLine(n);
            }
            else {
                Console.WriteLine(n2);
            }
        }
    }
}
