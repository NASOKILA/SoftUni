using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Catch_the_Thief
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
            
            Console.WriteLine(thiefsId);
        }
    }
}
