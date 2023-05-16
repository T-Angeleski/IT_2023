using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorsHospitals.Models {
    public class Patient {
        [Key]
        public int PatientID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        [Required]
        [MinLength(5), MaxLength(5)]
        [Display(Name = "Patient code")]
        public string Code { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}