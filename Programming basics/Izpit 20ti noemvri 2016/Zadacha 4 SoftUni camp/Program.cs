using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_4_SoftUni_camp
{
    class Program
    {
        static void Main(string[] args)
        {

            int broiGrupiOtStudenti = int.Parse(Console.ReadLine());



            double horaPutuvashtiSLekAvtomobil = 0.00;
            double horaPutuvashtiSMikrobus = 0.00;
            double horaPutuvashtiSMalukAvtobus = 0.00;
            double horaPutuvashtiSGolqmAvtobus = 0.00;
            double horaPutuvashtiSVlak = 0.00;

            double obshtoBroiStudenti = 0.00;

            for (int i = 0; i < broiGrupiOtStudenti; i++)
            {
                int broiNaHoraVGrupa = int.Parse(Console.ReadLine());
                obshtoBroiStudenti += broiNaHoraVGrupa;

                if(broiNaHoraVGrupa <= 5) { horaPutuvashtiSLekAvtomobil += broiNaHoraVGrupa; }
                else if (broiNaHoraVGrupa >= 6 && broiNaHoraVGrupa <= 12) { horaPutuvashtiSMikrobus += broiNaHoraVGrupa; }
                else if (broiNaHoraVGrupa >= 13 && broiNaHoraVGrupa <= 25) { horaPutuvashtiSMalukAvtobus += broiNaHoraVGrupa; }
                else if (broiNaHoraVGrupa >= 26 && broiNaHoraVGrupa <= 40) { horaPutuvashtiSGolqmAvtobus += broiNaHoraVGrupa; }
                else if (broiNaHoraVGrupa >= 41) { horaPutuvashtiSVlak += broiNaHoraVGrupa; }

            }

            horaPutuvashtiSLekAvtomobil = (horaPutuvashtiSLekAvtomobil / obshtoBroiStudenti) * 100.00;
            horaPutuvashtiSMikrobus = (horaPutuvashtiSMikrobus / obshtoBroiStudenti) * 100.00;
            horaPutuvashtiSMalukAvtobus = (horaPutuvashtiSMalukAvtobus / obshtoBroiStudenti) * 100.00;
            horaPutuvashtiSGolqmAvtobus = (horaPutuvashtiSGolqmAvtobus / obshtoBroiStudenti) * 100.00;
            horaPutuvashtiSVlak = (horaPutuvashtiSVlak/ obshtoBroiStudenti) * 100.00;

            Console.WriteLine("{0:f2}%",horaPutuvashtiSLekAvtomobil);
            Console.WriteLine("{0:f2}%", horaPutuvashtiSMikrobus);
            Console.WriteLine("{0:f2}%", horaPutuvashtiSMalukAvtobus);
            Console.WriteLine("{0:f2}%", horaPutuvashtiSGolqmAvtobus);
            Console.WriteLine("{0:f2}%", horaPutuvashtiSVlak);

        }
    }
}
