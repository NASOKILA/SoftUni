using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace fileDemos
{
    class fileDemos
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
            /* 
            
            Ako napishem
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



            // DIREKTORII, NACHINA NA RABOTA S TQH E KATO PRI FAILOVETE
           
            /*         
             Imame :
             
             CreateDirectory()     suzdava papkata i VSICHKI PODPAPKI OSVAN AKO NE SA VECHE SUZDADENI !
             DeleteDirectory()     za da se iztrie TRQBVA DA E PRAZNA PAPKATA !
             MoveDirectory()       moves a file or a direktory to a new location ! MOJE I DA PREIMENUVA EDNA PAPKA

             PAPKITE SUDURJAT:
             GetFiles()  vrushta imeto na faila i celiq pud predi neq v dadena papka
             GetDirectories() vrushta imenata i subPapkite v podadenata papka

             s tezi dve komandi vzimame informaciqta v dadena papka
             */



           /*WHAT ARE EXEPTIONS ?
             Kakvo sa greskite i izklucheniqta
             
             Tova sa neshta koito se sluchvat a programata ne gi ochakva,
             v povecheto puti e greshka na usera
             IMA MNOGO VIDOVE EXEPTIONI
             SystemExeption - tova sa greshki pri izchisleniq parsvane, nedostig na pamet,
             daden element e null, delenie na nula, prenatovarvane i drugi podobni
             IOExeption - e kogato neshto se prenatovari, kogato daden fail ili papkq ne sushtestvuvat !

             Imame i AplicationExeption

             S exeptionite se raboti po lesno !

            
             IMAME KLAS System.Exception KOITO E ZA VSICHKI GRESHKI V .NET, DAVE NI INFO ZA GRESHKATA
             Message sus opisanie na greshkata i StackTrece sus info za kakvo se sluchva v momenta na greshkata
             */

             /*
             Handling Exceptions : 
             KAK SE HVASHTAT GRESHKI ?          
             */


            //primer
            string str = "naso";

            try
            {
                //int integer = int.Parse(str);
                File.ReadAllText("naso.txt");  // TOVA E GRESHKA ZASHTOTO NQMAME TAKUV FAIL
            }
            catch (FileNotFoundException Err) // FileNotFoundException  e za failove koito ne sushtestvuvat
            {
                Console.WriteLine(Err.Message);
            }
            catch (FormatException Err) // FormatException   tova e za formatirashti greshki, kato pri parsvaneto
            {
                Console.WriteLine(Err.Message);
            }
            catch (Exception Err)  // TOVA HVASHTA VSICHKI GRESHKI
            {
                
                Console.WriteLine(Err.Message); // TOVA SHTE NI POKAJE TOCHNO KAKVA E PRICHINATA ZA GRESHKATA VAJNO
            }

            // taka se spravqme s greshkite, tozi metod ni pozvolqva da produljim napred s programata dori i da ima greshki!

            //AKO EDINIQ catch SE IZPULNI, DRUGTE NE SE IZPULNQVAT

            // HUBAVO E DA HVURLQME exeptioni ZA DA PROVERQVAME TOCHNO KAKVA E GRESHKATA I KADE SE NAMIRA





            /*
            Try-finally Statements :
            
            
            try
            {
                // daden kod 
            } 
            finally
            {
                // IZPULNQVA SE PRI VSICHKI SLUCHAI, DORI I DA NQMA GRESHKA V try Bloka
            }
             
            VUV FINALLY MOJEM DA POLZVAME NESHTATA DEFINIRANI VUV TRY I V CATCH BLOKOVETE
            IZPLOZVA SE POVECHE PRI RABOTA S FAILOVE, KAZVA: OPITAI SE DA OTVORISH FAILA I NAKRAQ VUV FINALLY GO ZATVORI

            */


            /*
             try-catch-finally:
             
             Nai izpolzvanoto e try-catch-finally
            
            try
            {
                // probvai dali shte stane, ako stane izpulni koda v try
            } 
            catch
            {
                // izpulni se ako ima greshka izpulni koda v catch
            } 
            finally
            {
                // izpulni se kakvoto i da stane
            }
             
             */



            /*
             SUMMARY:
             s klasa File mojem da suzdavame , promenqme i triem failove.
             s klasa Directory mojem da suzdavame, triem i promenqme i obhojdame papki.
             s exeptionite se spravqme s greshkite. 

             
             
             */




        }
    }
}
