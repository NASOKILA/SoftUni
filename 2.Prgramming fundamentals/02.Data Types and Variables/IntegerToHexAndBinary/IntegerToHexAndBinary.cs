using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerToHexAndBinary
{
   public class IntegerToHexAndBinary
    {
        public static void Main(string[] args)
        {
            short n = short.Parse(Console.ReadLine());

            string nHex = Convert.ToString(n, 16).ToUpper();
            Console.WriteLine(nHex);

            string nBinary = Convert.ToString(n, 2);  // we dont need to upper because it returns a string of numbers !
            Console.WriteLine(nBinary);
        }
    }
}
