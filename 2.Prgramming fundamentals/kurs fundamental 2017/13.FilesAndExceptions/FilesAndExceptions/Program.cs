using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText("input.txt");
            Console.WriteLine(text);

            File.WriteAllText("input.txt", "Zdr nasko");

            // imame i readAllLines() and writeAllLines() obche se polzvt s masivi za redovete

            File.AppendAllText("input.txt", "Zakachih te!" + Environment.NewLine);

            //S FileInfo() burkame za infrmaciq v daden fail

            var newFile = new FileInfo("input.txt");
            Console.WriteLine(newFile.Length);

            //FileInfo.Exist() koeto ne e funkciq no e properti koeto moje da ni pokaje dali sushtestvuva daden fail
            /*
              
             Statichno ozn che mojesh samo da viknesh metoda i linq, taka samiq metod se promenq 
            s referenciq e primerno 

             */



            //SUZDAVANE NA DIREKTORIQ
            //suzdadohme papka out v neq papka 1 i v neq papka 2
            Directory.CreateDirectory("out\\1\\2");
            //   ..\\ oznachava edin put nazad ot papkata debug

            //TRIENE NA DIREKTORIQ
            Directory.Delete("out", true); // opitvame da iztriem papkata out koqto suzdadohme v debug
                                           // obache ni davashe exception poneje ne e prazna i za tova mu davame "true" kato vtori parametur

            //PREMESTVANE NA DIREKTORIQ OT EDNO MQSTO NA DRUGO
            Directory.CreateDirectory("out\\1\\2"); //Purvo pak gi suzdavame
   //         Directory.Move("out", "..\\outMoved"); // we moved id outside th dir debug and we changed the name to outMoved
   // ToVA OBACHE SE PRAVI SAMO VEDNUJ INACHE POSLE NI DAVA EXCEPTION



            // GET ALL FILES OR ALL DIREKTORIES

            var allDirsInDebug = Directory.GetDirectories(@"C:\Users\nasko\Desktop\FilesAndExceptions\FilesAndExceptions\bin\Debug"); // vzimame papkite ot kudeto mu kajem da gi vzeme
            // sus @ eskeipvame chertichkite

            foreach (var dir in allDirsInDebug)
            {// papkite sa samo 2 : Nasko i out
                Console.WriteLine(dir);
            }


            //SUSHTOTO MOJEM DANAPTRAVIM ZA FAILOVETE SUS Directory.GetFiles








            // EXCEPTIONS AND HOW TO DEAL WITH THEM :

            /*   
                 kato grumne neshto ni se otvarq edno prozorche ot koeto 
                 mojem da daden na view details i da 
                 poluchim poveche info za tova kakvo stava
            
            KLASA SYSTEM:EXCEPTiON SUDURJA VSICHKI EXCEPTIONI, TOI E BAZOV KLAS 
            ZA EXCEPTIONI V .NET, SUDURJA INFO ZA TQH, DAVA SUOBSHTENIQ I STACKTrace
             
             Imame OverflowException : kogato neshto e mnogo dulgo
             NotFound : kogato neshto ne se namira
             FormatEcetion kogato formata e greshen
             IMA OSHTE MNOGO


            Hvashtat se s try i catch  i finally
            mojem da hvashame exceptioni na daden kod s edin try i catch  no 
            mojem i po otdelno, primerno ako imame 5 reda kod mojem s 5 try i catcha
            t.e. proverqvash vsqka operaciq po otelno 
            TOVA MOJE DA SE NAPRAVI I S METOD I TRY I CATCH DA SA V TOZI METOD, 
            NE E NUJNO DA PISHEM TEY I CATCH !== PUTI  !!!!!
             
            V skobite na catch mojem da hvane mrazlichni exceptioni 
            Za edin try moje da ima mnogo catchove za razlichni greshki


            Finally SE IZPULNQVA ZADULJITELNO NEZAVISIMO DALI IMA GRESHKA ILI NE
            I SE IZPULNQVA VINAGI NAKRAQ   
             
            Vuv finally mojem da zatvarqme failove close(); 
            NAI VAJNOTO PRI RABOTA S FAILOVE E DA SE ZATVARQT ZAASHTOTO 
            AKO ZABRAVIM POSLE NE MOJEM DA GI OTVORIM OTVUN.
             */

        }
    }
}
