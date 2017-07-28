using System;

namespace PriceChangeAlert
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());      
            double significance = double.Parse(Console.ReadLine());
            double firstPrice = double.Parse(Console.ReadLine());

            for (int i = 0; i < n - 1; i++)
            {
                double currentPrice = double.Parse(Console.ReadLine());
                double diference = FindPercentageDifference(firstPrice, currentPrice);
                bool isSignificantDifference = FindDiff(diference, significance);
                string message = GetChange(currentPrice, firstPrice, diference, isSignificantDifference);
                Console.WriteLine(message);
                firstPrice = currentPrice;
            }
        }

        private static string GetChange(double currentPrice, double firstPrice, double difference, bool etherTrueOrFalse)
        {
            string change = "";
            if (difference == 0)
            {
                change = string.Format("NO CHANGE: {0}", currentPrice);
            }
            else if (!etherTrueOrFalse)
            {
                change = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", firstPrice, currentPrice, difference * 100);
            }
            else if (etherTrueOrFalse && (difference > 0))
            {
                change = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", firstPrice, currentPrice, difference * 100);
            }
            else if (etherTrueOrFalse && (difference < 0))
            {
                change = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", firstPrice, currentPrice, difference * 100);
            }
            return change;
        }

        private static bool FindDiff(double difference, double significance)  // namira razlika 
        {
            if (Math.Abs(difference) >= significance)
            {
                return true;
            }
            return false;
        }

        private static double FindPercentageDifference(double firstPrice, double currentPrice) // Namira procent !
        {
            double r = (currentPrice - firstPrice) / firstPrice;
            return r ;
        }
    }
}
// CONTROL + K + D    direktno redaktira koda i go podrejda !!!  VAJNO!!!