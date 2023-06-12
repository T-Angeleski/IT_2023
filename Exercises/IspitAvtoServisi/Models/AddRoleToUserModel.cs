using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IspitAvtoServisi.Models {
    public class AddRoleToUserModel {
        public string email { get; set; }
        public string selectedRole { get; set; }
        public List<string> roles = new List<string>() {
            "Administrator", "User"
        };
    }
}