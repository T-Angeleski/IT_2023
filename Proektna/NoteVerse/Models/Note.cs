using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoteVerse.Models {
    public class Note {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Notes must have a title")]
        [StringLength(100)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter content for your note")]
        public string Content { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Deadline { get; set; }

        public int? GroupId { get; set; }
        public GroupedNotes ParentGroup { get; set; }

        // User
        public string UserId { get; set; }
    }
}