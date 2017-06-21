using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SearchForANumber
{
    class SearchForANumber
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            int[] threeNumsArray = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int numOfElementsToTakeFromTheList = threeNumsArray[0];
            int numOfElementsToDeleteFromTheTakenNums = threeNumsArray[1];
            int searchedNumInTheListAfterManiulation = threeNumsArray[2];

            List<int> takenElements = numbers.Take(numOfElementsToTakeFromTheList).ToList();

            takenElements.RemoveRange(0, numOfElementsToDeleteFromTheTakenNums);

            if(takenElements.Contains(searchedNumInTheListAfterManiulation))
                Console.WriteLine("YES!");
            else
                Console.WriteLine("NO!");


        }
    }
}
