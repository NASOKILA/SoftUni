using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pravougulnik_NxN_zvezdichki
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }


            // ili po tozi nachin :
            Console.WriteLine("");

            for (int h = 0; h < n; h++) {

                var test = new string('*',n);
                Console.WriteLine(test);
            }

        }
    }
}
