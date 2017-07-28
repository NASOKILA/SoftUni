using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_6_Bitki
{
    class Program
    {
        static void Main(string[] args)
        {

            int broiPokemoniNaPurviIgrach = int.Parse(Console.ReadLine());
            int broiPokemoniNaVtoriIgrach = int.Parse(Console.ReadLine());
            int MaxBitki = int.Parse(Console.ReadLine());

            int counter = 0;
            for (int i = 1; i <= broiPokemoniNaPurviIgrach; i++)
            {
                for (int j = 1; j <= broiPokemoniNaVtoriIgrach; j++)
                {
                    if (counter == MaxBitki) { break; }
                    Console.Write("(" + i + " <-> " + j + ") ");
                    counter++;
                }
                if (counter == MaxBitki) { break; }
            }
        }
    }
}
