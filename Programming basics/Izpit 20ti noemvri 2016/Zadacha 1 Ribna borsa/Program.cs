using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_1_Ribna_borsa
{
    class Program
    {
        static void Main(string[] args)
        {

            double cenaSkumriqNaKg = double.Parse(Console.ReadLine());
            double cenaCacaNaKg = double.Parse(Console.ReadLine());

            double palamudKg = double.Parse(Console.ReadLine());
            double safridKg = double.Parse(Console.ReadLine());

            int midiKg = int.Parse(Console.ReadLine());
            double obshtaSmetka = 0.00;

            double cenaNaPalamud = cenaSkumriqNaKg + (cenaSkumriqNaKg / 2) + (cenaSkumriqNaKg / 10);// 60% po skup ot skumriqta
            double cenaNaSafrid = (cenaCacaNaKg * 2) - (cenaCacaNaKg / 5); // 80% po skup ot cacata
            double cenaNaMidi = 7.50;

            double sumaPalamud = cenaNaPalamud * palamudKg;
            double sumaSafrid = cenaNaSafrid * safridKg;
            double sumaMidi = cenaNaMidi * midiKg;

            obshtaSmetka = sumaMidi + sumaPalamud + sumaSafrid;

            Console.WriteLine("{0:f2}",obshtaSmetka);



        }
    }
}
