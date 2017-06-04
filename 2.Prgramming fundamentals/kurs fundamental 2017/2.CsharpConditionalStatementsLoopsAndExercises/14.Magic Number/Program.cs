using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Magic_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            char firstInput = char.Parse(Console.ReadLine());
            char secondInput = char.Parse(Console.ReadLine());
            char thirdInput = char.Parse(Console.ReadLine());

            string result = string.Empty;

            for (char i = firstInput; i <= secondInput; i++)
            {
                for (char j = firstInput; j <= secondInput; j++)
                {
                    for (char h = firstInput; h <= secondInput; h++)
                    {
                        result = result + Convert.ToChar(i) + Convert.ToChar(j) + Convert.ToChar(h);
                        if (!result.Contains(thirdInput))
                        Console.Write(result + " ");
                        result = string.Empty;
                    }
                }
            }
        }
    }
}
