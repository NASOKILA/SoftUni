using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ').Select(int.Parse).ToList();

            int index = int.Parse(Console.ReadLine());

            decimal sumOfAllRemovedElements = 0;

            while (true)
            {
                if (index < 0)
                {
                    int first = numbers.First();
                    int last = numbers.Last();
                    int value = first;
                    numbers.RemoveAt(0);
                    numbers.Insert(0, last);

                    sumOfAllRemovedElements += value;


                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= value)
                        {
                            numbers[i] = numbers[i] + value;
                        }
                        else
                            numbers[i] = numbers[i] - value;
                    }


                }
                else if (index > numbers.Count - 1)
                {
                    int first = numbers.First();
                    int last = numbers.Last();
                    int value = last;
                    numbers.RemoveAt(numbers.Count - 1);
                    numbers.Add(first);



                    sumOfAllRemovedElements += value;
                    

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= value)
                        {
                            numbers[i] = numbers[i] + value;
                        }
                        else
                            numbers[i] = numbers[i] - value;
                    }



                }
                else
                {
                    int value = numbers[index];

                    sumOfAllRemovedElements += value;
                    numbers.RemoveAt(index);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= value)
                        {
                            numbers[i] = numbers[i] + value;
                        }
                        else
                            numbers[i] = numbers[i] - value;
                    }
                    
                }
                
                if (numbers.Count == 0)
                    break;

                index = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(sumOfAllRemovedElements);

        }
    }
}
