using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.BombNumbers
{
    class BombNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            int[] bomb = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int detonator = bomb[0];
            int power = bomb[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == detonator)
                {
                    int indexOfDetonator = numbers.IndexOf(detonator);

                    // explosion left
                    for (int j = indexOfDetonator-1; j >= indexOfDetonator - power; j--)
                    {
                        if (j < 0)
                            break;
                        numbers.RemoveAt(j);
                    }

                    // explosion right
                    int counter = 0;
                    int index = numbers.IndexOf(detonator) + 1;
                    while(counter < power)
                    {
                        if (index >= numbers.Count)
                            break;
                        numbers.RemoveAt(index);
                        counter++;
                    }
                    numbers.Remove(detonator);
                }

            }

            Console.WriteLine(numbers.Sum());

        }
    }
}
