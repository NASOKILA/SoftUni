using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Povtoreniq__Cikli_
{
    class Program
    {
        static void Main(string[] args)
        {

            var citizensAbleToVote = int.Parse(Console.ReadLine()); ;
                  
            for (int Izbirateli = 1; Izbirateli <=
                citizensAbleToVote; Izbirateli++)
            {
                //tqlo na cikula
                var buletinNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Az glasuvah za {0}",buletinNumber);
            }

/*
 
             */


        }
    }
}
