using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_za_izpit_uchebna_zala
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Visochina na zalata v metri : ");
            var h = double.Parse(Console.ReadLine());

            Console.Write("Shirochina na zalata v metri : ");
            var w = double.Parse(Console.ReadLine());

            if ((  h < 3) || (h > 100) || (w > h)) { Console.WriteLine("Error!  3 <= h <= w <= 100"); }
            else{

                int koridor = 100;
                int vrata = 70;
                var rabotnoMqsto = 120;

                var hInCm = h * 100;
                var wInCm = w * 100;

                var redove = hInCm / rabotnoMqsto;
                var redove2 = Math.Round(redove);

                var wInCm2 = wInCm - koridor;

                var biura = wInCm2 / vrata;
                var biura2 = Math.Round(biura);

                var mesta = (redove2 * biura2) - 3;
                Console.WriteLine("Broi mesta = {0}", mesta);
            }
        }
    }
}
