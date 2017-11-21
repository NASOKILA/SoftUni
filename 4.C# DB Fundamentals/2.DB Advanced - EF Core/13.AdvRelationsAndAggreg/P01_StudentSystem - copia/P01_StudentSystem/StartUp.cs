namespace P01_StudentSystem
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Extensions.Internal;
    using P01_StudentSystem.Data;
    using P01_StudentSystem.Data.Models;
    using P01_StudentSystem.Data.ViewModels;
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {

            using (var db = new StudentSystemContext())
            {
                
                ResetDatabase(db);

                //BONUS: Console Application

                var courses = db.Courses
                    .Include(c => c.StudentCourses)
                    .ThenInclude(sc => sc.Student)
                    .ToList();
                   

                foreach (var course in courses)
                {
                    Console.WriteLine($"-Name: {course.Name} / Desctiption: {course.Description} / Price: {course.Price} / StudentsCount:{course.StudentCourses.Count}");

                    foreach (var stuCourse in course.StudentCourses)
                    {
                        Console.WriteLine($"---Student Name: {stuCourse.Student.Name} / Student Phone Number: {stuCourse.Student.PhoneNumber}");
                    }

                }

                Console.WriteLine();
                Console.WriteLine();

                var students = db.Students
                    .Include(s => s.HomeworkSubmissions)
                    .ThenInclude(h => h.Course)
                    .ToList();

                foreach (var stu in students)
                {
                    Console.WriteLine($"-Name: {stu.Name} / Courses Count:{stu.HomeworkSubmissions.Count}");

                    foreach (var homework in stu.HomeworkSubmissions)
                    {
                        Console.WriteLine($"---Homework Name: {homework.Content} / Homework Submission Date: {homework.SubmissionTime}");
                    }

                }


                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();


                //Moi Tetvaniq

                //Joinvane .Include(), s Anonimni obekti, s.Join():

                //.Include()
                var studentsWithHomeworks = db.Students.Include(s => s.HomeworkSubmissions);

                var homeworksWithCourses = db.Homework
                    .Select(h => new {
                        h.Content,
                        h.SubmissionTime,
                        CourseName = h.Course.Name //Vzimame si samo imeto na kursa ZASHTOTO IMA EDNO KUM MNOGO VRUZKA
                    })
                    .ToList();

                foreach (var homework in homeworksWithCourses)
                {
                    Console.WriteLine($"{homework.Content} / {homework.SubmissionTime} / {homework.CourseName}");
                }


                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();

                //S Join(); Purvi parameur e tablicata koqto iskame da joinnvame
                //Vtori i treti parametur sa kluchovete ot dvete tablici
                //i posleden parametur priema anonimen obekt v koito selektirame kakvoto si poiskame.
                var coursesWithResourses = db.Courses
                    .Join(db.Resources,
                    (c => c.CourseId),
                    (r => r.CourseId),
                    (c, r) => new {
                        CourseName = c.Name,
                        CoursePrice = c.Price,
                        RsourseName = r.Name,
                        ResourceType = r.ResourceType
                    })
                    .ToList();
                
                foreach (var course in coursesWithResourses)
                {
                    Console.WriteLine($"{course.CourseName} / {course.CoursePrice} / {course.RsourseName} / {course.ResourceType}");
                }



                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();

                //Aggregirashti funkcii Count(), Min(), Max()  :
                var coursesWithResoursesCount =
                    db.Courses.Select(c => new {
                        c.Name,
                        c.Price,
                        /*  ResoursesCount = c.Resources.Sum( e => e.CourseId)
                          ResoursesMax = c.Resources.Max(),
                          ResoursesMin = c.Resources.Min() */
                    })
                    .ToList();
                

                //NESHTO NE STAVA
                foreach (var c in courses)
                {
                }



                //GRUPIRA SE S GroupBy();



                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();

                /*
                    View Model:
                        V nego kazvame kakvo iskame da selektirame,
                        Kakto v SQL SERVER. 
                        I mojem da go polzvame vuv Select.
                 */

                //Polzvame go kato go izvikvame v .Select() i mu podavame parametrite koito iskame !!!
                var courseNameAndPrice = db.Courses
                        .Select(c => new CourseViewModel(c.Name, c.Price))
                        .ToList();

                foreach (var course in courseNameAndPrice)
                {
                    Console.WriteLine($"{course.Course_Name} / {course.Course_Price}");
                }

                //Po formalno e i po dobre izglejda ot kolkoto Anonimnite obekti !
                //MOJEM PROSTO DA POLZVAME FUNKCIQ KOQTO DA PRAVI SUSHTOTO VMESTO KLAS !


                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
                
                //Polzvame ViewModel za Students
                var studentNamePhoneAndRegistration = db.Students
                    .Select(s => new StudentViewModel(s.Name, s.PhoneNumber, s.RegisteredOn))
                    .ToList();

                foreach (var studentViewModel in studentNamePhoneAndRegistration)
                {
                    Console.WriteLine(studentViewModel); 
                    //DIREKTNO SI GO PRINTIRAME ZASHTOTO IMAME override NA ToString() mewtoda !!!
                }

                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();


            }

        }
        
        private static void ResetDatabase(StudentSystemContext db)
        {
            //Resetvame si bzata
            db.Database.EnsureDeleted();

            db.Database.EnsureCreated();

            //Vkarvame si danni
            Seed(db);
            
        }

        private static void Seed(StudentSystemContext db)
        {

            var Students = new[]
            {
                  new Student()
                  {
                      Name = "Atanas Kambitov",
                      RegisteredOn = Convert.ToDateTime("01-02-2000"),
                      PhoneNumber = "1234567890"
                  },

                  new Student()
                  {
                      Name = "Asen Kambitov",
                      RegisteredOn = Convert.ToDateTime("07-01-2010"),
                      PhoneNumber = "1131562890"
                  },
                  new Student()
                  {
                      Name = "Stefan Kambitov",
                      RegisteredOn = Convert.ToDateTime("05-05-2008"),
                      BirthDay = Convert.ToDateTime("05-02-1974"),
                      PhoneNumber = "1232543210"
                  },

                  new Student()
                  {
                      Name = "Anton Stoqnov",
                      RegisteredOn = Convert.ToDateTime("03-09-2009"),
                      BirthDay = Convert.ToDateTime("11-11-1974"),
                      PhoneNumber = "1131212840"
                  }

              };
            db.Students.AddRange(Students);

            var Courses = new[]
            {
                new Course()
                {
                    Name = "Programming Basics",
                    Description = "Easy course for beginners !",
                    StartDate = Convert.ToDateTime("25-05-2016"),
                    EndDate = Convert.ToDateTime("29-06-2016"),
                    Price = 330
                },

                new Course()
                {
                    Name = "Programming Fundamentals",
                    StartDate = Convert.ToDateTime("25-07-2016"),
                    EndDate = Convert.ToDateTime("29-08-2016"),
                    Price = 390
                },

                new Course()
                {
                    Name = "Software Technologies",
                    Description = "Learn deferent working technologies !",
                    StartDate = Convert.ToDateTime("05-09-2016"),
                    EndDate = Convert.ToDateTime("09-08-2016"),
                    Price = 350
                },

                new Course()
                {
                    Name = "Databases Basics",
                    Description = "Basic learning of databases !",
                    StartDate = Convert.ToDateTime("25-05-2016"),
                    EndDate = Convert.ToDateTime("29-06-2016"),
                    Price = 290
                },

            };
            db.Courses.AddRange(Courses);

            var StudentCourses = new[]
            {
            new StudentCourse() {Student = Students[1], Course = Courses[1] },
            new StudentCourse() {Student = Students[2], Course = Courses[1] },
            new StudentCourse() {Student = Students[0], Course = Courses[0] },
            new StudentCourse() {Student = Students[0], Course = Courses[2] }
        };
            db.StudentsCourses.AddRange(StudentCourses);

            var Resourses = new[]
            {
                new Resource()
                {
                    Name = "ResourseOne",
                    Url = "https://www.softuni.bg",
                    ResourceType = ResourceType.Document,
                    CourseId = Courses[2].CourseId
                },

                new Resource()
                {
                    Name = "ResourseTwo",
                    Url = "https://www.youtube.bg",
                    ResourceType = ResourceType.Video,
                    CourseId = Courses[0].CourseId
                },

                new Resource()
                {
                    Name = "ResourseThree",
                    Url = "https://www.facebook.bg",
                    ResourceType = ResourceType.Other,
                    CourseId = Courses[2].CourseId
                },

            };
            db.Resources.AddRange(Resourses);
            
            var HomeworksSubmissions = new[]
            {
                new Homework()
                {
                    Content = "contentOne",
                    ContentType = ContentType.Application,
                    SubmissionTime = Convert.ToDateTime("04-06-2015"),
                    StudentId = Students[0].StudentId,
                    CourseId = Courses[1].CourseId
                },

                new Homework()
                {
                    Content = "contentTwo",
                    ContentType = ContentType.Zip,
                    SubmissionTime = Convert.ToDateTime("01-08-2011"),
                    StudentId = Students[1].StudentId,
                    CourseId = Courses[2].CourseId
                },

                new Homework()
                {
                    Content = "contentOne",
                    ContentType = ContentType.Pdf,
                    SubmissionTime = Convert.ToDateTime("08-06-2017"),
                    StudentId = Students[2].StudentId,
                    CourseId = Courses[0].CourseId
                }
            };
            db.Homework.AddRange(HomeworksSubmissions);



            db.SaveChanges();
          
        }
        
    }
}











