using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Heists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] priceOfJewelsAndGold = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int jewelsPrice = priceOfJewelsAndGold[0];
            int goldPrice = priceOfJewelsAndGold[1];

            string[] command = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int totalEarnings = 0;
            int totalExpences = 0;

            while (command[0] != "Jail" && command[1] != "Time")
            {
                int countOfJewels = 0;
                int countOfGold = 0;
                int expences = int.Parse(command[1]);

                totalExpences += expences;

                foreach (var item in command[0].ToString())
                {
                    if (item == '%')
                        countOfJewels++;
                    else if (item == '$')
                        countOfGold++;
                }

                int jewelsEarnings = countOfJewels * jewelsPrice;
                int goldEarnings = countOfGold * goldPrice;
                int earnings = jewelsEarnings + goldEarnings;
                totalEarnings += earnings;


                command = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            int moneyEarned = 0;
            int moneyLost = 0;

            if (totalEarnings >= totalExpences)
            {
                moneyEarned = totalEarnings - totalExpences;
                Console.WriteLine($"Heists will continue. Total earnings: {moneyEarned}.");
            }
            else
            {
                moneyLost = totalExpences - totalEarnings;
                Console.WriteLine($"Have to find another job. Lost: {moneyLost}.");
            }
        }
    }
}
