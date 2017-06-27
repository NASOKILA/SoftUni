using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.OrderByAge
{
    class Student
    {
        public string Name { set; get; }
        public int Age { set; get; }
        public string Id{ get; set; }
    }

    class OrderByAge
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine()
                .Split(' ')
                .ToArray();

            List<Student> students = new List<Student>();
            while (command[0] != "End")
            {

                string name = command[0];
                string id = command[1];
                int age = int.Parse(command[2]);

                Student currentStud = new Student()
                {
                    Name = name,
                    Id = id,
                    Age = age
                };

                students.Add(currentStud);

                command = Console.ReadLine()
                .Split(' ')
                .ToArray();
            }

            students = students.OrderBy(a => a.Age).ToList();

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name} with ID: {student.Id} is {student.Age} years old.");
            }
        }
    }
}
