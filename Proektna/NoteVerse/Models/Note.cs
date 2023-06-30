using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoteVerse.Models {
    public class Note {
        public int Id { get; set; }
        public string userId { get; set; }
        [Required(ErrorMessage = "Please enter a title!")]
        public string title { get; set; }
        [Required(ErrorMessage = "Note content is required")]
        public string content { get; set; }
        public List<string> tags { get; set; } = new List<string>();

        public DateTime createdAt { get; set; } = DateTime.Now;


    }
}