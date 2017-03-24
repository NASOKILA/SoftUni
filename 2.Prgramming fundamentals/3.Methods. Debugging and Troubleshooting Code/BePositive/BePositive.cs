using System;
using System.Collections.Generic;

public class BePositive_broken
{
    public static void Main()
    /* ALL INTEGER TYPE : varirat ot  -2 miliarda do 2 miliarda   
        sbyte [-128,...127] 8 bit
        byte [0,...255] unshort 8 bit
        short [-32 768,... 32 767] 16 bit
        unshort [0,...65 535] unshort 16 bit
        int [-2 147 483 648,...2 147 483 647] 32 bit
        uint[0,...4 294 967 295] unshort 32 bit
        long[-9 223 372 036 854 755 808,...9 223 372 036 854 755 807] unshort 64 bit
        undlong[0...18 446 744 073 709 551 615] 64 bit
*/
    {
        byte countSequences = byte.Parse(Console.ReadLine());

        if (countSequences > 0 && countSequences <= 15)
        {

            for (int i = 0; i < countSequences; i++)
            {
                string[] input = Console.ReadLine().Trim().Split(' ');

                var numbers = new List<short>();

                for (int j = 0; j < input.Length; j++)
                {
                    if (!input[j].Equals(string.Empty))
                    {
                        short num = short.Parse(input[j]); // parsvame chislata 

                        if (num < -1000 || num > 1000) { break; }
                        numbers.Add(num); // slagame chislata v numbers bez intervalite
                    }
                }

                if (numbers.Count < 1 || numbers.Count > 20) { break; }
                else
                {

                    bool found = false;

                    for (int j = 0; j < numbers.Count; j++) // do duljinata na noviq masiv
                    {

                        int currentNum = numbers[j];

                        if (currentNum >= 0) // ako chisloto e > o go printirame
                        {
                            if (found)
                            {
                                Console.Write(" ");
                            }

                            if (j == numbers.Count - 1) { Console.WriteLine(currentNum); }
                            else { Console.Write(currentNum); }

                            found = true;
                        }
                        else
                        {
                            currentNum += numbers[j + 1]; // ako chisloto e < 0 go subirame sus sledvashtoto
                                                          // i posle go printirame
                            if (currentNum >= 0)
                            {
                                if (found)
                                {
                                    Console.Write(" ");
                                }

                                if (j == numbers.Count - 1) { Console.WriteLine(currentNum); } // AKO E POSLEDNATA CIFRA, DA Q PRINTIRA I DA MINE NA NOV RED!
                                else { Console.Write(currentNum); } // AKO NE; DA PRINTIRA NA SUSHTIQ RED!

                                found = true;
                            }
                            j++; // UVELICHAVAME S 1 Za da ne gvashta sledvashtoto chislo koeto umnojihme s minusovoto !
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("(empty)");
                    }

                }// else

            }  // for

        } // if
    }
}