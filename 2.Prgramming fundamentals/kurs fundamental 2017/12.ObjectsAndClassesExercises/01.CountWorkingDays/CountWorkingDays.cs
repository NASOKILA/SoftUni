using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CountWorkingDays
{
    class CountWorkingDays
    {
        static void Main(string[] args)
        {
            string[] dateOne = Console.ReadLine()
                .Split('-')
                .ToArray();
            int day = int.Parse(dateOne[0]);
            int month = int.Parse(dateOne[1]);
            int year = int.Parse(dateOne[2]);

            DateTime startDate = new DateTime(year, month, day);

            string dateTwo = Console.ReadLine();

            DateTime endDate = DateTime.ParseExact(
                dateTwo,
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture
                );

            DateTime[] holidays = new DateTime[] { // year, month, day

                new DateTime(endDate.Year,01,01),
                new DateTime(endDate.Year,03,03),
                new DateTime(endDate.Year,05,01),
                new DateTime(endDate.Year,05,06),
                new DateTime(endDate.Year,05,24),
                new DateTime(endDate.Year,09,06),
                new DateTime(endDate.Year,09,22),
                new DateTime(endDate.Year,11,01),
                new DateTime(endDate.Year,12,24),
                new DateTime(endDate.Year,12,25),
                new DateTime(endDate.Year,12,26),

            };


            
            int workingDays = 0;
            for (DateTime currentDay = startDate; currentDay <= endDate; currentDay = currentDay.AddDays(1))
            {              
                if (!holidays.Any(d => d.Day == currentDay.Day && d.Month == currentDay.Month) 
                    && currentDay.DayOfWeek.ToString() != "Saturday" 
                    && currentDay.DayOfWeek.ToString() != "Sunday")
                    workingDays++;
            }

            Console.WriteLine(workingDays);
        }
    }
}
