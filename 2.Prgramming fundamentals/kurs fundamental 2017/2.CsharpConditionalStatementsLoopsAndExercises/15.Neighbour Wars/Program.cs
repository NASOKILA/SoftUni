using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Neighbour_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            int peshosDamage = int.Parse(Console.ReadLine());
            int goshosDamage = int.Parse(Console.ReadLine());

            string oddAttacker = "Pesho";
            string evenAttacker = "Gosho";

            string peshosAttack = "Roundhouse kick";
            string goshosAttack = "Thunderous fist";

            int peshosHelth = 100;
            int goshosHelth = 100;

            string winner = string.Empty;
            int rounds = 0;
            int[] everyThreeRounds = { 3,6,9,12,15,18,21,24,27,30,33,36,41,44,47,50};
            while(peshosHelth > 0 && goshosHelth > 0)
            {
                rounds++;
                goshosHelth = goshosHelth - peshosDamage;
                if (goshosHelth <= 0 || peshosHelth <= 0) { break; }
                Console.WriteLine($"{oddAttacker} used {peshosAttack} and reduced Gosho to {goshosHelth} health.");
                
                if (everyThreeRounds.Contains(rounds))
                {
                    goshosHelth = goshosHelth + 10;
                    peshosHelth = peshosHelth + 10;
                }

                rounds++;
                peshosHelth = peshosHelth - goshosDamage;
                if (goshosHelth <= 0 || peshosHelth <= 0) { break; }
                Console.WriteLine($"{evenAttacker} used {goshosAttack} and reduced Pesho to {peshosHelth} health.");
                
                if (everyThreeRounds.Contains(rounds))
                {
                    goshosHelth = goshosHelth + 10;
                    peshosHelth = peshosHelth + 10;
                }

            }


            if (goshosHelth <= 0 && peshosHelth <= 0)
            {
                if (goshosHelth < peshosHelth)
                    winner = "Pesho";
                else
                    winner = "Gosho";
            }
            else
            {
                if (goshosHelth <= 0)
                    winner = "Pesho";
                else if (peshosHelth <= 0)
                    winner = "Gosho";
            }

            Console.WriteLine( $"{winner} won in {rounds}th round.");

        }
    }
}
