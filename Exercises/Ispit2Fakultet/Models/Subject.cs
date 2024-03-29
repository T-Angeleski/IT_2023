﻿using Ispit2Fakultet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Students.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string TeacherName { get; set; }

        public List<StudentSubjectGrade> grades { get; set; } = new List<StudentSubjectGrade>();
    }
}