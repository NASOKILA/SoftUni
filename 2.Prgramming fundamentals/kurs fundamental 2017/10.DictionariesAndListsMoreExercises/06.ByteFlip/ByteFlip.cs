using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ByteFlip
{
    class ByteFlip
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(' ')
                .Where(n => n.Length == 2)
                .ToList();

            list.Reverse();
            
            foreach (var elem in list)
            {
                // we reverse everi element one by one
                string reversedElem = new string(elem.ToCharArray().Reverse().ToArray());
                // we convert from hex to char 
                char ch = (char)Int16.Parse(reversedElem, NumberStyles.AllowHexSpecifier);
                // print the result
                Console.Write(ch);
            }
            Console.WriteLine();
        }
    }
}
