using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteVerse.Models {
    public class AddUserToRoleModel {
        public string email {  get; set; }
        public string selectedRole { get; set; }
        public List<string> roles { get; set; } = new List<string>() {
            "Administrator", "User"
        };
    }
}