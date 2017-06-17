using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Sentence_the_Thief
{
    class Program
    {
        static void Main(string[] args)
        {

            string typeOfId = Console.ReadLine();

            long maxValue = 0L;
            switch (typeOfId)
            {
                case "sbyte":
                    maxValue = sbyte.MaxValue;
                    break;
                case "int":
                    maxValue = int.MaxValue;
                    break;
                case "long":
                    maxValue = long.MaxValue;
                    break;
            }


            int countOfIds = int.Parse(Console.ReadLine());
            long thiefsId = long.MinValue;


            for (int i = 0; i < countOfIds; i++)
            {
                long currentId = long.Parse(Console.ReadLine());
                if (currentId > thiefsId && currentId <= maxValue)
                {
                    thiefsId = currentId;
                }
            }



            //Console.WriteLine(thiefsId);

            double yearsOfSentence = 0.0;

            if (thiefsId >= sbyte.MinValue && thiefsId <= sbyte.MaxValue)
                yearsOfSentence = 1;
            else
            {
                if(thiefsId > sbyte.MaxValue)
                    yearsOfSentence = (thiefsId / (double)sbyte.MaxValue);
                else if(thiefsId < sbyte.MinValue)
                    yearsOfSentence = (thiefsId / (double)sbyte.MinValue);
            }


            Console.WriteLine("Prisoner with id {0} is sentenced to {1} {2}"
                , thiefsId
                , Math.Ceiling(yearsOfSentence)
                , Math.Ceiling(yearsOfSentence) > 1 ? "years" : "year");
            // Na poslednoto kazvame che ako godinite sa goveche ot 1 da pishe "years" inache "year"

        }
    }
}
