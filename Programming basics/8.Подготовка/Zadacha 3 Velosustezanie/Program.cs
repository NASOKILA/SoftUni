using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_3_Velosustezanie
{
    class Program
    {
        static void Main(string[] args)
        {

            int broiMladshiVelosipedisti = int.Parse(Console.ReadLine());
            int broiStarshiVelosipedisti = int.Parse(Console.ReadLine());
            string vidTrase = Console.ReadLine().ToLower();

            double taksaMladshi = 0.00;
            double taksaStarshi = 0.00;
            double darenaSuma = 0.00;
            double obshtoUchasnici = broiMladshiVelosipedisti + broiStarshiVelosipedisti;

            if (vidTrase == "trail") {

                taksaMladshi = broiMladshiVelosipedisti * 5.50;
                taksaStarshi = broiStarshiVelosipedisti * 7.00;                
            }
            else if (vidTrase == "cross-country")
            {

                taksaMladshi = broiMladshiVelosipedisti * 8.00;
                taksaStarshi = broiStarshiVelosipedisti * 9.50;
            }
            else if (vidTrase == "downhill")
            {

                taksaMladshi = broiMladshiVelosipedisti * 12.25;
                taksaStarshi = broiStarshiVelosipedisti * 13.75;
            }
            else if (vidTrase == "road")
            {

                taksaMladshi = broiMladshiVelosipedisti * 20.00;
                taksaStarshi = broiStarshiVelosipedisti * 21.50;
            }


            darenaSuma = taksaMladshi + taksaStarshi;

            if (vidTrase == "cross-country" && obshtoUchasnici >= 50)
            {
                darenaSuma = darenaSuma - (darenaSuma / 4); // - 25% za cross-country s 50 ili poveche uchastnici 
            }

           
            darenaSuma = darenaSuma - (darenaSuma / 20); // 5% za razhodi             
            Console.WriteLine("{0:f2}",darenaSuma);


        }
    }
}
