using EventLab.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventLab.Controllers {
    public class EventController : Controller {
        private static List<EventModel> events = new List<EventModel>() {
            new EventModel() {ID = 0, Name = "Concert", Location = "Skopje"},
            new EventModel() {ID = 1, Name = "Opera", Location = "Prilep"},
            new EventModel() {ID = 2, Name = "Marathon", Location = "Veles"}
        };
        // GET: Event
        public ActionResult Index() {
            return View();
        }

        public ActionResult ShowAllEvents() {
            List<EventModel> model = events;
            return View(events);
        }

        public ActionResult DetailsEvent(int id) {
            EventModel model = events[id];
            return View(model);
        }

        public ActionResult CreateEvent() {
            EventModel model = new EventModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEvent(EventModel model) {
            if (!ModelState.IsValid) {
                return View("CreateEvent", model);
            }
            model.ID = events.Count;
            events.Add(model);
            return View("ShowAllEvents", events);
        }

        public ActionResult EditEvent(int id) {
            EventModel model = events.FirstOrDefault(e => e.ID == id);
            model.ID = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult EditEvent(EventModel model) {
            if (!ModelState.IsValid) {
                return RedirectToAction("ShowAllEvents");
            }
            EventModel toUpdate = events.ElementAt(model.ID);
            toUpdate.Name = model.Name;
            toUpdate.Location = model.Location;
            return View("ShowAllEvents", events);
        }

        public ActionResult DeleteEvent(int id) {
            events.Remove(events[id]);
            return View("ShowAllEvents", events);
        }
    }
}