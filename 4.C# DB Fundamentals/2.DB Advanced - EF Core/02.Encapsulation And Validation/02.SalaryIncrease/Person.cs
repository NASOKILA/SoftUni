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
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
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

        //pravim setera da e private
        private set { this.salary = value; }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} get {this.Salary:f2} leva";
    }


    /*VAJNO : 
     Ne slagame 'static' zashtoto statichnite metodi imat
     dostup samo do statichni chlenove t.e. nqma kak da 
     polzvame 'this.' !!! 
     'main' metoda e statichen !!!*/
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

