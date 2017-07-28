using System;


namespace RoundingNumbersAwayFromZero
{
    public class RoundingNumbersAwayFromZero
    {
        public static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            string[] items = numbers.Split(' ');
            double[] Arr = new double[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                Arr[i] = double.Parse(items[i]);              
            }

            double[] Arr2 = new double[Arr.Length]; // suzdavam si vtori masiv koito shte izpolzvam kato kopie na purviq !
            
            for (int i = 0; i < Arr.Length; i++)
            {
                Arr2[i] = Arr[i]; // kopirame vtoriq i purviq
                Arr[i] = Math.Abs(Arr[i]); // vzimame absolutna stoinost
                Arr[i] = Arr[i] + 0.5; // dobavqme 5 i posle trunkirame
                if (Arr2[i] < 0) { Console.WriteLine(Arr2[i] + " => " +  "-" + Math.Truncate(Arr[i])); }
                else { Console.WriteLine(Arr2[i] + " => " + Math.Truncate(Arr[i])); }             
               
            }
            //  Math.Round(Arr2[i], RoundingNumbersAwayFromZero)  VAJNO !!!
            /* Math.Floor rounds down, Math.Ceiling rounds up, and Math.Truncate rounds towards zero. 
               Thus, Math.Truncate is like Math.Floor for positive numbers, and like Math.Ceiling for negative numbers.*/

        }
    }
}
