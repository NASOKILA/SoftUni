using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncreasingElements
{
    class IncreasingElements
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int length = 1;
            int prevNum = 1982470;
            List<int> groupsLength = new List<int>();
            
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > prevNum)
                {
                    length++;
                }
                if (length > 0 && num <= prevNum)
                {
                    groupsLength.Add(length);
                    length = 1;
                }

                prevNum = num;
            }

            groupsLength.Add(length);

            Console.WriteLine(groupsLength.Max());

        }
    }
}
