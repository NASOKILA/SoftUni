using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTickets
{
    class MatchTickets
    {
        static void Main(string[] args)
        {
            double biudjet = double.Parse(Console.ReadLine());
            string vidBileti = Console.ReadLine().ToLower();
            int broiZapalqnkovci = int.Parse(Console.ReadLine());
            var vip = 499.99;
            var normal = 249.99;
            double cenaZaTransport = 0.00;
            double ostatukOtBiudjeta = 0.00;
            double neStigat = 0.00;
            double result = 0.00;


            if (biudjet < 1000 || biudjet > 1000000 || !(vidBileti == "vip" || vidBileti == "normal") ||
                broiZapalqnkovci < 1 || broiZapalqnkovci > 200) { Console.WriteLine("Input error!"); }
            else
            {

                if (broiZapalqnkovci >= 1 && broiZapalqnkovci <= 4)
                {
                    cenaZaTransport = (biudjet / 5.00) + (biudjet / 2.00) + (biudjet / 20.00); //70%
                }
                else if (broiZapalqnkovci >= 5 && broiZapalqnkovci <= 9)
                {
                    cenaZaTransport = (biudjet / 10.00) + (biudjet / 2.00); //60%
                }
                else if (broiZapalqnkovci >= 10 && broiZapalqnkovci <= 24)
                {
                    cenaZaTransport = (biudjet / 2.00); //50%
                }
                else if (broiZapalqnkovci >= 25 && broiZapalqnkovci <= 49)
                {
                    cenaZaTransport = (biudjet / 2.00) - (biudjet / 10.00); //40%
                }
                else if (broiZapalqnkovci >= 50)
                {
                    cenaZaTransport = (biudjet / 4.00);//25%
                }


                ostatukOtBiudjeta = biudjet - cenaZaTransport;

                if (ostatukOtBiudjeta > vip)
                {

                    if ((vip * broiZapalqnkovci) < ostatukOtBiudjeta)
                    {
                        ostatukOtBiudjeta = ostatukOtBiudjeta - (vip * broiZapalqnkovci);
                        Console.WriteLine("Yes! You have {0:f2} leva left.", ostatukOtBiudjeta);
                    }
                    else if ((vip * broiZapalqnkovci) > ostatukOtBiudjeta)
                    {
                        neStigat = (vip * broiZapalqnkovci) - ostatukOtBiudjeta;
                        if (neStigat < 0) { neStigat = Math.Abs(neStigat); neStigat = neStigat - biudjet; }
                        Console.WriteLine("Not enough money! You need {0:f2} leva.", neStigat);
                    }



                }
                else if (ostatukOtBiudjeta < vip)
                {


                    if ((normal * broiZapalqnkovci) < ostatukOtBiudjeta)
                    {
                        result = ostatukOtBiudjeta - (normal * broiZapalqnkovci);
                        Console.WriteLine("Yes! You have {0:f2} leva left.", result);
                    }
                    else
                    {
                        neStigat = (normal * broiZapalqnkovci) - ostatukOtBiudjeta;
                        Console.WriteLine("Not enough money! You need {0:f2} leva.", neStigat);
                    }

                }

            }
        }
    }
}
