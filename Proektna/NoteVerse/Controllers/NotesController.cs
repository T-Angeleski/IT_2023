using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NoteVerse.Models;

namespace NoteVerse.Controllers {
    public class NotesController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public JsonResult MarkAsComplete(int id) {
            var note = db.Notes.Find(id);

            if (note == null) {
                return Json(new { success = false, message = "Note not found." });
            }

            note.IsCompleted = true;
            db.SaveChanges();
            return Json(new { success = true, message = "Note marked as complete." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Autocomplete(string term) {


            if (User.IsInRole("Administrator")) {
                var notes = db.Notes
                    .Where(n => n.Title.StartsWith(term))
                    .Take(10)
                    .Select(n => new {
                        label = n.Title
                    });
                return Json(notes, JsonRequestBehavior.AllowGet);

            } else {
                var loggedInUser = User.Identity.GetUserId();
                var notes = db.Notes
                    .Where(u => u.UserId.Equals(loggedInUser))
                    .Where(n => n.Title.StartsWith(term))
                    .Take(10)
                    .Select(n => new {
                        label = n.Title
                    });
                return Json(notes, JsonRequestBehavior.AllowGet);

            }

        }

        // GET: Notes
        [Authorize]
        public ActionResult Index(string searchTerm = null) {
            var notes = new List<Note>();

            if (User.IsInRole("Administrator")) {
                notes = db.Notes
                    .Where(n => searchTerm == null || n.Title.StartsWith(searchTerm))
                    .ToList();
            } else {
                var loggedInUser = User.Identity.GetUserId();
                notes = db.Notes
                    .Where(u => u.UserId.Equals(loggedInUser))
                    .Where(n => searchTerm == null || n.Title.StartsWith(searchTerm))
                    .ToList();
            }

            if (Request.IsAjaxRequest()) {
                return PartialView("_Notes", notes);
            }

            return View(notes);
        }

        // GET: Notes/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null) {
                return HttpNotFound();
            }
            return View(note);
        }

        // GET: Notes/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,IsCompleted,CreatedAt,Deadline,GroupId,UserId")] Note note) {
            if (ModelState.IsValid) {
                var userId = User.Identity.GetUserId();
                note.UserId = userId;
                note.ParentGroup = null;
                note.GroupId = null;

                db.Notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(note);
        }

        // GET: Notes/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null) {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,IsCompleted,CreatedAt,Deadline,GroupId,UserId")] Note note) {
            if (ModelState.IsValid) {
                db.Entry(note).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        // GET: Notes/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null) {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Note note = db.Notes.Find(id);
            db.Notes.Remove(note);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
