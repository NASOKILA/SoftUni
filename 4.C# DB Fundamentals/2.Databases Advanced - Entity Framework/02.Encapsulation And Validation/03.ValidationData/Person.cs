using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Person
{
    //napravihme si constanta koqto e private, 
    //jivee v nashiq klas i nikoga ne se promenq !!!
    //Shte q polzvame vmesto da pishem prosto 3, PO DOBRA PRAKTIKA E !!!
    private const int minLength = 3;

    //Napravihme si i edna za salarito
    private const double minSalary = 460.0;

    private string firstName;
    private string lastName;
    private int age;
    private double salary;


    public Person(string firstName, string lastName, int age, double salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary; 
    }

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (value.Length < minLength)
                throw new ArgumentException("First name cannot be less than 3 symbols");
            this.firstName = value;
            
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (value.Length < minLength)
                throw new ArgumentException("Last name cannot be less than 3 symbols");            
            this.lastName = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {

            if (value <= 0)
                throw new ArgumentException("Age cannot be zero or negative integer");
            this.age = value;
            
        }
    }

    public double Salary
    {
        get { return this.salary; }
        set
        {
            if (value < minSalary)
                throw new ArgumentException("Salary cannot be less than 460 leva");
            this.salary = value; 
        }
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

