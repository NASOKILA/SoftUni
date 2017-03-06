using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountWorkingDays
{
    class CountWorkingDays
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();           
            DateTime startDate = DateTime.ParseExact(firstDate,
                "dd-MM-yyyy", CultureInfo.InvariantCulture);

            string secondDate = Console.ReadLine();            
            DateTime endDate = DateTime.ParseExact(secondDate,
                "dd-MM-yyyy", CultureInfo.InvariantCulture);

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


            int result = 0;
            for (DateTime i = startDate; i <= endDate;)
            {
                if (!(i.DayOfWeek.ToString().Equals("Saturday") || 
                    i.DayOfWeek.ToString().Equals("Sunday")) &&
                    !holidays.Contains(i))
                {
                    // Ako ne e pochiven den i ako ne e praznik uvelichavame s edno
                    
                    result++;
                }
                i = i.AddDays(1);
            }

            Console.WriteLine(result);

            
        }
    }
}
