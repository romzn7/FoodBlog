﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using blog.Models;

namespace blog.Controllers
{
    public class RestuarantsController : Controller
    {
        private OdeToFoodDb db = new OdeToFoodDb();

        // GET: Restuarants
        public ActionResult Index()
        {
            return View(db.Restuarants.ToList());
        }

        // GET: Restuarants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restuarant restuarant = db.Restuarants.Find(id);
            if (restuarant == null)
            {
                return HttpNotFound();
            }
            return View(restuarant);
        }

        // GET: Restuarants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restuarants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,City,Country")] Restuarant restuarant)
        {
            if (ModelState.IsValid)
            {
                db.Restuarants.Add(restuarant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restuarant);
        }

        // GET: Restuarants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restuarant restuarant = db.Restuarants.Find(id);
            if (restuarant == null)
            {
                return HttpNotFound();
            }
            return View(restuarant);
        }

        // POST: Restuarants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,City,Country")] Restuarant restuarant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restuarant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restuarant);
        }

        // GET: Restuarants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restuarant restuarant = db.Restuarants.Find(id);
            if (restuarant == null)
            {
                return HttpNotFound();
            }
            return View(restuarant);
        }

        // POST: Restuarants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restuarant restuarant = db.Restuarants.Find(id);
            db.Restuarants.Remove(restuarant);
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
