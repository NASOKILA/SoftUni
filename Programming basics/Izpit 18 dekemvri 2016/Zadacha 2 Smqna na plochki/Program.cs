using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_2_Smqna_na_plochki
{
    class Program
    {
        static void Main(string[] args)
        {

            double subraniPari = double.Parse(Console.ReadLine());
            double shirochinaNaPoda = double.Parse(Console.ReadLine());
            double duljinaNaPoda = double.Parse(Console.ReadLine());
            double stranaNaTriugulnika = double.Parse(Console.ReadLine());

            double visochinaNaTriugulnika = double.Parse(Console.ReadLine());
            double cenaNaEdnaPlochka = double.Parse(Console.ReadLine());
            double sumaZaMaistora = double.Parse(Console.ReadLine());

            double ploshtNaPoda = shirochinaNaPoda * duljinaNaPoda;
            double ploshtNaPlochka = (stranaNaTriugulnika * visochinaNaTriugulnika) / 2 ;
            double neobhodimiPlochki = ploshtNaPoda / ploshtNaPlochka;
            neobhodimiPlochki = Math.Ceiling(neobhodimiPlochki);
           
            neobhodimiPlochki = neobhodimiPlochki + 5; // za fira

            double obshtaSuma = (neobhodimiPlochki * cenaNaEdnaPlochka) + sumaZaMaistora; // + 100 za maistor

            double ostavashtiPari = subraniPari - obshtaSuma;
            double nedostigashtiPari = obshtaSuma - subraniPari;

            if (obshtaSuma <= subraniPari) { Console.WriteLine("{0:f2} lv left.", ostavashtiPari); }
            else if (obshtaSuma > subraniPari) { Console.WriteLine("You'll need {0:f2} lv more.",nedostigashtiPari); }

        }
    }
}
