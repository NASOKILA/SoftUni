using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.CameraView
{
    class CameraView
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ').Select(int.Parse).ToArray();

            int elementsToSkip = input[0];
            int elementsToTake = input[1];

            string cameras = Console.ReadLine();

            string patt = @"\|<\w+";

            Regex reg = new Regex(patt);

            MatchCollection matches = reg.Matches(cameras);

            List<string> results = new List<string>();

            foreach (var item in matches)
            {
                
                char[] resultElements = item
                    .ToString()
                    .ToCharArray()
                    .Skip(elementsToSkip+2)
                    .Take(elementsToTake)
                    .ToArray();

                string result = new string(resultElements);
                results.Add(result);
                             
            }

            Console.WriteLine(string.Join(", ", results));
        }
    }
}
