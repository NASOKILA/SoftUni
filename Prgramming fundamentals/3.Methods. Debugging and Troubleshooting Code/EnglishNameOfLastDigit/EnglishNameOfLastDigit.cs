using System;


namespace EnglishNameOfLastDigit
{
    public class EnglishNameOfLastDigit
    {
        
        static string PrintNameInEnglish(long a) {

            long lastDigit = Math.Abs(a % 10);    // moje da e minus

            string result = "";

            if (lastDigit == 0) { result = "zero"; }
            else if (lastDigit == 1) { result = "one"; }
            else if (lastDigit == 2) { result = "two"; }
            else if (lastDigit == 3) { result = "three"; }
            else if (lastDigit == 4) { result = "four"; }
            else if (lastDigit == 5) { result = "five"; }
            else if (lastDigit == 6) { result = "six"; }
            else if (lastDigit == 7) { result = "seven"; }
            else if (lastDigit == 8) { result = "eight"; }
            else if (lastDigit == 9) { result = "nine"; }

            return result;
        }

        public static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());   
           
            string result = PrintNameInEnglish(n);    //  PRI DEBUGVANE S F11 SE VLIZA V METODITE !!!
            Console.WriteLine(result);       
        }
    }
}
