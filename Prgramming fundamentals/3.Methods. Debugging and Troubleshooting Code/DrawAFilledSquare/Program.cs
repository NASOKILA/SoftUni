using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawAFilledSquare
{
    class Program
    {

        static void PrintHeaderRow(int n) {
            Console.WriteLine(new string('-', n*2));  // da printira  '-' n*2 puti
        }

        static void PrintMiddleRow(int n) {
            

            for (int i = 0; i < n-2; i++)
            {
                Console.Write("-");
                for (int j = 0; j < n - 1; j++)
                {
                    Console.Write("\\");
                    Console.Write("/");

                }
                Console.WriteLine("-");
                
            }            
         
        }

        static void PrintLastRow(int n)
        {
            Console.WriteLine(new string('-', n * 2));  // da printira  '-' n*2 puti
        }


        static void DrawSquare(int n) {
            PrintHeaderRow(n);
            PrintMiddleRow(n);
            PrintLastRow(n);
        }


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            DrawSquare(n);
        }
    }
}
