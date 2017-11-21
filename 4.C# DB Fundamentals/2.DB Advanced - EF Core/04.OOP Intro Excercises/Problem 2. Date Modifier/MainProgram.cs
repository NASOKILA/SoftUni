using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static void Main(string[] args)
    {
        string[] dateOne = Console.ReadLine()
                    .Split()
                    .ToArray();
        string date1 = dateOne[0] + '/' + dateOne[1] + '/' + dateOne[2];

        string[] dateTwo = Console.ReadLine()
                    .Split()
                    .ToArray();
        string date2 = dateTwo[0] + '/' + dateTwo[1] + '/' + dateTwo[2];

        DateModifier dateModifier = new DateModifier(date1, date2);

        Console.WriteLine(dateModifier);



    }
}

    