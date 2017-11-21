namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    // [Table("Resourse")]      // [Table("Resourse" , Schema = "dbo.ImeNasShema")]         
    public class Resource
    {
        public Resource()
        {

        }

        //[Key]
        public int ResourseId { get; set; }

        [MinLength(5)]
        [MaxLength(20)]
        [Required]
        [Column("Name", Order = 2, TypeName = "NVARCHAR(50)")]
        public string Name { get; set; }

        [Range(5, 10)]
        public string Url { get; set; }
        
        public ResourceType ResourceType { get; set; }

        //[ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
