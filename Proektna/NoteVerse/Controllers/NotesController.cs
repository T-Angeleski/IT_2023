using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
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

        public ActionResult AddNoteToGroup(int id) {
            var groupedNote = db.GroupedNotes.Find(id);

            if (groupedNote == null) {
                return HttpNotFound();
            }

            var notes = db.Notes.ToList();
            var notesSelectList = new SelectList(notes, "Id", "Title");

            var model = new AddNoteToGroupViewModel {
                groupedNoteId = id,
                Notes = notesSelectList
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddNoteToGroup(AddNoteToGroupViewModel model) {
            var groupNote = db.GroupedNotes.SingleOrDefault(n => n.Id == model.groupedNoteId);
            var note = db.Notes.SingleOrDefault(n => n.Id == model.noteId);

            if(note != null) {
                groupNote.Notes.Add(note);
                note.GroupId = groupNote.Id;
                note.ParentGroup = groupNote;
                db.SaveChanges();
                return RedirectToAction("GroupedNotes", db.GroupedNotes.ToList());
            }

            return View(model);
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

        [Authorize]
        public ActionResult Create() {
            return View();
        }


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

        [Authorize]
        public ActionResult CreateGroupedNote() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGroupedNote(GroupedNotes note) {
            if (ModelState.IsValid) {
                note.UserId = User.Identity.GetUserId();
                db.GroupedNotes.Add(note);
                db.SaveChanges();
                return RedirectToAction("GroupedNotes");
            }
            return View(note);
        }

        [Authorize]
        public ActionResult GroupedNotes() {
            var notes = new List<GroupedNotes>();

            if (User.IsInRole("Administrator")) {
                notes = db.GroupedNotes
                    .ToList();
            } else {
                var loggedInUser = User.Identity.GetUserId();
                notes = db.GroupedNotes
                    .Where(u => u.UserId.Equals(loggedInUser))
                    .ToList();
            }

            return View(notes);
        }

        [Authorize]
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

        [Authorize]
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Note note = db.Notes.Find(id);
            db.Notes.Remove(note);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditGroupedNote(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupedNotes note = db.GroupedNotes.Find(id);
            if (note == null) {
                return HttpNotFound();
            }
            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGroupedNote(GroupedNotes note) {
            if (ModelState.IsValid) {
                db.Entry(note).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GroupedNotes");
            }
            return View(note);
        }

        public ActionResult DeleteGroupedNote(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupedNotes note = db.GroupedNotes.Find(id);
            if (note == null) {
                return HttpNotFound();
            }
            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGroupedNote(int id) {
            GroupedNotes note = db.GroupedNotes.Find(id);
            db.GroupedNotes.Remove(note);
            db.SaveChanges();
            return RedirectToAction("GroupedNotes");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
