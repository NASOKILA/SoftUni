using System;
using System.Collections.Generic;
using System.Linq;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {

            string resourse = Console.ReadLine();
            

            Dictionary<string, long> miner = new Dictionary<string, long>();


           //AKO IZPOLZVAME == SRUVNQVAME SAMO ADRESITE PO DOBRE DA POLZVAME Equals()
                while (!resourse.Equals("stop"))
                {

                    long quantity = long.Parse(Console.ReadLine());
                  
                    if (miner.ContainsKey(resourse))
                    {        
                        miner[resourse] += quantity;    
                    }
                    else
                    {
                        miner[resourse] = quantity;
                    }

                    resourse = Console.ReadLine();
                    

                }

                foreach (var pair in miner)
                {
                    Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
                }

            
        }
    }
}
