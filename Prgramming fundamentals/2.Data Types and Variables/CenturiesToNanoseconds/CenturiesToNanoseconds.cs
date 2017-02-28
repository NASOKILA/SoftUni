using System;
using System.Numerics;  // tova ni trqbva za BigInteger !!!

namespace CenturiesToNanoseconds
{
   public class CenturiesToNanoseconds
    {
       public static void Main(string[] args)
        {

            byte centuries = byte.Parse(Console.ReadLine());
            short years = (short)(centuries * 100);
            uint days = (uint)(years * 365.2422);
            ulong hours = days * 24;
            ulong minutes = hours * 60;
            ulong seconds = minutes * 60;
            ulong milliseconds = (seconds * 1000);
            decimal microseconds = (decimal)(milliseconds * 1000);
            BigInteger nanosecond = (BigInteger)(microseconds * 1000);

            /*mojem da polzvame BIG INTEGER vmesto decimal no trqbva da dobavim referenciq kum edna biblioteka koqto
             se kazva System.Numerics  .  Otivame na references, davame dqsno kopche / add reference / System.Numerics 
             davame ok i to se importva samo , SEGA VECHE MOJEM DA POLZVAME  BIG INTEGER !!!*/

            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes = {5} seconds = {6} milliseconds = {7} microseconds = {8} nanoseconds",
            centuries,years,days,hours,minutes,seconds,milliseconds,microseconds,nanosecond);
        }
    }
}
