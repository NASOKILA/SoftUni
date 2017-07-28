using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obrushtenie_spored_vuzrast_i_pol
{
    class Program
    {
        static void Main(string[] args)
        {

            // zadacha: obrushtenie spored vuzrast i pol

            double age = double.Parse(Console.ReadLine());
            string genter = Console.ReadLine();

            if (age >= 16)
            {
                if (genter == "m")
                {
                    Console.WriteLine("Mr.");
                }
                else if (genter == "f")
                {
                    Console.WriteLine("Ms.");
                }
                else
                {
                    Console.WriteLine("Error! Must input  m  or  f  !");
                }

            }
            else
            {
                if (genter == "m")
                {
                    Console.WriteLine("Master");
                }
                else if (genter == "f")
                {
                    Console.WriteLine("Miss");
                }
                else
                {
                    Console.WriteLine("Error! Must input  m  or  f  !");
                }


            }
        }
    }
}
