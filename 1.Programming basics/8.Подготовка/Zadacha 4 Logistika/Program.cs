using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_4_Logistika
{
    class Program
    {
        static void Main(string[] args)
        {

            int broiNaTovari = int.Parse(Console.ReadLine());
            int tonajNaTovar = 0;

          
            double cenaNaTonMikrobus = 200.00;
            double cenaNaTonKamion = 175.00;
            double cenaNaTonVlak = 120.00;

            double obshtoTonMikrobus = 0.00;
            double obshtoTonKamion = 0.00;
            double obshtoTonVlak = 0.00;

            double obshtoTonoveTovari = 0.00;

            double tonoveSMikrobus = 0.00;
            double tonoveSKamion = 0.00;
            double tonoveSVlak = 0.00;

            for (int i = 0; i < broiNaTovari; i++)
            {
                tonajNaTovar = int.Parse(Console.ReadLine());

                if (tonajNaTovar <= 3)
                {
                    obshtoTonMikrobus = obshtoTonMikrobus +  (tonajNaTovar * cenaNaTonMikrobus);
                    tonoveSMikrobus = tonoveSMikrobus + tonajNaTovar;

                }
                else if (tonajNaTovar >= 4 && tonajNaTovar <= 11)
                {
                    obshtoTonKamion = obshtoTonKamion + (tonajNaTovar * cenaNaTonKamion);
                    tonoveSKamion = tonoveSKamion + tonajNaTovar;
                }
                else if (tonajNaTovar >= 12)
                {
                    obshtoTonVlak = obshtoTonVlak + (tonajNaTovar * cenaNaTonVlak);
                    tonoveSVlak = tonoveSVlak + tonajNaTovar;
                }

                obshtoTonoveTovari = obshtoTonoveTovari + tonajNaTovar;
            }

            double srednaCenaNaTon = (obshtoTonMikrobus + obshtoTonKamion + obshtoTonVlak) / obshtoTonoveTovari;

            double procentNaTonSMikrobus = (tonoveSMikrobus / obshtoTonoveTovari) * 100;
            double procentNaTonSKamion = (tonoveSKamion / obshtoTonoveTovari) * 100;
            double procentNaTonSVlak = (tonoveSVlak / obshtoTonoveTovari) * 100;

            Console.WriteLine("{0:f2}", srednaCenaNaTon);
            Console.WriteLine("{0:f2}%", procentNaTonSMikrobus);
            Console.WriteLine("{0:f2}%", procentNaTonSKamion);
            Console.WriteLine("{0:f2}%", procentNaTonSVlak);



        }
    }
}
