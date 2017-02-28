using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triugulnik_ot_dolari
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            //TAKA STAVA SAMOCHE NQMA KAK DA SLOJIM RAZSTOQNIQ MEJDU DOLARCHETATA

            //for (int i = 0; i <= num; i++)
            //{
            //    var test1 = new string('$', i);
            //    Console.WriteLine(test1);
            //}

            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < i+1; j++)
                {
                    Console.Write("$ ");

                }
                Console.WriteLine(" ");
            }

        }
    }
}
