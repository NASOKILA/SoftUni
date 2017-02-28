using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountNumbers
{
    class CountNumbers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var nums= new List<int>(input);
            nums.Sort(); // sortirame

            var position = 0;
            while (position < nums.Count)
            {
                int n = nums[position];
                int count = 0;
                while (position + count < nums.Count && nums[position + count] == n)
                {//dali poziciata + counta e po malko ot duljinata na masiva i dali chisloto koeto e na [position + count] e ravno na n
                 // ako e sushtoto chislo uvelichavame count s 1
                 // v tozi while gledame kolko puti se sudurja sushtoto chislo
                    count++;
                }

                position = position + count;
                Console.WriteLine("{0} -> {1}",n,count );
            }

        }
    }
}
