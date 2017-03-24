using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_2_Domashni_lubimci
{
    class Program
    {
        static void Main(string[] args)
        {
            int broiDni = int.Parse(Console.ReadLine());
            int ostavenaHranaVKg= int.Parse(Console.ReadLine());

            double hranaNaDenZaKuchetoVKg = double.Parse(Console.ReadLine());
            double hranaNaDenZaKotkataVKg = double.Parse(Console.ReadLine());
            double hranaNaDenZaKostenurkataVGramove = double.Parse(Console.ReadLine());    // gramove !!!

            double kolkoEIzqloKucheto = hranaNaDenZaKuchetoVKg * broiDni;
            double kolkoEIzqlaKotkata = hranaNaDenZaKotkataVKg * broiDni;
            double kolkoEIzqlaKostenurkata = (hranaNaDenZaKostenurkataVGramove * broiDni) / 1000;  // v gramove

            double obshtoIzqdenaHrana = kolkoEIzqloKucheto + kolkoEIzqlaKotkata + kolkoEIzqlaKostenurkata;
            double ostanalaHrana = ostavenaHranaVKg - obshtoIzqdenaHrana;
            ostanalaHrana = Math.Floor(ostanalaHrana);

            double nedostignalaHrana = obshtoIzqdenaHrana - ostavenaHranaVKg;
            nedostignalaHrana = Math.Ceiling(nedostignalaHrana);
           

            if (ostavenaHranaVKg >= obshtoIzqdenaHrana)
            {
                Console.WriteLine("{0} kilos of food left.", ostanalaHrana);
            }
            else if (ostavenaHranaVKg < obshtoIzqdenaHrana)
            {
                Console.WriteLine("{0} more kilos of food are needed.", nedostignalaHrana);
            }
        }
    }
}
