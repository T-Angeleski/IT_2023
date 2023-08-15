using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoteVerse.Models {
    public class TodoNote {
        [Key]
        public int Id { get; set; }
        public string userId { get; set; }
        public string title { get; set; }
        public List<string> tasks { get; set; } = new List<string>();
        public string allTasksCS { get; set; }
        public List<bool> taskComplete { get; set; } = new List<bool> { false };
    }
}