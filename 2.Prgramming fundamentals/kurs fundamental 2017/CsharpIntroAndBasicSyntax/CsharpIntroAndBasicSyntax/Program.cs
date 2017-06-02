using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpIntroAndBasicSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vuvedi ime:");
            var name = Console.ReadLine();

            Console.WriteLine($"Your name is {name}");
        }
    }
}
