using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SortTimes
{
    class SortTimes
    {
        static void Main(string[] args)
        {

            List<TimeSpan> dates = Console.ReadLine()
                .Split(' ')
                .Select(TimeSpan.Parse)           
                .ToList();

           var result =  dates.OrderBy(a => a).ToList();
            List<string> res = new List<string>();

            foreach (var item in result)
            {
                string time = item.ToString();
                time = time.Substring(0, time.Length - 3);
                res.Add(time);
            }
            Console.WriteLine(string.Join(", " ,res));
            
        }
    }
}
