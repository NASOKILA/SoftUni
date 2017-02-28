using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sumirane_na_chisla
{
    class Program
    {
        static void Main(string[] args)
        {

            int nomerNaChisla = int.Parse(Console.ReadLine());
            var suma = 0;
            for (var i = 1; i <= nomerNaChisla; i++) {
                int nomer = int.Parse(Console.ReadLine());
                suma = suma + nomer;
            }

            Console.WriteLine(suma);
        }
    }
}
