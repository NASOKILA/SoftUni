using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Regexmon
{
    class Regexmon
    {
        static void Main(string[] args)
        {
            //^\b[a-zA-Z]+\-[a-zA-Z]+\b    didimon

            int counter = 0;
            string input = Console.ReadLine();

            while (true)
            {
               // string didimonPattern = @"^[^a-zA-Z\-]+";
              //  string bojomonPattern = @"^\b[a-zA-Z]+\-[a-zA-Z]+\b";
               // Regex bojoregex = new Regex(bojomonPattern);
              //  Regex didiRegex= new Regex(bojomonPattern);

                if(counter % 2 == 0)
                {

                    MatchCollection didiMatches = Regex.Matches(input
                  , @"[^a-zA-Z-]+");

                    foreach (var match in didiMatches)
                    {

                        string partToRemove = match.ToString();
                        char firstElem = partToRemove.First();
                        int lastIndex = 0;

                        while (true)
                        {
                            if (input.IndexOf(firstElem) == 0)
                                break;

                            input = input.Remove(0, 1);
                        }

                       
                        Console.WriteLine(partToRemove);
                        //int indexOfElementToRemove = input.IndexOf(partToRemove);
                        input = input.Remove(0, partToRemove.Length);
                        break;
                    }

                    if (didiMatches.Count == 0)
                        break;
                    counter++;
                }







                if (counter % 2 == 1)
                {

                    MatchCollection bojoMatches = Regex.Matches(input
                    , @"\b[a-zA-Z]+\-[a-zA-Z]+\b"
                    , RegexOptions.Multiline);

                    foreach (var match in bojoMatches)
                    {
                        string partToRemove = match.ToString();

                        char firstElem = partToRemove.First();
                        int lastIndex = 0;

                        while (true)
                        {
                            if (input.IndexOf(firstElem) == 0)
                                break;

                            input = input.Remove(0, 1);
                        }

                        Console.WriteLine(partToRemove);
                        //int indexOfElementToRemove = input.IndexOf(partToRemove);
                        input = input.Remove(0, partToRemove.Length);
                        break;
                    }

                    if (bojoMatches.Count == 0)
                        break;
                    counter++;


                }





            }

        }
    }
}
