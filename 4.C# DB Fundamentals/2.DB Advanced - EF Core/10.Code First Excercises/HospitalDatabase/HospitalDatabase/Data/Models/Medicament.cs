using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {
        public Medicament()
        {
            //INICIALIZIRAME SI VSICHKI KOLEKCII
            Prescriptions = new List<PatientMedicament>();
        }

        [Key]
        public int MedicamentID { get; set; }
        
        public string Name { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; internal set; }
    }
}
