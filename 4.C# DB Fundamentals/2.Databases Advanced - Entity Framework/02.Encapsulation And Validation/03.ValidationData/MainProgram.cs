﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MainProgram
{
    static void Main(string[] args)
    {
        //DATA VALIDATION HAPPENS IN THE SETTERS !
        //USERS OF THAT CLASS NEED TO HANDLE THE EXCEPTION THROWN !

        var lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {

                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0],
                                        cmdArgs[1],
                                        int.Parse(cmdArgs[2]),
                                        double.Parse(cmdArgs[3]));

                persons.Add(person);
            
        }
        var bonus = double.Parse(Console.ReadLine());

        foreach (var person in persons)
        {
            person.IncreaseSalary(bonus);
        }

        persons.ForEach(p => Console.WriteLine(p.ToString()));



    }
}

