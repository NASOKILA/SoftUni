using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02.LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
          
            string[] resultLines = lines
                .Select((l, i) => $"{i+1}.  " + l).ToArray();

            File.WriteAllLines("output.txt", resultLines);
            //Stava i s for cikul
        }
    }
}
