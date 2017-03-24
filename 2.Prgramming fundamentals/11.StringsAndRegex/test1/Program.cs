using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelrahShake
{
    class MelrahShake
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bankroll: 100lv");
            Console.WriteLine("Bets: 10%, 3 times per week");
            Console.WriteLine("Average odd = 2.16");
            Console.WriteLine("The system is: 2 wins 1 loss");
            Console.WriteLine("Input months: ");
            int months = int.Parse(Console.ReadLine());

            Console.WriteLine("Input Bankroll:");
            double bankroll = double.Parse(Console.ReadLine());

            double bet = bankroll / 10;
            double averageOdd = 2.16;
            int betsPerWeek = 3;
            int betsPerMonth = betsPerWeek * 4;
            int losses = 0;
            int wins = 0;
            // wwl wwl wwl wwl

            for (int j = 0; j < months; j++)
            {


                for (int i = 1; i <= betsPerMonth; i++)
                {
                    if (i == 3 || i == 6 || i == 9 || i == 12)
                    {
                        bankroll -= bet;
                        losses++;
                    }
                    else
                    {
                        bankroll += bet * averageOdd;
                        bankroll -= bet;
                        bet = bankroll / 10;
                        if (bet > 33000) { bet = 33000; }
                        wins++;
                    }


                }
            }
            double totalProfit = bankroll - 100.00;

            Console.WriteLine("Total Profit: {0}", totalProfit);
            Console.WriteLine("Total wins: {0}", wins);
            Console.WriteLine("Total losses: {0}", losses);

        }
    }
}
