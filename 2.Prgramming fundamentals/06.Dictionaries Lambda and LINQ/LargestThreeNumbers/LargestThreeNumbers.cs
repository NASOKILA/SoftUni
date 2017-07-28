using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestThreeNumbers
{
    class LargestThreeNumbers
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ')
                .Select(n => int.Parse(n))
                .OrderByDescending(x => x)
                .ToArray();

            byte nTimes = 3;
            if (nums.Length < nTimes) { nTimes = (byte)nums.Length; }

           var result = nums.Take(nTimes);
            Console.WriteLine(string.Join(" ",result));

            // TOVA MOJE DA STANE SAMO NA EDIN RED sus samo edna promenliva
        }
    }
}
