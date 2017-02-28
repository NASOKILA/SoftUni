using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Characters_and_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Be sure that each value is stored in the correct variable. 
              Finally, you need to print all variables to the console.*/

            string s1 = "Software";
            string s11 = "University";

            char ch1 = (char)66;  // tova e    B    po shesnaisetichna b.s.
            char ch2 = (char)121;  // tova e    y   po shesnaisetichna b.s.
            char ch3 = (char)101;  // tova e    e    po shesnaisetichna b.s.

            string s21 = "I";
            string s22 = "love";
            string s23 = "programming";

            Console.WriteLine($"{s1} {s11}");  // nachin na vizualizirane s   $ 
            Console.WriteLine(ch1);
            Console.WriteLine(ch2);
            Console.WriteLine(ch3);
            Console.WriteLine("{0} {1} {2}",s21,s22,s23);  // nachin na vizualizirane s placeholderi !


        }
    }
}
