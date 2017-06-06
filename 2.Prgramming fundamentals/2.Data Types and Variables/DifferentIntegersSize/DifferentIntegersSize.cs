using System;
using System.Collections.Generic;

namespace DifferentIntegersSize
{
   public class DifferentIntegersSize
    {
        public static void Main(string[] args)
        {
            string num = Console.ReadLine();
            try
            {

                long n = long.Parse(num);

                List<string> result = new List<string>();


                if (n >= sbyte.MinValue && n <= sbyte.MaxValue)
                {
                    result.Add("sbyte");
                }
                if (n >= byte.MinValue && n <= byte.MaxValue)
                {
                    result.Add("byte");
                }
                if (n >= short.MinValue && n <= short.MaxValue)
                {
                    result.Add("short");
                }
                if (n >= ushort.MinValue && n <= ushort.MaxValue)
                {
                    result.Add("ushort");
                }
                if (n >= int.MinValue && n <= int.MaxValue)
                {
                    result.Add("int");
                }
                if (n >= uint.MinValue && n <= uint.MaxValue)
                {
                    result.Add("uint");
                }
                if (n >= long.MinValue && n <= long.MaxValue)
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
                Console.WriteLine($"{num} can't fit in any type");
            }

        }
    }
}
