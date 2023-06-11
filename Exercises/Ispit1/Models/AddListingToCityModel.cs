using Listings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ispit1.Models {
    public class AddListingToCityModel {
        public int CityId { get; set; }
        public int listingId { get; set; }
        public List<Listing> listings { get; set; } = new List<Listing>(); 
    }
}