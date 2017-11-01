using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private double salary;


    public Person(string firstName, string lastName, int age, double salary)
    {


        if (firstName.Length < 3)
        {
            throw new ArgumentException("First name cannot be less than 3 symbols");
        }
        else
        {
            this.firstName = firstName;
        }

        if (lastName.Length < 3)
        {
            throw new ArgumentException("Last name cannot be less than 3 symbols");
        }
        else
        {
            this.lastName = lastName;
        }

        if (age <= 0)
        {
            throw new ArgumentException("Age cannot be zero or negative integer");
        }
        else
        {
            this.age = age;
        }

        if (salary < 460.0)
        {
            throw new ArgumentException("Salary cannot be less than 460 leva");
        }
        else
        {
            this.salary = salary;
        }
        
    }

    public string FirstName
    {
        get { return this.firstName; }
        set { this.firstName = value; }
    }

    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public double Salary
    {
        get { return this.salary; }
        set { this.salary = value; }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} get {this.Salary:f2} leva";
    }

    public void IncreaseSalary(double bonus)
    {

        if (this.Age < 30)
        {
            this.Salary += (((bonus * salary * 0.1) / 10) / 2);
        }
        else
        {
            this.Salary += ((bonus * salary * 0.1) / 10);
        }

    }


}

