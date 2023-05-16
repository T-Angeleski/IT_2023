using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorsHospitals.Models {
    public class Hospital {
        [Key]
        public int HospitalID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImageURL { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}