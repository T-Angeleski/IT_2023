using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ispit1.Models {
    public class AddToRoleModel {
        public string Email { get; set; }
        public List<string> roles = new List<string>() {
            "Administrator",
            "User"
        };
        public string selectedRole { get; set; }
    }
}