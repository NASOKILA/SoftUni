using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_za_izpit_Trabi_v_basein
{
    class Program
    {
        static void Main(string[] args)
        {

            int litriNaBaseina = int.Parse(Console.ReadLine());
            int pipe1 = int.Parse(Console.ReadLine());
            int pipe2 = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            if ((litriNaBaseina < 1 || litriNaBaseina > 10000) || (pipe1 < 1 || pipe1 > 5000) || (pipe2 < 1 || pipe2 > 5000) || (hours < 1.00 || hours > 24.00))
            {
                Console.WriteLine("ERROR !");
            }
            else {

                var litriP1 = pipe1 * hours;
                var litriP2 = pipe2 * hours;
                var obshtoLitri = litriP1 + litriP2;
                var obshtProcentOtBaseina = (obshtoLitri / litriNaBaseina) * 100;
                var procentOtPipe1 = (litriP1 / obshtProcentOtBaseina) * 10;
                var procentOtPipe2 = (litriP2 / obshtProcentOtBaseina) * 10;

                if (litriNaBaseina > obshtoLitri) {
                    Console.WriteLine("The pool is {0}% full. Pipe 1: {1:f0}%. Pipe 2: {2:f0}%.", Math.Round(obshtProcentOtBaseina), Math.Round(procentOtPipe1), Math.Round(procentOtPipe2));
                }
                else {
                    var prelqliLitri = obshtoLitri - litriNaBaseina;
                    if (prelqliLitri < 0) { prelqliLitri = 0; }
                    Console.WriteLine("For {0} hours the pool overflows with {1} liters.", hours, prelqliLitri);
                }

            }
        }
    }
}


