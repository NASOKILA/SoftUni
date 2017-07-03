using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Hideout
{
    class Hideout
    {
        static void Main(string[] args)
        {
            string map = Console.ReadLine();

            while (true)
            {
                string[] array = Console.ReadLine().Split(' ').ToArray();

                char searchedChar = Convert.ToChar(array[0]);

                int minimumCountToSearch = int.Parse(array[1]);
   
                string search = new string(searchedChar, minimumCountToSearch);

                if (map.Contains(search))
                {
                    int startIndex = map.IndexOf(search);
                    int size = 0;
                    for (int i = startIndex; i < map.Length; i++)
                    {
                        if (map[i] == searchedChar)
                            size++;
                        else
                            break;
                    }

                    Console.WriteLine($"Hideout found at index {startIndex} and it is with size {size}!");
                    break;
                }


            }
        }
    }
}
