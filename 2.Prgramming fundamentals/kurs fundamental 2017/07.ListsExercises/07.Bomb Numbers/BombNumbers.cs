using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.BombNumbers
{
    class BombNumbers
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            int[] bomb = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int bombNum = bomb[0];
            int bombPower = bomb[1];

            for (int i = 0; i < list.Count; i++)
            {

                var currentNum = list[i];
                if (currentNum == bombNum)
                {
                    var leftindex = Math.Max(i - bombPower, 0);
                    // ako stane po malko ot 0, vzimame 0

                    var rightindex = Math.Min(i + bombPower, list.Count-1);
                    // ako stane poveche ot duljinata na spisuka-1 vzimame duljinata na spisuka-1

                    var removeCount = rightindex - leftindex + 1;
                    list.RemoveRange(leftindex, removeCount);
                    i = -1;
                }
            }

            Console.WriteLine(list.Sum());
        }
    }
}
