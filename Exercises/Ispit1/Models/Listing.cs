using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Listings.Models
{
    public class Listing
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [StringLength(100, MinimumLength = 12)]
        public string Address { get; set; }
        public float PricePerDay { get; set; }
        public string Image { get; set; }
        public bool IsAvailable { get; set; }
    }
}