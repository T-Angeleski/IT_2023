using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NoteVerse.Models;

namespace NoteVerse.Controllers {
    public class NotesController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Notes
        [Authorize]
        public ActionResult Index() {
            var notes = new List<Note>();

            if (User.IsInRole("Administrator")) {
                notes = db.Notes.ToList();
            } else {
                var loggedInUser = User.Identity.GetUserId();
                notes = db.Notes
                    .Where(u => u.UserId.Equals(loggedInUser))
                    .ToList();
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
