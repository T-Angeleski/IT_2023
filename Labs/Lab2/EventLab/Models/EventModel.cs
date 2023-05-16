using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventLab.Models {
    public class EventModel {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
    }
}