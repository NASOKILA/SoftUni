using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piramida_ot_chisla
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int counter = 1;

            for (int row = 1;row <= n ; row++)
            {
                for (var col = 1; col <= row; col++)
                {
                    
                    Console.Write(counter); Console.Write(" ");
                    counter++;
                    if (counter > n) { break; }

                }                                
              Console.WriteLine();
                if (counter > n) {break; }
            }

        }
    }
}
