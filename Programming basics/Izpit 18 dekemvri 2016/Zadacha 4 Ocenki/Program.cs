using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_4_Ocenki
{
    class Program
    {
        static void Main(string[] args)
        {
            int broiStudentiNaIzpit = int.Parse(Console.ReadLine());

            if (broiStudentiNaIzpit < 1 || broiStudentiNaIzpit > 1000) { Console.WriteLine("Input error!"); }
            else
            {
                int zaProverkaNaOcenki = 0;


                double sredenUspeh = 0.00;
                double pod3 = 0.00;
                double mejdu3I4 = 0.00;
                double mejdu4I5 = 0.00;
                double mejdu5I6 = 0.00;

                for (int i = 0; i < broiStudentiNaIzpit; i++)
                {
                    double ocenki = double.Parse(Console.ReadLine());

                    if (ocenki < 2.00 || ocenki > 6.00)
                    { Console.WriteLine("Input error!"); zaProverkaNaOcenki = 1; break; }
                    else
                    {

                        //ZADACHATA ZAPOCHVA OT TUKA!  V CIKULA SME !!!

                        sredenUspeh += ocenki;


                        if (ocenki >= 2.00 && ocenki <= 2.99) {  // pod 3
                            pod3++;
                        }
                        else if (ocenki >= 3.00 && ocenki <= 3.99) // ot 3 do 4
                        {
                            mejdu3I4++;
                        }
                        else if (ocenki >= 4.00 && ocenki <= 4.99) // ot 4 do 5
                        {
                            mejdu4I5++;
                        }
                        else if (ocenki >= 5.00 && ocenki <= 6.00) // ot 5 do 6
                        {
                            mejdu5I6++;
                        }



                    }
                }

                // IZVUN CIKULA SME !

                // transformirame v procenti:
                double mejdu5I6VProcenti = (mejdu5I6 / broiStudentiNaIzpit) * 100;
                double mejdu4I5VProcenti = (mejdu4I5 / broiStudentiNaIzpit) * 100;
                double mejdu3I4VProcenti = (mejdu3I4 / broiStudentiNaIzpit) * 100;
                double pod3VProcenti = (pod3 / broiStudentiNaIzpit) * 100;

                sredenUspeh = sredenUspeh / broiStudentiNaIzpit;

                if (zaProverkaNaOcenki == 0)
                {
                    Console.WriteLine("Top students: {0:f2}%", mejdu5I6VProcenti);
                    Console.WriteLine("Between 4.00 and 4.99: {0:f2}%", mejdu4I5VProcenti);
                    Console.WriteLine("Between 3.00 and 3.99: {0:f2}%", mejdu3I4VProcenti);
                    Console.WriteLine("Fail: {0:f2}%", pod3VProcenti);
                    Console.WriteLine("Average: {0:f2}", sredenUspeh);
                }
            }
        }
    }
}
