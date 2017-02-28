using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablica_s_chisla
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var num = 0;
          

            for (int row = 1; row <= n; row++) // da se izpulni n puti
            {
                for (int col = 1; col<=n; col++)  // da se izpulni n puti
                {
                   
                    num = row + col - 1;
                    if (num == n + 1) { num = num - 2; }
                    if (num == n + 2) { num = num - 4; }
                    if (num == n + 3) { num = num - 6; }
                    if (num == n + 4) { num = num - 8; }

                    if (num == n + 5) { num = num - 10; }
                    if (num == n + 6) { num = num - 12; }
                    if (num == n + 7) { num = num - 14; }
                    if (num == n + 8) { num = num - 16; }

                    if (num == n + 9) { num = num - 18; }
                    if (num == n + 10) { num = num - 20; }
                    if (num == n + 11) { num = num - 22; }
                    if (num == n + 12) { num = num - 24; }

                    if (num == n + 13) { num = num - 26; }
                    if (num == n + 14) { num = num - 28; }
                    if (num == n + 15) { num = num - 30; }
                    if (num == n + 16) { num = num - 32; }

                    if (num == n + 17) { num = num - 34; }
                    if (num == n + 18) { num = num - 36; }
                    if (num == n + 19) { num = num - 38; }
                    if (num == n + 20) { num = num - 40; }
                    if (num == n + 21) { num = num - 42; }

                    Console.Write(num); Console.Write(" ");

                    
                }
                Console.WriteLine();
                // tazi formula ne q izpolzvahme   !!!    num = 2 * n - num;
                

            }
        }
    }
}
