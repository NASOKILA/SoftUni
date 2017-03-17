using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopravkaNaPlochki
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


            if ((N < 1 || N > 100.00) || (W < 0.10 || W > 10.00) 
                || (L < 0.10 || L > 10.00) || (M < 0.00 || M > 10.00) 
                || (O < 0.00 || O > 10.00))
            {
                Console.WriteLine("ERROR!");
            }
            else
            {
                double vremeZaPlochka = 0.20;

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
