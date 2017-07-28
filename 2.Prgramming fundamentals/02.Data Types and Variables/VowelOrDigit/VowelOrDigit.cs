using System;

   namespace VowelOrDigit
{
    public class VowelOrDigit
    {
        public static void Main(string[] args)
        {
            // Five of the 26 alphabet letters are vowels: A, E, I, O, and U.

            char input = char.Parse(Console.ReadLine());
            
            string result = input.ToString().ToLower();

            if ((input >= (char)48) && (input <= (char)57))
            {
                result = "digit";
            }
             else if(result == "a" ||  result == "e" || result == "i" || result == "o" || result == "u")
            {
                result = "vowel";
            }
            else { result = "other"; }

            Console.WriteLine(result);
        }
    }
}
