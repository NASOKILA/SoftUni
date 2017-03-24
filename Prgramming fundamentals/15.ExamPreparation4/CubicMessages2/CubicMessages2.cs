using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CubicMessages2
{
    class CubicMessages2
    {
        static void Main(string[] args)
        {
            string inputMessage = Console.ReadLine();
            int lengthOfMessage = int.Parse(Console.ReadLine());

            //1234test4321

            while (true)
            {
                // string[] messageArgs = message.Split()
                string pattern = "^([0-9]+)([a-zA-Z]+)([^a-zA-Z]*)$";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(inputMessage);

                if (match.Success)
                {
                    List<char> numbersBeforeMessage = new List<char>();
                    string message = string.Empty;
                    List<char> numbersAfterMessage = new List<char>();
                    foreach (Match item in match)
                    {
                        numbersBeforeMessage = item.Groups[1].ToString().ToCharArray().ToList();
                        message = item.Groups[2].ToString();
                        numbersAfterMessage = item.Groups[3].ToString().ToCharArray().ToList();
                    }

                    bool containsLetterAtTheEnd = false;

                    if (!message.Equals(""))
                    {

                        int counter = inputMessage.Length - numbersAfterMessage.Count;
                        for (int i = inputMessage.Length - 1; i >= counter; i--)
                        {
                            if (Char.IsLetter(inputMessage[i]))
                                containsLetterAtTheEnd = true;
                        }

                        if (containsLetterAtTheEnd == false)
                            PrintResult(message, numbersBeforeMessage, numbersAfterMessage);

                    }

                }


                inputMessage = Console.ReadLine();
                if (inputMessage.Equals("Over!"))
                    break;
                lengthOfMessage = int.Parse(Console.ReadLine());

            }

        }

        private static void PrintResult(string message, List<char> numbersBeforeMessage, List<char> numbersAfterMessage)
        {

            Console.Write($"{message} == ");
            foreach (var num in numbersBeforeMessage)
            {
                int number = int.Parse(num.ToString());

                try
                {
                    Console.Write(message[number]);
                }
                catch (Exception)
                {
                    Console.Write(" ");
                }

            }

            foreach (var num in numbersAfterMessage)
            {
                int number = int.Parse(num.ToString());

                try
                {
                    Console.Write(message[number]);
                }
                catch (Exception)
                {
                    Console.Write(" ");
                }

            }
            Console.WriteLine();

        }
    }
}