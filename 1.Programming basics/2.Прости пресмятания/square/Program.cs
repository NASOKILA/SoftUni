using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace square
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("set a : ");
            var a = double.Parse(Console.ReadLine());
            var square = Math.Pow(a,2);
            Console.Write("sqare : ");
            Console.WriteLine(square);
        }
    }
}
