using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace _05.WriteToFile
{
    class WriteToFile
    {
        static void Main(string[] args)
        {

            var text = File.ReadAllText("../../Sample_text.txt");

         

           // char[] punctuations = { '.', ',', '!', '?', ':' };

            string result = string.Empty;

           
                foreach (var letter in text)
                {
                    if (letter != '.' && letter != ',' && letter != '!' && letter != '?' && letter != ':')
                        result += letter;
                }
                  

            File.WriteAllText("../../output.txt", result);
        }
    }
}
