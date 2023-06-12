using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Students.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string StudentName { get; set; }
        [StringLength(6, MinimumLength = 6)]
        public string Index { get; set; }
        public string EmailAddress { get; set; }
        public string ProfileImage { get; set; }
    }
}