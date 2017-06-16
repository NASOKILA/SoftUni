using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ShortWordsSorted
{
    class ShortWordsSorted
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine()
                .Split(new char[] { '.', ',', ':', ';','(',')','[',']','"','\'','/','\\','!','?',' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

          // text = text.Select(a => a.ToLower()).Distinct().ToList();
            Console.WriteLine(string.Join(", ", text
                .Select(a => a.ToLower())
                .Distinct()
                .Where(c => c.Count() < 5)
                .OrderBy(a => a)
                .ToList()));

        }
    }
}
