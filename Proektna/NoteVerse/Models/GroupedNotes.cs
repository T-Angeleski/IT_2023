using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoteVerse.Models {
    public class GroupedNotes {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage ="Please enter a title for this group")]
        public string Title { get; set; }
        public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}