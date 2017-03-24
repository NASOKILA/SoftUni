using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace WordsCount
{
    class WordsCount
    {
        static void Main(string[] args)
        {
            File.WriteAllText("Words.txt", "quick is fault");
            string words = File.ReadAllText("Words.txt"); // we read Words.txt and put it into 'file'
            string[] wordsArr = words.ToLower().Split().ToArray();            // we split the text in 'file' into words 

            // PRAVIM DUMITE DA SA MALKI

            Dictionary<string, int> matchedWordsAndCount = new Dictionary<string, int>();
          


            string inputFile = File.ReadAllText("input.txt");
            string[] text = inputFile.ToLower().Split(' ', ',', '.', '-', '!', '?').ToArray();
            // I TUK PRAVIM DUMITE DA SA MALKI


            foreach (var word in text)
            {
                int counter = 0;
                foreach (var inputWord in wordsArr)
                {
                    
                    if (word.Equals(inputWord))
                    {
                        counter++;
                        if(matchedWordsAndCount.ContainsKey(inputWord))
                            matchedWordsAndCount[inputWord] += counter;
                        else
                            matchedWordsAndCount[inputWord] = counter;

                    }
                }

            }

            //suzdavame si faila za resultata output
            File.WriteAllText("output.txt", "");  // prazen e  TAKA GO SUZDAVAME

            foreach (var pair in matchedWordsAndCount.OrderByDescending(w => w.Value))
            {
              File.AppendAllText("output.txt", $"{pair.Key} - {pair.Value}" + "\r\n");
                // ZA DA GI VMUKNEM TRQBVA DA IZPOLZVAME PLACE HOLDERI
            }

           
        }
    }
}
