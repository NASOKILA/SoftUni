﻿using System;

class Program
{
    static void Main(string[] args)
    {

        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        try
        {
            Person person = new Person(name, age);


            Child child = new Child(name, age);
            Console.WriteLine(child);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}

