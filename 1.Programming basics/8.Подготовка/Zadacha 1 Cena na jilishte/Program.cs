using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_1_Cena_na_jilishte
{
    class Program
    {
        static void Main(string[] args)
        {
            double ploshtNaNaiMalkaStaq = double.Parse(Console.ReadLine());
            double ploshtNaKuhniq = double.Parse(Console.ReadLine());
            double cenaNaKvadratenMetar = double.Parse(Console.ReadLine());
            double obshtaPlosht = 0.00;
            double cenaNaJilishteto = 0.00;

            if (ploshtNaNaiMalkaStaq < 1.00 || ploshtNaNaiMalkaStaq > 100.00 || 
                ploshtNaKuhniq < 1.00 || ploshtNaKuhniq > 100.00 ||
                cenaNaKvadratenMetar < 1.00 || cenaNaKvadratenMetar > 1000.00)
            { Console.WriteLine("Input error!"); }
            else
            {

                double ploshtNaBanq = ploshtNaNaiMalkaStaq / 2.00; // 50% po malka ot nai malkata staq
                double ploshtVtoraStaq = ploshtNaNaiMalkaStaq + (ploshtNaNaiMalkaStaq / 10.00); // 10% > ot nai malkata staq
                double ploshtTretaStaq = ploshtVtoraStaq + (ploshtVtoraStaq / 10.00);

                obshtaPlosht = ploshtNaBanq + ploshtNaKuhniq + ploshtNaNaiMalkaStaq +
                    ploshtVtoraStaq + ploshtTretaStaq;

                obshtaPlosht = obshtaPlosht + (obshtaPlosht / 20.00); // +5% ot obshtata plosht za koridor

                cenaNaJilishteto = cenaNaKvadratenMetar * obshtaPlosht;

                Console.WriteLine("{0:f2}",cenaNaJilishteto);
            }




        }
    }
}
