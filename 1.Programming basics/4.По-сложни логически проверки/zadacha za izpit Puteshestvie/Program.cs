using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadacha_za_izpit_Puteshestvie
{
    class Program
    {
        static void Main(string[] args)
        {
            double biudjet = double.Parse(Console.ReadLine());
            string sezon = Console.ReadLine().ToLower();

            string vidPochivka = "";
            string mestopolojenie = "";
            double razhodiOtBiudjetaVProcenti = 0.00;

            if (biudjet <= 100 && sezon == "summer") {
                vidPochivka = "Camp";
                mestopolojenie = "Bulgaria";
                razhodiOtBiudjetaVProcenti = (biudjet / 5.00) + (biudjet / 10.00); // 30% VAJNO E DA NAPRAVIM DROBNO DELENIE

            }
            else if (biudjet <= 100 && sezon == "winter") {
                vidPochivka = "Hotel";
                mestopolojenie = "Bulgaria";
                razhodiOtBiudjetaVProcenti = (biudjet / 2.00) + (biudjet / 5.00); // 70% VAJNO E DA NAPRAVIM DROBNO DELENIE

            }
            else if (biudjet <= 1000 && sezon == "summer") {
                vidPochivka = "Camp";
                mestopolojenie = "Balkans";
                razhodiOtBiudjetaVProcenti = (biudjet / 5.00) + (biudjet / 5.00); // 40% VAJNO E DA NAPRAVIM DROBNO DELENIE
            }
            else if (biudjet <= 1000 && sezon == "winter")
            {
                vidPochivka = "Hotel";
                mestopolojenie = "Balkans";
                razhodiOtBiudjetaVProcenti = biudjet - (biudjet / 5); // 80% VAJNO E DA NAPRAVIM DROBNO DELENIE
            }
            else if (biudjet > 1000) {
                mestopolojenie = "Europe";
                vidPochivka = "Hotel";
                razhodiOtBiudjetaVProcenti = biudjet - (biudjet / 10); //90%
            }
            
            Console.WriteLine("Somewhere in {0}",mestopolojenie);
            Console.WriteLine("{0} - {1:f2}", vidPochivka, razhodiOtBiudjetaVProcenti);

        }
    }
}
