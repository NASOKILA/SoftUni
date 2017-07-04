using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Ladybugs
{
    class Ladybugs
    {
        static void Main(string[] args)
        {
            int sizeOfTheField = int.Parse(Console.ReadLine());

            List<int> indexesOfAllLadybugs = Console.ReadLine()
                .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            int[] initialField = new int[sizeOfTheField];

            SetInitialField(initialField, indexesOfAllLadybugs);


            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandStr = command
                    .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int ladyBugIndex = int.Parse(commandStr[0]);
                string direction = commandStr[1];
                int flyLength = int.Parse(commandStr[2]);

                if (direction == "left")
                    MoveLadyBugToLeft(ladyBugIndex, flyLength, initialField);
                else if (direction == "right")
                    MoveLadyBugToRight(ladyBugIndex, flyLength, initialField);

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", initialField));

        }

        private static void MoveLadyBugToRight(int ladyBugIndex, int flyLength, int[] initialField)
        {

            if (flyLength < 0)
            {
                MoveLadyBugToLeft(ladyBugIndex, Math.Abs(flyLength), initialField);
                return;
            }


            if ((ladyBugIndex >= 0 && ladyBugIndex <= initialField.Length) && initialField[ladyBugIndex] != 0)
            {  // if there is a ladybug at that index and if it's a valid index

                initialField[ladyBugIndex] = 0; // delete that ladybug
                while (true) // dokato ne namerim svobodno mqsto za da stupne ladybuga
                {
                    if (ladyBugIndex + flyLength >= initialField.Length) // ako indexsa izliza breikvame
                        break;
                    if (initialField[ladyBugIndex + flyLength] == 0)
                    {
                        initialField[ladyBugIndex + flyLength] = 1;
                        break;
                    }
                    ladyBugIndex++;
                }
            }
        }

        private static void MoveLadyBugToLeft(int ladyBugIndex, int flyLength, int[] initialField)
        {
            if ((ladyBugIndex >= 0 && ladyBugIndex <= initialField.Length) && initialField[ladyBugIndex] != 0)
            {  // if there is a ladybug at that index and if it's a valid index

                if (flyLength < 0)
                {
                    MoveLadyBugToRight(ladyBugIndex, Math.Abs(flyLength), initialField);
                    return;
                }

                initialField[ladyBugIndex] = 0; // delete that ladybug
                while (true) // dokato ne namerim svobodno mqsto za da stupne ladybuga
                {
                    if (ladyBugIndex - flyLength < 0) // ako indexsa izliza breikvame
                        break;
                    if (initialField[ladyBugIndex - flyLength] == 0)
                    {
                        initialField[ladyBugIndex - flyLength] = 1;
                        break;
                    }
                    ladyBugIndex--;
                }
            }
        }

        private static void SetInitialField(int[] initialField, List<int> indexesOfAllLadybugs)
        {
            foreach (var index in indexesOfAllLadybugs)
            {
                if (index >= 0 && index <= initialField.Length)
                    initialField[index] = 1;
            }
        }
    }
}
