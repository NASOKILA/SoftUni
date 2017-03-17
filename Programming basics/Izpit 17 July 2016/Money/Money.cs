using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    class Money
    {
        static void Main(string[] args)
        {
            //  1 биткойн = 1168 лева.
            //  1 китайски юан = 0.15 долара.
            //  1 долар = 1.76 лева.
            //  1 евро = 1.95 лева.

            var bitkoini = double.Parse(Console.ReadLine());
            var kitaiskiIoana = double.Parse(Console.ReadLine());
            var komisionna = double.Parse(Console.ReadLine());


            var bitkoiniVLv = bitkoini * 1168;
            var bitcoiniVEU = bitkoiniVLv / 1.95;

            var kitaiskiIoanaVUSD = kitaiskiIoana * 0.15;
            var kitaiskiIoanaVLV = kitaiskiIoanaVUSD * 1.76;
            var kitaiskiIoanaVEU = kitaiskiIoanaVLV / 1.95;

            var resultat = bitcoiniVEU + kitaiskiIoanaVEU;
            var komisionnaProcent = (komisionna * resultat) / 100;
            var kraenResultat = resultat - komisionnaProcent;

            Console.WriteLine(kraenResultat);
        }
    }
}
