using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace _01.OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {

            string[] lines = File.ReadAllLines("input.txt");

            List<string> oddLines = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (i % 2 == 1)
                    oddLines.Add(lines[i]);
            }
                
            File.WriteAllLines("output.txt", oddLines);
            
            // I S TOVA LIN1 STAVA
           // List<string> oddLines2 = lines.Where((line,index) => index % 2 == 1).ToList();
            


        }
    }
}
