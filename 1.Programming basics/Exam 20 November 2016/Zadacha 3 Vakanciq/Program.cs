using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_3_Vakanciq
{
    class Program
    {
        static void Main(string[] args)
        {
            int broiVuzrastni = int.Parse(Console.ReadLine());
            int broiUchenici = int.Parse(Console.ReadLine());
            int broiNoshtuvki = int.Parse(Console.ReadLine());
            string vidTransport = Console.ReadLine().ToLower();

            int obshtoHora = broiVuzrastni + broiUchenici;

            double cenaVlakVuzrastni = 24.99 * 2;
            double cenaVlakUchenici = 14.99 * 2;

            double cenaAvtobusVuzrastni = 32.50 * 2;
            double cenaAvtobusUchenici = 28.50 * 2;

            double cenaKorabVuzrastni = 42.99 * 2;
            double cenaKorabUchenici = 39.99 * 2;

            double cenaSamoletVuzrastni = 70.00 * 2;
            double cenaSamoletUchenici = 50.00 * 2;

            double razhodNoshtuvki = broiNoshtuvki * 82.99;
            double razhodTransport = 0.00;
            


            if (vidTransport == "train" )
            {
                if (obshtoHora >= 50)
                {
                    razhodTransport = (broiVuzrastni * cenaVlakVuzrastni) + (broiUchenici * cenaVlakUchenici);
                    razhodTransport = razhodTransport / 2; // 50% otstupka 
                }
                else
                {
                    razhodTransport = (broiVuzrastni * cenaVlakVuzrastni) + (broiUchenici * cenaVlakUchenici);
                }
            }
            else if (vidTransport == "bus")
            {
                razhodTransport = (broiVuzrastni * cenaAvtobusVuzrastni) + (broiUchenici * cenaAvtobusUchenici);
            }
            else if (vidTransport == "boat")
            {
                razhodTransport = (broiVuzrastni * cenaKorabVuzrastni) + (broiUchenici * cenaKorabUchenici);
            }
            else if (vidTransport == "airplane")
            {
                razhodTransport = (broiVuzrastni * cenaSamoletVuzrastni) + (broiUchenici * cenaSamoletUchenici);
            }

            double cqlaSuma = razhodNoshtuvki + razhodTransport;
            cqlaSuma = cqlaSuma + (cqlaSuma/10); // 10% komisionna


            Console.WriteLine("{0:f2}",cqlaSuma);

        }
    }
}
