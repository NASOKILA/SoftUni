using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_converter
{
    class Program
    {
        static void Main(string[] args)
        {

            var sum = double.Parse(Console.ReadLine());
            var valutaVhod = Console.ReadLine();
            var valutaIzhod = Console.ReadLine();

            double valUSD = 1.79549;
            double valEUR = 1.95583;
            double valGBP = 2.53405;
            double valBGN = 1;

            var valutaUSD = "USD";
            var valutaEUR = "EUR";
            var valutaGBP = "GBP";
            var valutaBGN = "BGN";

            double promenliva1 = 1;
            double promenliva2 = 1;
            

            if (valutaVhod == valutaUSD) { promenliva1 = valUSD; }
            if (valutaVhod == valutaEUR) { promenliva1 = valEUR; }
            if (valutaVhod == valutaGBP) { promenliva1 = valGBP; }
            if (valutaVhod == valutaBGN) { promenliva1 = valBGN; }
            if (valutaIzhod == valutaUSD) { promenliva2 = valUSD; }
            if (valutaIzhod == valutaEUR) { promenliva2 = valEUR; }
            if (valutaIzhod == valutaGBP) { promenliva2 = valGBP; }
            if (valutaIzhod == valutaBGN) { promenliva2 = valBGN; }
            

            var result = sum * promenliva1 / promenliva2;
            Console.WriteLine(Math.Round(result, 2));

            //1 BNG = 1.79549 USD     1.95583 EUR   2.53405 GBP

        }
    }
}

