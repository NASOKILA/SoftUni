using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace MergeFiles
{
    class MergeFiles
    {
        static void Main(string[] args)
        {
            File.WriteAllText("input1.txt", "1" + "\r\n" + "2" + "\r\n" + "3");
            File.WriteAllText("input2.txt", "4" + "\r\n" + "5" + "\r\n" + "6");

            string file1 = File.ReadAllText("input1.txt");
            string file2 = File.ReadAllText("input2.txt");

            File.WriteAllText("output.txt", file1);
            File.AppendAllText("output.txt", "\r\n" + file2);
        }
    }
}
