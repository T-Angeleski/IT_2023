using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteVerse.Models {
    public class AddNoteToGroupViewModel {
        public int groupedNoteId { get; set; }

        public int noteId { get; set; }

        public SelectList Notes { get; set; }
    }
}