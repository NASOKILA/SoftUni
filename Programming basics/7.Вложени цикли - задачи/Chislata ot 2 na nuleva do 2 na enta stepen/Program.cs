using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chislata_ot_2_na_nuleva_do_2_na_enta_stepen
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int num = 1;
            int counter =0;

            while (counter <=n)
            {
                Console.WriteLine(num);
                num = num * 2;
            
                counter++;

            }




        }
    }
}
