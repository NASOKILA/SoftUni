using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageQuit
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            string[] splitter = { "0","1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
          

           
            string input = Console.ReadLine().ToUpper();

            string[] letters = input.Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int[] numbers = input.Split(letters, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<string> charachtersCount = new List<string>();

            for (int i = 0; i < letters.Length; i++)
            {
                foreach (var charachter in letters[i])
                {                   
                        if (!charachtersCount.Contains(charachter.ToString()))  // ako ne sudurja tazi bukva q dobavi
                            charachtersCount.Add(charachter.ToString());
                }
            }

            Console.WriteLine("Unique symbols used: {0}", charachtersCount.Count);

            byte counter = 0;
            foreach (var letter in letters)
            {
                for (int i = 0; i < numbers[counter]; i++)
                {
                    Console.Write(letter);
                    
                }
                counter++;
            }


        }
    }
}
