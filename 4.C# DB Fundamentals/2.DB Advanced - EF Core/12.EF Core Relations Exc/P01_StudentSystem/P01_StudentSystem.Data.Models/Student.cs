namespace P01_StudentSystem.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        public Student()
        {

        }

        public int StudentId { get; set; }

        public string Name { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        //Trqbva da go setnem na NULL zashtoto PO USLOVIE NE e required() !
        public DateTime? BirthDay { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
            = new List<StudentCourse>();

        public ICollection<Homework> HomeworkSubmissions { get; set; }
            = new List<Homework>();

    }
}
