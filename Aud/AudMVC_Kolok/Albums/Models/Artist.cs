﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Albums.Models {
    public class Artist {
        public int ArtistId { get; set; }
        [Display(Name = "Artist Name")]
        [Required]
        public string Name { get; set; }
    }
}