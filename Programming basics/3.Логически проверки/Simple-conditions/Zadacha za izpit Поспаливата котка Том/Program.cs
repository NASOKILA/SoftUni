using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_za_izpit_Поспаливата_котка_Том
{
    class Program
    {
        static void Main(string[] args)
        {
            int pochivniDniGodishno = int.Parse(Console.ReadLine());

            if (pochivniDniGodishno > 356) { Console.WriteLine("ERROR!"); }
            else {

                var minutiNormaZaIgraNaTomGodishno = 30000;
                var rabotniDniGodishno = 365 - pochivniDniGodishno;
                var godishnaIgraNaTom = (rabotniDniGodishno * 63) + (pochivniDniGodishno * 127);
                var minutiOstatukOtNormata = minutiNormaZaIgraNaTomGodishno - godishnaIgraNaTom;

                if (godishnaIgraNaTom > minutiNormaZaIgraNaTomGodishno)
                {
                    var absMin = Math.Abs(minutiOstatukOtNormata); // convert to positive number
                    var chasoveOstatuk = absMin / 60;
                    var minutiOstatuk = absMin % 60;
                    Console.WriteLine("Tom will run away");
                    Console.WriteLine(chasoveOstatuk + " hours and {0} minutes more for play", minutiOstatuk);    
                }
                else {
                    
                    var chasoveOstatuk2 = minutiOstatukOtNormata / 60;
                    var minutiOstatuk2 = minutiOstatukOtNormata % 60;
                    Console.WriteLine("Tom sleeps well");
                    Console.WriteLine(chasoveOstatuk2 + " hours and {0} minutes less for play", minutiOstatuk2);
                }

            }
        }
    }
}
