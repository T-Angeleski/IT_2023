using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteVerse.Models {
    public class AddUserToRoleModel {
        public string Email { get; set; }
        public string SelectedRole { get; set; }
        public List<string> Emails { get; set; } = new List<string>();
        public IEnumerable<string> Roles { get; set; } = new List<string>() {
            "Administrator", "User"
        };
    }
}