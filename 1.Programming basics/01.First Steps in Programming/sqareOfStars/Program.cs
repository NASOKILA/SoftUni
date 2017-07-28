using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqareOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());


            for (var i = 1; i <= a; i++)
            {
                Console.Write("*");
            }

            Console.WriteLine("");




            for (var u = 0; u <= a - 3; u++)
            {

                Console.Write("*");

                for (var ii = 0; ii <= a - 3; ii++)
                {

                    Console.Write(" ");
                }

                Console.Write("*");
                Console.WriteLine("");

            }





            for (var iii = 1; iii <= a; iii++)
            {
                Console.Write("*");
            }
        }
    }
}
