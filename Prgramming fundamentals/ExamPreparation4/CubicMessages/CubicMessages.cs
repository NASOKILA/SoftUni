using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CubicMessages
{
    class CubicMessages
    {
        static void Main(string[] args)
        {
            string inputMessage = Console.ReadLine();

            while (!inputMessage.Equals("Over!"))
            {

                int count = int.Parse(Console.ReadLine());


                string pattern = "^([0-9]+)([a-zA-Z]{" + count + "})([^a-zA-Z]*)$";  // TAKA VKARVAME PROMENLIVI V REGEKSA
                Regex regex = new Regex(pattern);
                Match matche = regex.Match(inputMessage);



                if (matche.Success)  // ako ima machove
                {
                    string message = matche.Groups[2].ToString();
                    Console.Write(message + " == ");
                    List<int> indexes = GetIndexes(matche);



                    foreach (var i in indexes)
                    {
                        if (0 <= i && i < message.Length)
                        {
                            Console.Write(message[i]);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }




                //bool containsLetterAtTheEnd = false;

                //if (!message.Equals(""))
                //{

                //    int counter = inputMessage.Length - numbersAfterMessage.Count;
                //    for (int i = inputMessage.Length-1; i >= counter; i--)
                //    {
                //        if (Char.IsLetter(inputMessage[i]))
                //            containsLetterAtTheEnd = true;                     
                //    }

                //    if(containsLetterAtTheEnd == false)
                //        PrintResult(message, numbersBeforeMessage, numbersAfterMessage);

                //}

                inputMessage = Console.ReadLine();



            }

        }

        private static List<int> GetIndexes(Match matche)
        {

            List<int> indexes = new List<int>();
            string left = matche.Groups[1].ToString();
            for (int i = 0; i < left.Length; i++)
            {
                // AKO E CHISLO GO SLAGAME V INDEXES
                if(Char.IsDigit(left[i]))
                    indexes.Add(int.Parse(left[i].ToString()));
            }


            string right = matche.Groups[3].ToString();
            for (int i = 0; i < right.Length; i++)
            {
                // AKO E CHISLO GO SLAGAME V INDEXES
                if (Char.IsDigit(right[i]))
                    indexes.Add(int.Parse(right[i].ToString()));
            }


            return indexes;
        }
    }
}
      