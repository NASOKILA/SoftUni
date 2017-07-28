using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_0._._._9_to_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 0) { Console.WriteLine("zero"); }
            if(n == 1) { Console.WriteLine("one"); }
            if (n == 2) { Console.WriteLine("two"); }
            if (n == 3) { Console.WriteLine("three"); }
            if (n == 4) { Console.WriteLine("four"); }
            if (n == 5) { Console.WriteLine("five"); }
            if (n == 6) { Console.WriteLine("six"); }
            if (n == 7) { Console.WriteLine("seven"); }
            if (n == 8) { Console.WriteLine("eight"); }
            if (n == 9) { Console.WriteLine("nine"); }
            else if (n>9){ Console.WriteLine("number too big"); }

        }
    }
}
