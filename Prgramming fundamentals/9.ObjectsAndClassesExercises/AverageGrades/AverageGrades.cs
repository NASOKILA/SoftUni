using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageGrades
{
    class AverageGrades
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, double> QualifiedStudents = new SortedDictionary<string, double>();
            Student students = new Student();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ').ToArray();

                List<double> GradesList = new List<double>();

                students.Name = input[0];
             //   if (QualifiedStudents.Contains(students.Name)) { QualifiedStudents.Add(students.Name, ); }

                for (int j = 1; j < input.Length; j++)
                {
                    double gradeToDouble = double.Parse(input[j]);
                    if(gradeToDouble > 6)
                        gradeToDouble  = gradeToDouble / 100;

                    GradesList.Add(gradeToDouble);
                }
                students.Grades = GradesList;

                double average = students.AverageGrade();

                if(average >= 5)
                {
                    

                    QualifiedStudents[students.Name] = average;
                }


            }

            foreach (var qualifiedStudent in QualifiedStudents)
            {
                Console.WriteLine("{0} -> {1:f2}", qualifiedStudent.Key, qualifiedStudent.Value);
            }

        }
    }
}
