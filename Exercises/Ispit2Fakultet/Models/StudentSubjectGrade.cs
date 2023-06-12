using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ispit2Fakultet.Models {
    public class StudentSubjectGrade {
        [Key]
        public int studentID { get; set; }
        public string Name { get; set; }
        public int subjectID { get; set; }
        [Range(5,10)]
        public int Grade { get; set; }
    }
}