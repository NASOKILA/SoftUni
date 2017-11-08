using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MainProgram
{
    static void Main(string[] args)
    {

        //Human numan = new Human("Asen Kambitov", 22);
        // Worker worker = new Worker("Atanas Kambitov",30,  200, 8);



        List<string> studentInfo = Console.ReadLine()
           .Split(' ')
           .ToList();

        string studentFirstName = studentInfo[0];
        string studentLastName = studentInfo[1];
        string facultyNumber = studentInfo[2];


        List<string> workerInfo = Console.ReadLine()
               .Split()
               .ToList();

        string workerFirstName = workerInfo[0];
        string workerLastName = workerInfo[1];
        decimal workerSalary = decimal.Parse(workerInfo[2]);
        decimal workerWorkingHours = decimal.Parse(workerInfo[3]);
        
        try
        {
            
            Student student = new Student(studentFirstName, studentLastName, facultyNumber);
            Worker worker = new Worker(workerFirstName, workerLastName, workerSalary, workerWorkingHours);
            
            Console.WriteLine(student + Environment.NewLine);
            Console.WriteLine(worker);
            
        }
        catch (ArgumentException e)
        {
            Console.WriteLine( e.Message );
        }




    }
}

    