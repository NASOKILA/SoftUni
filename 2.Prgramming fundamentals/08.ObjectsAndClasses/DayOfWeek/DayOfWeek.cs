using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;

namespace DayOfWeek
{
    class DayOfWeek
    {
        static void Main(string[] args)
        {
            var dateAsString = Console.ReadLine();
            /*
             Primeri za formati:
             d-M-yyyy   2-5-2017
             dd-MM-yy   02-05-17
             */

            // m e za minuti   ,   M  e za meseci !
            var date = DateTime.ParseExact(
                dateAsString, // DATA
                "d-M-yyyy",  // FORMAT
                CultureInfo.InvariantCulture //ZAPOMNI GO TOVA NA IZUS !
                );
            // InvariantCulture ni spasqva ot malki dobaveni tochni ili drugi drazneshti sinvoli

            //kato natisnem  date.  i izchakame shte se poqvat vsichki vuzmojni i dostupni za DateTime neshta !
            Console.WriteLine(date.DayOfWeek);


        }
    }
}
