using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.AverageGrades
{

    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double AverageGrade
        {
            get
            {
                return Grades.Sum() / Grades.Count;
            }            
        }

        class AverageGrades
        {
            static void Main(string[] args)
            {

                int n = int.Parse(Console.ReadLine());

                List<Student> students = new List<Student>();

                for (int i = 0; i < n; i++)
                {
                    string[] input = Console.ReadLine()
                        .Split(' ')
                        .ToArray();

                    string name = input.First();

                    List<double> grades = input
                        .Skip(1)
                        .Select(double.Parse)
                        .ToList();

                    Student student = new Student()
                    {
                        Name = name,
                        Grades = grades
                    };

                        students.Add(student);
                }

                PrintStudents(students);
            }

            private static void PrintStudents(List<Student> students)
            {
                foreach (var item in students.Where(a => a.AverageGrade >= 5.00)
                    .OrderBy(b => b.Name).ThenByDescending(a => a.AverageGrade))
                {
                    Console.WriteLine($"{item.Name} -> {item.AverageGrade:F2}");
                }
            }

        }
    }
}