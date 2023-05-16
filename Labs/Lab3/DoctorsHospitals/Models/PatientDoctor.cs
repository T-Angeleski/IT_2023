using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorsHospitals.Models {
    public class PatientDoctor {
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
    }
}