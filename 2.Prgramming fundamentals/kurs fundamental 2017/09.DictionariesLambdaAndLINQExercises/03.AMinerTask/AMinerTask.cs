using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Dictionary<string, int> resoursesQuantities = new Dictionary<string, int>();

            int counter = 1;
            string prevInput = string.Empty;

            while (input != "stop")
            {

                if (counter % 2 == 1)
                {
                    if (!resoursesQuantities.ContainsKey(input))
                        resoursesQuantities[input] = 0;
                }
                else
                {
                    resoursesQuantities[prevInput] += int.Parse(input);
                }

                prevInput = input;

                counter++;
                input = Console.ReadLine();
            }

            foreach (var resourseQuantity in resoursesQuantities)
            {
                // IZVEJDAI GI V PROMENLIVI ZA DA E PO QSNO !!!
                var resourse = resourseQuantity.Key;
                var quantity = resourseQuantity.Value;
                Console.WriteLine($"{resourse} -> {quantity}");
            }

        }
    }
}
