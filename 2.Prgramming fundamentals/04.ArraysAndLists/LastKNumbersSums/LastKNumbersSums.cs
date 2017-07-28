using System;


namespace LastKNumbersSums
{
    public class LastKNumbersSums
    {
        public static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long k = long.Parse(Console.ReadLine());
            long[] seq = new long[n];
               
            seq[0] = 1; // purviq element e 1

            for (long i = 1; i < n; i++)  // n puti     zapochva ot vtoriq element
            {
                long sum = 0; // na vsqka vrutka sumata e =  na 0

                for (long j = i-k; j <= i-1; j++) // ot   i-k   do   i-1   vinagie se vurti   k   puti
                {
                    if (j >= 0) 
                    {
                        sum += seq[j];
                    }

                }
                seq[i] = sum;
              
            }


            for (int i = 0; i < n; i++)
            {
                Console.Write(seq[i] + " ");
                Console.WriteLine();
            }

        }
    }
}
