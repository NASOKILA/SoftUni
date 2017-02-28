        using System;
        using System.Globalization;

class HolidaysBetweenTwoDates
    {
        static void Main()
        {

        /*You are given a program (existing source code) that aims to count the non-working days between two dates given 
         in format day.month.year (e.g. between 1.05.2015 and 15.05.2015 there are 5 non-working days – Saturday and Sunday).*/



        DateTime startDate = DateTime.ParseExact(Console.ReadLine(),
         "d.M.yyyy", CultureInfo.InvariantCulture);
        DateTime endDate = DateTime.ParseExact(Console.ReadLine(),
            "d.M.yyyy", CultureInfo.InvariantCulture);
        int holidaysCount = 0;
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            if (date.DayOfWeek == DayOfWeek.Saturday ||
                date.DayOfWeek == DayOfWeek.Sunday) holidaysCount++;
        Console.WriteLine(holidaysCount);
    }
}

    //There are 4 mistakes in the code. You’ve got to use the debugger to find them and fix them. 

    // V JUDJA DAVA 100 OT 100 A TUKA NE TRUGVA !!!
