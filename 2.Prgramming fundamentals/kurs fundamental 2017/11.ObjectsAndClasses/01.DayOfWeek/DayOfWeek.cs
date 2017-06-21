using System;
using System.Globalization;

namespace _01.DayOfWeek
{
    class DayOfWeek
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string format = "d-M-yyyy";

            var date = DateTime.ParseExact(input, 
                format, 
                CultureInfo.InvariantCulture);

            Console.WriteLine(date.DayOfWeek);

            // STAVA I TAKA: 
            /*
            int day = int.Parse(input.Substring(0,2));
            int month = int.Parse(input.Substring(3, 2));
            int year = int.Parse(input.Substring(6));

            DateTime dayOfWeek = new DateTime(day, month, year);
            

            Console.WriteLine(dayOfWeek.DayOfWeek);
            */
        }
    }
}
