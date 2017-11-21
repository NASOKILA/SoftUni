

namespace P01_HospitalDatabase.Data.Models
    {

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Doctor
        {
            public Doctor()
            {
                Visitations = new List<Visitation>();
            }

            [Key]
            public int DoctorID { get; set; }

            public string Name { get; set; }

            public string Speciality { get; set; }

            public ICollection<Visitation> Visitations { get; set; }

        }
    }


