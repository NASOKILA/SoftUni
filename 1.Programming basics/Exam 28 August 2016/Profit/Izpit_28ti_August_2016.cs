using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profit
{
    class Izpit_28ti_August_2016
    {
        static void Main(string[] args)
        {
            int rabotniDniVMeseca = int.Parse(Console.ReadLine());
            double izkaraniPariNaDen = double.Parse(Console.ReadLine());
            double kursNaUSDsprqmoLv = double.Parse(Console.ReadLine());


            var mesechnaPechalba = rabotniDniVMeseca * izkaraniPariNaDen;
            var godishenBonus = mesechnaPechalba * 2.5;
            var godishnaPechalba = (mesechnaPechalba * 12) + godishenBonus;
            var godishniDanuci = (godishnaPechalba * 25) / 100;

            var chistaGodishnaPechalbaVUSD = godishnaPechalba - godishniDanuci;
            var chistaGodishnaPechalbaVLV = chistaGodishnaPechalbaVUSD * kursNaUSDsprqmoLv;
            var chistaDnevnaPechalba = chistaGodishnaPechalbaVLV / 365;

            Console.WriteLine(Math.Round(chistaDnevnaPechalba, 2));
        }
    }
}
