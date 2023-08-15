using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoteVerse.Models {
    public class Note {
        [Key]
        public int Id { get; set; }
        public string userId { get; set; }
        [Required(ErrorMessage = "Please enter a title!")]
        public string title { get; set; }
        [Required(ErrorMessage = "Note content is required")]
        public string content { get; set; }
        public bool isHighPrio;
        public bool isLowPrio;

        public DateTime createdAt { get; set; } = DateTime.Now;



    }


}