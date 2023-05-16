using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudMVC_1.Models {
    public class EventModel {
        public List<Event> Events { get; set; }

        public EventModel() {
            Events = new List<Event>();
        }
    }
}