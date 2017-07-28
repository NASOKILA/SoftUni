using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {

            string copyNum = string.Empty;
            try
            {
                string num = Console.ReadLine();
                copyNum = num;
                long n = long.Parse(num);

                List<string> result = new List<string>();


                if (n >= -128 && n <= 127)
                {
                    result.Add("sbyte");
                }
                if (n >= 0 && n <= 255)
                {
                    result.Add("byte");
                }
                if (n >= -32768 && n <= 32767)
                {
                    result.Add("short");
                }
                if (n >= 0 && n <= 65535)
                {
                    result.Add("ushort");
                }
                if (n >= -2147483648 && n <= 2147483647)
                {
                    result.Add("int");
                }
                if (n >= 0 && n <= 4294967295)
                {
                    result.Add("uint");
                }
                if (n >= -9223372036854755808 && n <= 9223372036854755807)
                {
                    result.Add("long");
                }



                if (result.Count.Equals(0))
                    Console.WriteLine($"{n} can't fit in any type");
                else
                {

                    Console.WriteLine($"{n} can fit in:");
                    for (int i = 0; i < result.Count; i++)
                    {
                        Console.WriteLine("* " + result[i]);
                    }
                }
            }
            catch
            {
                Console.WriteLine($"{copyNum} can't fit in any type");
            }


        }
    }
}
