using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_integers
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Put the following numbers in the right integer format : 
            -100
            128
            -3540
            64876
            2147483648
            -1141583228
            -1223372036854775808*/


            sbyte n1 = -100;
            byte n2 = 128;
            short n3 = -3540;
             int n4 = 64876;    // trqbva da e unshort no go nqma 
            uint n5 = 2147483648;
            int n6 = -1141583228;
            long n7 = -1223372036854775808;

            Console.WriteLine(n1);
            Console.WriteLine(n2);
            Console.WriteLine(n3);
            Console.WriteLine(n4);
            Console.WriteLine(n5);
            Console.WriteLine(n6);
            Console.WriteLine(n7);
        }
    }
}
