using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAfter5Days
{
    class DateAfter5Days
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            DateTime date = new DateTime(2017,month, day).AddDays(5);

            int newday = date.Day;
            int newmonth = date.Month;
            Console.Write($"{newday}.");

            if (newmonth <= 9)
                Console.Write("0");

            Console.Write($"{newmonth}");
        }
    }
}
