using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Worker : Human
{
    
    private decimal weekSalary;
    private decimal hoursPerDay;

    public Worker(string firstName, string lastName, 
                  decimal weekSalary, decimal hoursPerDay) 
        :base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.HoursPerDay = hoursPerDay;
    }
    

    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.weekSalary = value;
        }
    }


    public decimal HoursPerDay
    {
        get { return this.hoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.hoursPerDay = value;
        }
    }


    public string MoneyPerHour()
    {
        decimal result = (this.WeekSalary / 5) / this.HoursPerDay;
        string strResult = $"{result:f2}";
        return strResult;
    }


    public override string ToString()
    {
        string result =
                (
                      $"First Name: {this.FirstName}" + Environment.NewLine
                    + $"Last Name: {this.LastName}" + Environment.NewLine
                    + $"Week Salary: {this.WeekSalary:f2}" + Environment.NewLine
                    + $"Hours per day: {this.HoursPerDay:f2}" + Environment.NewLine
                    + $"Salary per hour: {this.MoneyPerHour():f2}"
                );

        return result;

    }


}

