using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoService.Models {
    public class AutoServisi {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Име")]
        public string Name { get; set; }
        [Range(1, 30)]
        public int Capacity { get; set; }
        public virtual List<Car> cars { get; set; } = new List<Car>();
        
    }
}