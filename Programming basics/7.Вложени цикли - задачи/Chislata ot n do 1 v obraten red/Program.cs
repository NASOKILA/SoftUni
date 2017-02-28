using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chislata_ot_n_do_1_v_obraten_red
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            while (true)
            {
                Console.WriteLine(n);
                n--;
                if (n == 0) { break; }
            }



        }
    }
}
