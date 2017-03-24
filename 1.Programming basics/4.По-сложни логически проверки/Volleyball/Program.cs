using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string vidGodina = Console.ReadLine().ToLower();
            int godishniPraznici = int.Parse(Console.ReadLine());
            int uikendiVKoitoVnadiPutuva = int.Parse(Console.ReadLine());
            int obshtoUikendi = 48;
            double uikendiVSofia = obshtoUikendi - uikendiVKoitoVnadiPutuva;
            double subotniIgriVSofia = uikendiVSofia * (3.0 / 4); // vladi igrae samo tri chetvurti ot subotite v sofiq,  IZPOLZVAME DROBNO DELENIE
            double igriVRodniqSiGrad = uikendiVKoitoVnadiPutuva; // igrae vsqka nedelq
            double igriVPraznichniDniVSofia = godishniPraznici * (2.0 / 3); // IZPOLZVAME DROBNO DELENIE
            double obshtoIgri = subotniIgriVSofia + igriVRodniqSiGrad + igriVPraznichniDniVSofia;

            if (vidGodina == "leap") {
                double procenti15 = obshtoIgri / 10 + obshtoIgri / 20; // 15% ot obshtite igri
                obshtoIgri = obshtoIgri + procenti15;

                Console.WriteLine(Math.Truncate(obshtoIgri));
            }
            else if (vidGodina == "normal") {

                Console.WriteLine(Math.Truncate(obshtoIgri)); // Math.Truncate()  zakruglq nagore ili na dolo kum 0levo chislo! 

                //  Math.Round() moje da izaravnqva do nai blizkoto chetno chislo i do nechetno zavisi kak go nastroim
            }
            else { Console.WriteLine("Error!"); }



        }
    }
}
