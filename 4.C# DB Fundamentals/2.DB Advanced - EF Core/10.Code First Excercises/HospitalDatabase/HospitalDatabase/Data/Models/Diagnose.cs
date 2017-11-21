using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Diagnose
    {
        public Diagnose()
        {

        }

        [Key]
        public int DiagnoseID { get; set; }
        
        public string Comments { get; set; }
        
        public string Name { get; set; }
        
        public int PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
