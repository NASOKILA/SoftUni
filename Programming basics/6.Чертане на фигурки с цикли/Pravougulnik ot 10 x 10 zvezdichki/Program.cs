using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pravougulnik_ot_10_x_10_zvezdichki
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 10; i++)
            {
                var test = new string('*',10);
                Console.WriteLine(test);
            }

            Console.WriteLine("");

            //Moje i po sledniq nachin s vlojeni cikli

            for (int i = 0; i < 10; i++)
            {
                for (int J = 0; J < 10; J++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
        }
    }
}
