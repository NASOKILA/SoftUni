using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adacha_za_izpit_Remont_na_plochki
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double N = double.Parse(Console.ReadLine());  
            double W = double.Parse(Console.ReadLine());
            double L = double.Parse(Console.ReadLine());
            double M = double.Parse(Console.ReadLine());
            double O = double.Parse(Console.ReadLine());


            if((N<1 || N>100) || (W<0.1 || W>10.00) || (L < 0.1 || L > 10.00) || (M<0 || M>10) || (O < 0 || O > 10)){ Console.WriteLine("ERROR!"); }
            else {
                double vremeZaPlochka = 0.2;

                double ploshNaPloshtatka = N * N;
                double ploshNaPlochka = W * L;
                double ploshNaPeika = M * O;

                double broiPlochki = (ploshNaPloshtatka - ploshNaPeika) / ploshNaPlochka;
                double vremeZaRemont = broiPlochki * vremeZaPlochka;

                Console.WriteLine(broiPlochki);
                Console.WriteLine(vremeZaRemont);
            }


        }
    }
}
