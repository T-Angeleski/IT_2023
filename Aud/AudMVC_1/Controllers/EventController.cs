using AudMVC_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AudMVC_1.Controllers {
    public class EventController : Controller {

        private static Event ev1 = new Event() { ID = 1, Name = "Music?", Location = "Skopje" };
        private static Event ev2 = new Event() { ID = 2, Name = "Concert", Location = "Veles" };
        private static Event ev3 = new Event() { ID = 3, Name = "Marathon", Location = "Ohrid" };

        private static List<Event> events = new List<Event> { ev1, ev2, ev3 };
        // GET: Event
        public ActionResult Index() {
            return View();
        }

        public ActionResult ShowEvents() {
            EventModel model = new EventModel();
            model.Events = events;
            return View(model);
        }
    }
}