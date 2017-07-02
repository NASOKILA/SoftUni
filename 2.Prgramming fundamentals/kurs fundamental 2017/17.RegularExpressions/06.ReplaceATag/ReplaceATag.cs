using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.ReplaceATag
{
    class ReplaceATag
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"<a.*?href.*?=(.*)>(.*?)</a>";
            string replacement = @"[URL href=$1]$2[/URL]";

            Regex regex = new Regex(pattern);
            List<string> res = new List<string>();
            while (input != "end")
            {
                var result = regex.Replace(input, replacement);
                res.Add(result);
                input = Console.ReadLine();
            }

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
    }
}
