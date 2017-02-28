using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chisla_ot_1_do_100_zavurshvashti_na_7
{
    class Program
    {
        static void Main(string[] args)
        {

            for (var i = 1; i <= 1000; i++)
            {
                // edno chislo zavurshva na 7 ako   chislo % 10 = 7
                if (i % 10 == 7)  
                {
                    Console.WriteLine(i);
                }
            }

        }
    }
}
