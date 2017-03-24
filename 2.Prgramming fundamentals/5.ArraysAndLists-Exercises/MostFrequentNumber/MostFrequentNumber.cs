using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostFrequentNumber
{
    class MostFrequentNumber
    {
        static void Main(string[] args)
        {

            /* ALL INTEGER TYPE : varirat ot  -2 miliarda do 2 miliarda   
            sbyte [-128,...127] 8 bit
            byte [0,...255] unshort 8 bit
            short [-32 768,... 32 767] 16 bit
            ushort [0,...65 535] unshort 16 bit
            int [-2 147 483 648,...2 147 483 647] 32 bit
            uint[0,...4 294 967 295] unshort 32 bit
            long[-9 223 372 036 854 755 808,...9 223 372 036 854 755 807] unshort 64 bit
            undlong[0...18 446 744 073 709 551 615] 64 bit*/

            ushort[] array = Console.ReadLine().Split(' ').Select(ushort.Parse).ToArray();

            var query = (from item in array
                         group item by item into g
                         orderby g.Count() descending
                         select g.Key).First();

            Console.WriteLine(query);

        }
    }
}
