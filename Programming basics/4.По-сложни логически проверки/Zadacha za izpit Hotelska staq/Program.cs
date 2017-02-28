using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_za_izpit_Hotelska_staq
{
    class Program
    {
        static void Main(string[] args)
        {

            string mesec = Console.ReadLine().ToLower();
            int noshtuvki = int.Parse(Console.ReadLine());
            double cenaStudio = 0.00;
            double cenaApartament = 0.00;           

            if (!(mesec == "may" || mesec == "september" || mesec == "june" || mesec == "july" ||
                mesec == "octpber" || mesec == "august" || noshtuvki > 0 || noshtuvki < 200)) { Console.WriteLine("Input error!"); }
            else
            {

                if (mesec == "may" || mesec == "october")
                {
                    cenaStudio = noshtuvki * 50.00;
                    cenaApartament = noshtuvki * 65.00;
                }
                else if (mesec == "june" || mesec == "september")
                {
                    cenaStudio = noshtuvki * 75.20;
                    cenaApartament = noshtuvki * 68.70;
                }
                else if (mesec == "july" || mesec == "august")
                {
                    cenaStudio = noshtuvki * 76.00;
                    cenaApartament = noshtuvki * 77.00;
                }
                //otstupki :

                if ((mesec == "may" || mesec == "october") && noshtuvki > 7 && noshtuvki < 15)
                {
                    cenaStudio = cenaStudio - (cenaStudio / 10) + (cenaStudio / 20); // 5% otstupka                
                }

                else if ((mesec == "may" || mesec == "october") && noshtuvki > 14)
                {
                    cenaStudio = cenaStudio - (cenaStudio / 5) - (cenaStudio / 10); // 30% otstupka                
                }

                else if ((mesec == "june" || mesec == "september") && noshtuvki > 14)
                {
                    cenaStudio = cenaStudio - (cenaStudio / 5);// 20% otstupka                
                }

                if (noshtuvki > 14)
                {
                    cenaApartament = cenaApartament - (cenaApartament / 10); // 10% otstupka                
                }


                Console.WriteLine("Apartment: {0:f2} lv.", cenaApartament);
                Console.WriteLine("Studio: {0:f2} lv.", cenaStudio);
            }
        }
    }
}
