using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chislata_ot_1_do_n_prez_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            int count = 1;
            Console.WriteLine("The numbers are:");
            while (count<=n)         //for (var i = 1; i <= n; i+=3){}  i tak stava
            {
                Console.WriteLine(count);
                count += 3;
            }
      
        }
    }
}
