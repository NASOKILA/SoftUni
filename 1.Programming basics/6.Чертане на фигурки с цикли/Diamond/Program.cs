using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            var width = n;           
            if (n % 2 == 0) {                               

                var vutreshniTireta = 0;
                for (int i = 1; i <= n/2; i++)  // gorna chast
                {

                    Console.Write(new string('-', (n / 2) - i));
                    Console.Write("*");                    
                    Console.Write(new string('-', vutreshniTireta));
                    Console.Write("*");
                    Console.WriteLine(new string('-', (n / 2) - i));
                    vutreshniTireta += 2;
                }

                vutreshniTireta = (n / 2) - 2;
                for (int j = (n / 2)-1; j>0;j--) // dolna chast
                {                   
                        Console.Write(new string('-', (n / 2) - j));
                        Console.Write("*");
                        Console.Write(new string('-', 2*j -2));
                        Console.Write("*");
                        Console.WriteLine(new string('-', (n / 2) - j));                                       
                 }
            }
            else if (n % 2 == 1)
            {

                var count = 0;
                var vutreshniTireta = 0;
                for (int i = 1; i <= (n+1) / 2; i++)    // gorna chast na nechetno
                {
                    Console.Write(new string('-', (((n + 1) / 2)-i)));
                    Console.Write("*");
                    Console.Write(new string('-', vutreshniTireta));
                    Console.Write(new string('*', count));
                    Console.WriteLine(new string('-', (((n + 1) / 2) - i)));

                    if (i>1) { vutreshniTireta += 2; } else { vutreshniTireta = i; }
                    count = 1;
                }

                vutreshniTireta = n-4;
                for (int j = ( n-1)/2; j > 0; j--)   // dolna chast na nechetno
                {
                    if (j==1) { count = 0; }
                    if (vutreshniTireta<0){ vutreshniTireta = 0; }
                    Console.Write(new string('-', (((n + 1) / 2) - j)));
                    Console.Write("*");
                    Console.Write(new string('-', vutreshniTireta));  // vutreshni tireta
                    Console.Write(new string('*', count));
                    Console.WriteLine(new string('-', (((n + 1) / 2) - j)));

                    vutreshniTireta -= 2;
                }
              }
           }        
        }
    }

