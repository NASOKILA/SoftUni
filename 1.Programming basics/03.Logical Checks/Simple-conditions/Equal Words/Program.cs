﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            string word2 = Console.ReadLine().ToLower();

            if (word == word2) {
                Console.WriteLine("yes");
            }
            else { Console.WriteLine("no"); }

        }
    }
}
