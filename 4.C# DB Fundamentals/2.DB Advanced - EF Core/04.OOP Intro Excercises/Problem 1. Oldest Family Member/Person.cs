using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Person
{
    private string name;
    private int age;

    List<int> ages = new List<int>();

    public Person(string name, int age)
    {
        ages.Add(age);
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            this.name = value;
        }
    }


    public int Age
    {
        get { return this.age; }
        set
        {
            this.age = value;
        }
    }


    public override string ToString()
    {
        return ($"{this.Name} {this.Age}");
    }


}

