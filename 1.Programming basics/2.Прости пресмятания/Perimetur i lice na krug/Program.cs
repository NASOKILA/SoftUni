using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perimetur_i_lice_na_krug
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = double.Parse(Console.ReadLine());
            var area = Math.PI * r * r;
            Console.WriteLine("Area = " + area);
            var perimeter = 2 * Math.PI * r;
            Console.WriteLine("Perimeter = " + perimeter);

        }
    }
}
