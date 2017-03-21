using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulator2
{
    class ArrayManipulator2
    {
        static void Main(string[] args)
        {

            List<int> list = Console.ReadLine().ToLower()
                .Split(' ').Select(int.Parse)
                .ToList();

            string command = Console.ReadLine().ToLower();
            while (!command.Equals("end"))
            {

                string[] userInput = command.Split(' ').ToArray();


                switch (userInput[0])
                {
                    case "exchange":
                        list = ExecuteExchange(list, userInput);
                        break;
                    case "max":
                        GetMaxIndex(list, userInput);
                        break;
                    case "min":
                        GetMinIndex(list, userInput);
                        break;
                    case "first":
                        GetFirst(list, userInput);
                        break;
                    case "last":
                        GetLast(list, userInput);
                        break;
                    default:
                        break;
                }


                command = Console.ReadLine();

            }


            Console.WriteLine($"[{string.Join(", ",list)}]");

        }

        private static void GetLast(List<int> list, string[] userInput)
        {
            List<int> temp = new List<int>();
            string type = userInput[2];
            int remainder = type == "even" ? 0 : 1;   // ako e "even" znachi 0, inache 1
            int count = int.Parse(userInput[1]);

            if (count > list.Count)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            temp.AddRange(list.Where(x => x % 2 == remainder).Reverse().Take(count).Reverse());
            Console.WriteLine($"[{string.Join(", ", temp)}]");

        }

        private static void GetFirst(List<int> list, string[] userInput)
        {
            List<int> temp = new List<int>();

            string type = userInput[2];
            int remainder = type == "even" ? 0 : 1;   // ako e "even" znachi 0, inache 1
            int count = int.Parse(userInput[1]);

            if (count > list.Count)
            {
                Console.WriteLine("Invalid count");
                return;
            }


            int counter = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i] % 2 == remainder && temp.Count < count)
            
                temp.Add(list[i]);
                counter++;
            }

            Console.WriteLine($"[{string.Join(", ", temp)}]");
        }

        private static void GetMinIndex(List<int> list, string[] userInput)
        {
            string type = userInput[1];

            if (type == "even")
            {
                var filtered = list.Where(x => Math.Abs(x) % 2 == 0);
                if (filtered.Count() > 0)
                {
                    int min = filtered.Min();// namirame minimalnoto chislo
                    int minIndex = list.LastIndexOf(min);// vzimame indexsa na minimalnoto chislo
                    Console.WriteLine(minIndex);
                }
                else
                {
                    Console.WriteLine("No matches");
                }

            }
            else if (type == "odd")
            {
                var filtered = list.Where(x => Math.Abs(x) % 2 == 1);
                if (filtered.Count() > 0)
                {
                    int min = filtered.Min();// namirame minimalnoto chislo
                    int minIndex = list.LastIndexOf(min);// vzimame indexsa na minimalnoto chislo
                    Console.WriteLine(minIndex);
                }
                else
                {
                    Console.WriteLine("No matches");    
                }

            }
           
        }

        private static void GetMaxIndex(List<int> list, string[] userInput) 
        {
            string type = userInput[1];
            if (type == "even")
            {
                var filtered = list.Where(x => Math.Abs(x) % 2 == 0);
                if (filtered.Count() > 0)
                {
                    int max = filtered.Max();// namirame minimalnoto chislo
                    int maxIndex = list.LastIndexOf(max);// vzimame indexsa na minimalnoto chislo
                    Console.WriteLine(maxIndex);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
            else if(type == "odd")
            {
                var filtered = list.Where(x => Math.Abs(x) % 2 == 1);
                if (filtered.Count() > 0)
                {
                    int max = filtered.Max();// namirame minimalnoto chislo
                    int maxIndex = list.LastIndexOf(max);// vzimame indexsa na minimalnoto chislo
                    Console.WriteLine(maxIndex);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
        }

        private static List<int> ExecuteExchange(List<int> array, string[] userInput)
        {
            int index = int.Parse(userInput[1]);

            if (index < 0 || array.Count <= index)
            {
                Console.WriteLine("Invalid index");
            }


            List<int> temp = array.Skip(index + 1).ToList();
            temp.AddRange(array.Take(index+1));
           
            return temp;
        }
    }
}
