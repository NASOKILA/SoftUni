using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace fileDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            //CHETENE:

            string file = File.ReadAllText("textFile.txt"); // VZIMA TEKSTOVIQ FAIL I GO SLAGA V STRINGOVA PROMENLIVA
            // papkata trqbva da e vuv   C:\Users\nasko\Desktop\FilesDirectoriesAndExceptions\fileDemos\bin
            Console.WriteLine(file);


            string[] file2 = File.ReadAllLines("textFile2.txt");
            //ReadAllLines Vzima tova koeto e vuv faila no go chete list po list => go slaga v masil ili list 
            Console.WriteLine(string.Join(",\n", file2));


            // ReadAllBytes vrushta byte masiv moje da chete vsichko samoche ni trqbvat nqkakvi biblioteki


            //PISANE:
            /*
             Za pisaneto ni imame: 
             
             WriteAllText(); //Vzima text i go slaga vuv faila
             
             writeAllLines(); // vzima kolekciq i q pishe vuv faila red po red
            */

            File.WriteAllText("output.txt", file); // v sluchaq slagame textfile.txt v output
            
            File.WriteAllLines("output2.txt", file2); // prezapisvame kolekciqta t.e. masiva v output2


            //PREZAPISVANE:
            /* Ako napishem
            File.WriteAllText("output.txt", file2[0]); // pishem samo purviq red ot file2
            //NO TO TRIE VSICHKO OSTANALO
            // ZA da se izbegne tova imame AppendAllText(), AppendAllLines()
            */
            Console.WriteLine(); Console.WriteLine();

            File.AppendAllText("output.txt", file2[0]); // SEGA VECHE DOBAVQ REDA NAKRAQ BEZ DA TRIE NISHTO
            string output = File.ReadAllText("output.txt");
            Console.WriteLine(output);

            Console.WriteLine();

            //IMAME I File.AppendAllLines("output.txt", file2[0]); 
            File.AppendAllLines("output2.txt", file2); // SLAGAME File2 OSHTE EDIN PUT            
            string[] output2 = File.ReadAllLines("output2.txt");
            Console.WriteLine(string.Join(",\n", output2));

            Console.WriteLine(); Console.WriteLine();



            //Klasyt  File.Info  ni dava poveche properties sudurjashti poveche informaciq za faila.
            FileInfo fInfo = new FileInfo("output.txt"); // SEGA IMAME DOSTUP DO CQLATA INFORMACIQ ZA TOZI FAIL!
            Console.WriteLine(fInfo.Name); // v sluchaq shte potpechatame samo imeto



            // TOVA E VSICHKO ZA FAILOVETE vsichko natam sa masivi i stringove i dr


        }
    }
}
