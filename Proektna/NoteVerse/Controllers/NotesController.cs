using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using NoteVerse.Models;

namespace NoteVerse.Controllers {
    public class NotesController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Notes
        [Authorize]
        public ActionResult Index() {

            List<Note> notes = new List<Note>();
            List<TodoNote> todos = new List<TodoNote>();

            if (User.IsInRole("Administrator")) {
                notes = db.Notes.ToList();
                todos = db.ToDos.ToList();
            } else {
                var loggedInUser = User.Identity.GetUserId();
                notes = db.Notes.Where(n => n.userId == loggedInUser).ToList();
                todos = db.ToDos.Where(n => n.userId == loggedInUser).ToList();
            }

            var model = new BothNotesModel() {
                Notes = notes, TodoNotes = todos
            };
            return View(model);

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
        public ActionResult Create([Bind(Include = "Id,userId,title,content,createdAt")] Note note) {
            if (ModelState.IsValid) {
                var userId = User.Identity.GetUserId();
                note.userId = userId;
               

                db.Notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(note);
        }

        public ActionResult CreateTodo() {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTodo(TodoNote note) {
            note.userId= User.Identity.GetUserId();
            note.taskComplete = new List<bool>();
            note.tasks.ForEach(t => note.taskComplete.Add(false));

            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < note.tasks.Count - 1; i++) {
                sb.Append(note.tasks[i]).Append(",");
            }
            sb.Append(note.tasks[note.tasks.Count - 1]);
            note.allTasksCS = sb.ToString();
            db.ToDos.Add(note);
            db.SaveChanges();
            return RedirectToAction("Index");

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
        public ActionResult Edit([Bind(Include = "Id,userId,title,content,createdAt")] Note note) {
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
