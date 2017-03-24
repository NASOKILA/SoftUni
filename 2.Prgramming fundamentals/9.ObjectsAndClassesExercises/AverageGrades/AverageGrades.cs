using System;
using System.Collections.Generic;
using System.Linq;


namespace AverageGrades
{
    class AverageGrades
    {
       public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            List<Student> Students = new List<Student>();



            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ').ToArray();

                List<double> GradesList = new List<double>();
                string studentName = input[0];        // imeto

                for (int j = 1; j < input.Length; j++)
                {

                    double grades = double.Parse(input[j]);
                    if (grades > 6)
                        grades = grades / 100;

                    GradesList.Add(grades);     // we add grades to gradeList
                }

                Student student = new Student();   // DOBAVQME NAME, GRADES I AVERAGE GRADES TOVA NE E NAI PRAVILNIQ NACHIN !
                student.Name = studentName;
                student.Grades = GradesList;

                Students.Add(student); // dobavqme si studenta v spisuka studenti

            }

            // Students sega sudurja vsichki studenti !!!

                foreach (var student1  in Students
                    .Where(s => s.AverageGrade >= 5)  // vzimame tezi koito imat average > 5
                    .OrderBy(s => s.Name)           // podrejdame po imena
                    .ThenByDescending(s => s.AverageGrade))  // podrejdame po Average grade obache descending (ot gore na dolo)
                {

                Console.WriteLine("{0} -> {1:f2}",student1.Name, student1.AverageGrade);
                }
                
         
        }
    }
}
