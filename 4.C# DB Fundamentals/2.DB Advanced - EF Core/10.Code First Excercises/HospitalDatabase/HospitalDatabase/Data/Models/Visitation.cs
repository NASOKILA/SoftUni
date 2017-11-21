using System;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {
        public Visitation()
        {

        }

        [Key]
        public int VisitationID { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
        
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }

}
