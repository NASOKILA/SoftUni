using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CompanyRoaster
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Employee> employees = new List<Employee>();

        Dictionary<string, List<decimal>> departmentsAndSalariesList = 
        new Dictionary<string, List<decimal>>();

        
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            Employee employee = new Employee();

            if (input.Length == 6)
            {
                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];
                string email = input[4];
                int age = int.Parse(input[5]);

                employee.Name = name;
                employee.Salary = salary;
                employee.Position = position;
                employee.Department = department;
                employee.Email = email;
                employee.Age = age;

            }
            else if (input.Length == 5)
            {

                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];
                string email = input[4];

                employee.Name = name;
                employee.Salary = salary;
                employee.Position = position;
                employee.Department = department;
                employee.Email = email;
                employee.Age = -1;

            }
            else if (input.Length == 4)
            {
                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];
                

                employee.Name = name;
                employee.Salary = salary;
                employee.Position = position;
                employee.Department = department;
                employee.Email = "n/a";
                employee.Age = -1;
            }
            
            employees.Add(employee);

            List<decimal> SalariesList = new List<decimal>();

            /*Ako veche imame takuv departament*/
            if (departmentsAndSalariesList.ContainsKey(employee.Department))
            {
                foreach (var v in departmentsAndSalariesList
                    .Where(kvp => kvp.Key == employee.Department))
                {
                    
                    foreach (var vItem in v.Value)
                    {
                        SalariesList.Add(vItem);
                    }
                    //Dobavqme vsichki do sega zaplati 
                    
                }
                
            }

            //dobavqme i segashnata zaplata
                SalariesList.Add(employee.Salary);

                
            departmentsAndSalariesList[employee.Department] = SalariesList;
            

        }
        Dictionary<string, decimal> departmentAverageSalary = new Dictionary<string, decimal>();


        foreach (var dept in departmentsAndSalariesList)
        {
            departmentAverageSalary[dept.Key] = dept.Value.Average();
        }




        //get department with highest
        string highestDepartment = departmentAverageSalary.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

        Console.WriteLine($"Highest Average Salary: {highestDepartment}");
        foreach (var emp in employees
            .Where(e => e.Department == highestDepartment)
            .OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{emp.Name} {emp.Salary:f2} {emp.Email} {emp.Age}");

        }

    }
}

