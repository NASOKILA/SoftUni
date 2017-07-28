using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumAdjacentEqualNumbers
{
    class SumAdjacentEqualNumbers
    {
        static void Main(string[] args)
        {
            var items = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var nums = new List<int>(items);
            var result = new List<int>();

            int prevItem = 0;

            int counter = 0;
            while (counter < nums.Count) // 3 puti  pri   3 3 6 1 
            {            
                if (nums[counter] == prevItem) {
                    
                    nums[counter] = nums[counter] + prevItem;
                    nums.Remove(nums[counter-1]);
                    counter = 0;             
                }

                prevItem = nums[counter];
                counter++;
            }

            Console.WriteLine(string.Join(" ", nums));

        }
    }
}
