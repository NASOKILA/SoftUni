using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chislo_v_diapazon_1_do_100_s_while_cikul
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number in the range [1...100]:");
            int n = int.Parse(Console.ReadLine());            
            

            while (n<1||n>100)
            {
                Console.WriteLine("Invalid number!");
                Console.WriteLine("Enter a number in the range [1...100]:");
                n = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("The number is:{0}", n);
        }
    }
}
