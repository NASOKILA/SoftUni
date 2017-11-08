using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//KATO MU DADEM public MOJEM DA GO NASLEDQVAME OT VSEKI PROEKT
public class Person
{

    //fields: 
    private string name;
    private int age;


    //constructors
    public Person()
    {

    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }


    //properties : PO DOBRE DA SA VIRTUALNI ZASHTOTOMOJE DA SE NALOJI 
    //DA GI PROMENQME V KLASA child
    
    public virtual string Name
    {
        get { return this.name; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");  
            }

            this.name = value;
        }
    }


    public virtual int Age
    {
        get { return this.age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }

            this.age = value;
        }
    }


    //Sega kato izvikame child vuv Console.WriteLine();
    public override string ToString()
    {
        return ($"Name: {this.Name}, Age: {this.Age}");
    }

}

    