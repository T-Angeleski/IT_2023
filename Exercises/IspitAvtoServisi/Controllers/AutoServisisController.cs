using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoService.Models;
using IspitAvtoServisi.Models;

namespace IspitAvtoServisi.Controllers
{
    public class AutoServisisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AutoServisis
        public ActionResult Index()
        {
            return View(db.autoServices.ToList());
        }

        // GET: AutoServisis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoServisi autoServisi = db.autoServices.Find(id);
            if (autoServisi == null)
            {
                return HttpNotFound();
            }
            return View(autoServisi);
        }


        public ActionResult AddCarToService(int id) {
            var model = new AddCarToServiceModel();
            model.cars = db.cars.ToList();
            model.autoServices = db.autoServices.ToList();
            model.serviceId = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddCarToService(AddCarToServiceModel model) {
            var service = db.autoServices.Find(model.serviceId);
            var car = db.cars.Find(model.carId);
            service.cars.Add(car);
            db.SaveChanges();
            return View("Index", db.autoServices.ToList());
        }

        // GET: AutoServisis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutoServisis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Capacity")] AutoServisi autoServisi)
        {
            if (ModelState.IsValid)
            {
                db.autoServices.Add(autoServisi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autoServisi);
        }

        // GET: AutoServisis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoServisi autoServisi = db.autoServices.Find(id);
            if (autoServisi == null)
            {
                return HttpNotFound();
            }
            return View(autoServisi);
        }

        // POST: AutoServisis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Capacity")] AutoServisi autoServisi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoServisi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autoServisi);
        }

        // GET: AutoServisis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoServisi autoServisi = db.autoServices.Find(id);
            if (autoServisi == null)
            {
                return HttpNotFound();
            }
            return View(autoServisi);
        }

        // POST: AutoServisis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutoServisi autoServisi = db.autoServices.Find(id);
            db.autoServices.Remove(autoServisi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
