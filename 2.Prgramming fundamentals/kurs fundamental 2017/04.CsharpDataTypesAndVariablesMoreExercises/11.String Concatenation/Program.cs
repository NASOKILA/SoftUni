using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.String_Concatenation
{
    class Program
    {
        static void Main(string[] args)
        {

            char delimeter = char.Parse(Console.ReadLine());
            string oddOrEven = Console.ReadLine();
            int numberOfLines = int.Parse(Console.ReadLine());
            string stringToUse = string.Empty;
            List<string> listOfStrings = new List<string>();
            
            
            for (int i = 1; i <= numberOfLines; i++)
            {

                stringToUse = Console.ReadLine();

                if (oddOrEven.Equals("odd"))
                {
                    if (i % 2 == 1)
                    {
                        listOfStrings.Add(stringToUse);
                    }
                }
                else if (oddOrEven.Equals("even"))
                {
                    if (i % 2 == 0)
                    {
                        listOfStrings.Add(stringToUse);
                    }
                }

            }

            


            string result = string.Empty;
            foreach (var item in listOfStrings)
            {

                result += item;
                result += delimeter;         
            }

            result = result.Remove(result.Length-1);
            Console.WriteLine(result);
        }
    }
}
