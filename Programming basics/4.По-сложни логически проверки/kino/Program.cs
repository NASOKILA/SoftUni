using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kino
{
    class Program
    {
        static void Main(string[] args)
        {
            string projekciq = Console.ReadLine().ToLower();
            int redove = int.Parse(Console.ReadLine());
            int koloni = int.Parse(Console.ReadLine());
            double result = 0.00;

            if (projekciq == "premiere") {
                result = redove * koloni * 12;
            }
            if (projekciq == "normal")
            {
                result = redove * koloni * 7.5;
            }
            if (projekciq == "discount")
            {
                result = redove * koloni * 5;
            }

            if (result == 0) { Console.WriteLine("error"); }
            else
            {
                Console.WriteLine("{0:f2} leva", result);
            }

            // CTRL + K + T    NI PODREJDA KODA 
        }
    }
}
