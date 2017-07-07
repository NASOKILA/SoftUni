using System;

namespace _01.CharityMarathon
{
    class CharityMarathon
    {
        static void Main(string[] args)
        {

            short daysOFMarathon = short.Parse(Console.ReadLine());
            long runnersCount = long.Parse(Console.ReadLine());
            byte lapsCount = byte.Parse(Console.ReadLine());
            long trackLength = long.Parse(Console.ReadLine());
            short trackCpacity = short.Parse(Console.ReadLine());
            decimal moneyPerKm = decimal.Parse(Console.ReadLine());

            long maxRunners = daysOFMarathon * trackCpacity;
            long runners = Math.Min(maxRunners, runnersCount);

            decimal totalMeters = runners * lapsCount * trackLength;
            long totalKilometers = (long)(totalMeters / 1000);
            decimal moneyRaisedForTheMarathon = moneyPerKm * totalKilometers;

            Console.WriteLine($"Money raised: {moneyRaisedForTheMarathon:F2}");

        }
    }
}


/*
  ALL INTEGER TYPE : varirat ot  -2 miliarda do 2 miliarda   
            sbyte [-128,...127] 8 bit
            byte [0,...255] unshort 8 bit
            short [-32 768,... 32 767] 16 bit
            ushort [0,...65 535] unshort 16 bit
            int [-2 147 483 648,...2 147 483 647] 32 bit
            uint[0,...4 294 967 295] uint 32 bit
            long[-9 223 372 036 854 755 808,...9 223 372 036 854 755 807] unshort 64 bit
            ulong[0...18 446 744 073 709 551 615] ulong 64 bit
 */
