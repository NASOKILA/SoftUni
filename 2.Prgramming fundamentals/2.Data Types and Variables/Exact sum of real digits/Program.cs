using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exact_sum_of_real_digits
{
    class Program
    {
        static void Main(string[] args)
        {

            /*If you use types like float 
            or double, the result will lose some of its precision. Also it might be printed in
            scientific notation.
            You might use the decimal data type which holds real numbers with high precision with less loss.
            Note that decimal numbers sometimes hold the unneeded zeroes after the decimal point, so 0m is
            different than 0.0m and 0.00000m.*/

            int aa = int.Parse(Console.ReadLine());
            decimal sum2 = 0;


            for (int i = 0; i < aa; i++)
            {
                sum2 += decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(sum2); // pokazva ni istinskata suma probvai s double da vidish che e razlichno 
        
    }
    }
}
