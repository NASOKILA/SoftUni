using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace FolderSize
{
    class FolderSize
    {
        static void Main(string[] args)
        {

            Directory.CreateDirectory("TestFolder"); // We create the folder


            string[] files = Directory.GetFiles("TestFolder");
            // TAKA VZIMAME VSICHKI FAILOVE V TAQ PAPKA
            double sizeSum = 0;

            foreach (string file in files)
            { // obhojdame vsichi failove 

                FileInfo fInfo = new FileInfo(file);   // FileInfo E KLAS   VAJNO
                // file info ni dava dostup do vsqkakva informaciq za failove i direktorii
                sizeSum += fInfo.Length;  // dobavqme length kum sum
            }

            sizeSum = sizeSum / 1024 / 1024;
            File.WriteAllText("output.txt", "");
            File.AppendAllText("output.txt", sizeSum.ToString());
            // slagame mu ToString() zashtoto ne moje samo da se transformira !



        }
    }
}
