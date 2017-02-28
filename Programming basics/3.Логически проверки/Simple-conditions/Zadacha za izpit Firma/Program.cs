using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_za_izpit_Firma
{
    class Program
    {
        static void Main(string[] args)
        {
            int nujniChasove = int.Parse(Console.ReadLine());
            int razpolagashtiDni = int.Parse(Console.ReadLine());
            int izvunrednoRaboteshtiSlujiteli = int.Parse(Console.ReadLine());

            if (nujniChasove < 0 || nujniChasove > 200000 || razpolagashtiDni < 0 || razpolagashtiDni > 20000 || izvunrednoRaboteshtiSlujiteli < 0 || izvunrednoRaboteshtiSlujiteli > 200)
            {
                Console.WriteLine("ERROR!");
            }
            else {

                double minus10Procenta = (double)razpolagashtiDni / 10;
                double realniDni = razpolagashtiDni - minus10Procenta;
                var chasoveZaRabota = realniDni * 8;
                var izvunredniChasove = izvunrednoRaboteshtiSlujiteli * (2*razpolagashtiDni);
                double obshtoChasove = chasoveZaRabota + izvunredniChasove;
                obshtoChasove = Math.Floor(obshtoChasove);

                if (obshtoChasove >= nujniChasove)
                {
                    var ostanaliChasove = obshtoChasove - nujniChasove;

                    Console.WriteLine("Yes!{0} hours left.", ostanaliChasove);
                }
                else {
                    var ostanaliChasove = nujniChasove - obshtoChasove;
                    Console.WriteLine("Not enough time!{0} hours needed.", ostanaliChasove);
                }


            }
        }
    }
}
