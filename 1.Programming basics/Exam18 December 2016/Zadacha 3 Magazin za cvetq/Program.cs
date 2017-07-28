using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_3_Magazin_za_cvetq
{
    class Program
    {
        static void Main(string[] args)
        {

            int broiZakupeniHrizantemi = int.Parse(Console.ReadLine());
            int broiZakupeniRozi = int.Parse(Console.ReadLine());
            int broiZakupeniLaleta = int.Parse(Console.ReadLine());

            if (broiZakupeniHrizantemi < 0 || broiZakupeniHrizantemi > 200 ||
                broiZakupeniLaleta < 0 || broiZakupeniLaleta > 200 ||
                broiZakupeniRozi < 0 || broiZakupeniRozi > 200) { Console.WriteLine("Input number Error!"); }
            else
            {

                string sezon = Console.ReadLine().ToLower();  // sezon
                

                if (!(sezon == "spring" || sezon == "summer" ||
                    sezon == "autumn" || sezon == "winter")) { Console.WriteLine("Input sezon error!"); }
                else {

                    string praznikIliNe = Console.ReadLine().ToLower(); // praznik ili ne

                    if (!(praznikIliNe == "y" || praznikIliNe == "n")) { Console.WriteLine("Input praznik error!"); }
                    else {

                        // programata zapochva ot tuk !

                        double kupeniHrizantemi = 0.00;
                        double kupeniRozi = 0.00;
                        double kupeniLaleta = 0.00;

                        if (sezon == "spring" || sezon == "summer") {

                            kupeniHrizantemi = broiZakupeniHrizantemi * 2.00;
                            kupeniRozi = broiZakupeniRozi * 4.10;
                            kupeniLaleta = broiZakupeniLaleta * 2.50;
                        }
                        else if (sezon == "autumn" || sezon == "winter")
                        {
                            kupeniHrizantemi = broiZakupeniHrizantemi * 3.75;
                            kupeniRozi = broiZakupeniRozi * 4.50;
                            kupeniLaleta = broiZakupeniLaleta * 4.15;
                        }

                        double obshtBuket = kupeniHrizantemi + kupeniRozi + kupeniLaleta;
                        if (praznikIliNe == "y")
                        { 
                            obshtBuket = obshtBuket + ((obshtBuket / 10) + (obshtBuket/ 20)); // + 15%  za vsichki cvetq t.e ot celiq buket
                        }               

                        // oststupki :   pravim gi bez if else zashtoto moje da ima dve otstupki ednovremenno !
                        if (sezon == "spring" && broiZakupeniLaleta > 7) {
                            obshtBuket = obshtBuket - (obshtBuket/20);  // - 5%
                        }
                        if (sezon == "winter" && broiZakupeniRozi >= 10) {
                            obshtBuket = obshtBuket - (obshtBuket / 10);   // - 10%
                        }

                        double obshtoCvetq = broiZakupeniHrizantemi + broiZakupeniLaleta + broiZakupeniRozi;

                        if (obshtoCvetq > 20) {
                            obshtBuket = obshtBuket - (obshtBuket / 5); // - 20%
                        }

                        obshtBuket = obshtBuket + 2; // +2 za aranjirane

                        Console.WriteLine("{0:f2}",obshtBuket);

                    }
                }
            }
        }
    }
}
