using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorsHospitals.Models {
    public class Doctor {
        [Key]
        public int DoctorID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
        public virtual Hospital Hospital { get; set; }

    }
}