using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.MentorGroup
{
    class Student
    {
        public string Name { get; set; }
        public List<DateTime> Dates { get; set; }
        public List<string> Comments { get; set; }
    }

    class MentorGroup
    {
        static void Main(string[] args)
        {
            string[] nameAndDates = Console.ReadLine().Split(' ').ToArray();
            string[] nameAndComments = Console.ReadLine().Split('-').ToArray();

            List<DateTime> dates = new List<DateTime>();
            List<Student> students = new List<Student>();

            SetStudents(nameAndDates, dates, students);
            GetComments(nameAndComments, nameAndDates, students);
            
            PrintResult(students);
        }

        private static void SetStudents(string[] nameAndDates, List<DateTime> dates, List<Student> students)
        {
            while (nameAndDates[0] != "end")
            {

                string name = nameAndDates[0];
                if (nameAndDates.Length > 0)
                    dates = nameAndDates[1].Split(',').Select(DateTime.Parse).ToList();

                Student student = new Student
                {
                    Name = name,
                    Dates = dates
                };

                bool hasTheSameName = CheckIfHasTheSameName(students, name, dates);
                
                if (!hasTheSameName)
                    students.Add(student);

                nameAndDates = Console.ReadLine().Split(' ').ToArray();
            }

        }

        private static bool CheckIfHasTheSameName(List<Student> students, string name, List<DateTime> dates)
        {
            bool hasTheSameName = false;
            foreach (var stu in students)
            {
                if (stu.Name == name)
                {
                    dates.AddRange(stu.Dates);
                    stu.Dates = dates;
                    hasTheSameName = true;
                }
            }
            return hasTheSameName;
        }

        private static void GetComments(string[] nameAndComments, string[] nameAndDates, List<Student> students)
        {
            List<string> comments = new List<string>();
            while (nameAndComments[0] != "end")
            {
                string name = nameAndComments[0];
                string comment = nameAndComments[1];

                Student currStud = students.Where(s => s.Name == name).FirstOrDefault();

                if (currStud != null)
                {
                    currStud.Comments = comments;
                    comments.Add(comment);
                }

                nameAndComments = Console.ReadLine().Split(' ').ToArray();
            }
        }

        private static void PrintResult(List<Student> students)
        {
            foreach (var stud in students.OrderBy(s => s.Name))
            {
                string name = stud.Name;
                Console.WriteLine(name);
                Console.WriteLine("Comments:");

                if (stud.Comments != null)
                {
                    foreach (var comm in stud.Comments)
                    {
                        Console.WriteLine($"- {comm}");
                    }
                }

                Console.WriteLine("Dates attended:");

                if (stud.Dates != null)
                {
                    foreach (var date in stud.Dates.OrderBy(d => d))
                    {
                        Console.WriteLine($"-- {date.Day:D2}/{date.Month:D2}/{date.Year}");
                    }
                }
            }

        }
    }
}
