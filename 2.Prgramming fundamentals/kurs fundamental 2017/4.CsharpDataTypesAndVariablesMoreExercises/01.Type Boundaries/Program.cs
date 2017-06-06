using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Type_Boundaries
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataTipe = Console.ReadLine();

            long max = 0;
            long min = 0;
            
            switch (dataTipe)
            {
                case "int":
                    max = int.MaxValue;
                    min = int.MinValue;
                    break;
                case "uint":
                    max = uint.MaxValue;
                    min = uint.MinValue;
                    break;
                case "long":
                    max = long.MaxValue;
                    min = long.MinValue;
                    break;
                case "byte":
                    max = byte.MaxValue;
                    min = byte.MinValue;
                    break;
                case "sbyte":
                    max = sbyte.MaxValue;
                    min = sbyte.MinValue;
                    break;

            }

            Console.WriteLine(max);
            Console.WriteLine(min);

        }
    }
}
