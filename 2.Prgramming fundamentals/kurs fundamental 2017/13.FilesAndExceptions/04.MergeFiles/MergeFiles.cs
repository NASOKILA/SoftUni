using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MergeFiles
{
    class MergeFiles
    {
        static void Main(string[] args)
        {
            List<string> linesOne = File.ReadAllLines("input1.txt").ToList();
            List<string> linesTwo = File.ReadAllLines("input2.txt").ToList();
            List<string> result = linesOne.Concat(linesTwo).ToList();

            File.WriteAllLines("output.txt", result);
         }
    }
}
