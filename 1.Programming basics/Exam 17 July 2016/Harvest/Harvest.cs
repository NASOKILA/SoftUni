using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest
{
    class Harvest
    {
        static void Main(string[] args)
        {
            int kvmLozq = int.Parse(Console.ReadLine());
            double za1KvmGrozde = double.Parse(Console.ReadLine());
            int nujniLitriVino = int.Parse(Console.ReadLine());
            int broiRabotnici = int.Parse(Console.ReadLine());

            if (kvmLozq < 10 || kvmLozq > 5000 || za1KvmGrozde < 0 || za1KvmGrozde > 10 || nujniLitriVino < 10 || nujniLitriVino > 600 || broiRabotnici < 1 || broiRabotnici > 20)
            {
                Console.WriteLine("ERROR !");
            }
            else
            {

                var obshtoGrozde = kvmLozq * za1KvmGrozde;
                var grozdeZaVino = (obshtoGrozde / 2) - (obshtoGrozde / 10); //40%
                var proizvedenoVino = grozdeZaVino / 2.5;


                if (proizvedenoVino >= nujniLitriVino)
                {
                    var ostanaloVino = proizvedenoVino - nujniLitriVino;
                    var vinoZaVsekiRabotnik = ostanaloVino / broiRabotnici;
                    Console.WriteLine("Good harvest this year! Total wine: {0} liters.", proizvedenoVino);
                    Console.WriteLine("{0} liters left -> {1} liters per person.", Math.Ceiling(ostanaloVino), Math.Ceiling(vinoZaVsekiRabotnik));
                }
                else
                {

                    var nedostigashtoVino = nujniLitriVino - proizvedenoVino;
                    Console.WriteLine("It will be a tough winter! More {0} liters wine needed.", Math.Floor(nedostigashtoVino));

                }

            }
        }
    }
}
