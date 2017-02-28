using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nai_golqm_obsh_delitel
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());  

            while (b != 0) {

                var temp = b;
                b = a % b;
                a = temp; 

            }
            Console.WriteLine(a); // greater common divider se sabira v   a

        }
    }
}
