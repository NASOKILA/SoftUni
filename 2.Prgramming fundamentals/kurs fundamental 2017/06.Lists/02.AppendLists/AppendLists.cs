using System;
using System.Collections.Generic;
using System.Linq;


namespace _02.AppendLists
{
    class AppendLists
    {
        static void Main(string[] args)
        {

            List<string> lists = Console.ReadLine()
                .Split('|')
                .ToList();

            List<string> result = new List<string>();
            lists.Reverse();


            foreach (var item in lists)
            {
                List<string> newList = item
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                result.AddRange(newList);

            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
