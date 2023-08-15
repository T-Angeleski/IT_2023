using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteVerse.Models {
    public class BothNotesModel {
        public List<Note> Notes { get; set; } = new List<Note>();
        public List<TodoNote> TodoNotes { get; set; } = new List<TodoNote> {};
    }
}