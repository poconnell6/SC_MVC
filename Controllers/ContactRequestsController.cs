﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SC_MVC.Models;

namespace SC_MVC.Controllers
{
    public class ContactRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactRequests
        public ActionResult Index()
        {
            return View(db.ContactRequests.ToList());
        }

        // GET: ContactRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactRequest contactRequest = db.ContactRequests.Find(id);
            if (contactRequest == null)
            {
                return HttpNotFound();
            }
            return View(contactRequest);
        }

        // GET: ContactRequests/Contact
        public ActionResult Contact()
        {
            return View();
        }

        // POST: ContactRequests/Contact
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "intPrimaryKey,txtName,dteDate,txtEmail,txtEmailConfirm,txtSubject,txtMessage")] ContactRequest contactRequest)
        {
            if (ModelState.IsValid)
            {
                db.ContactRequests.Add(contactRequest);
                db.SaveChanges();
                return RedirectToAction("Thanks");
            }

            return View(contactRequest);
        }

        // GET: ContactRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactRequest contactRequest = db.ContactRequests.Find(id);
            if (contactRequest == null)
            {
                return HttpNotFound();
            }
            return View(contactRequest);
        }

        // POST: ContactRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "intPrimaryKey,txtName,dteDate,txtEmail,txtEmailConfirm,txtSubject,txtMessage")] ContactRequest contactRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactRequest);
        }

        // GET: ContactRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactRequest contactRequest = db.ContactRequests.Find(id);
            if (contactRequest == null)
            {
                return HttpNotFound();
            }
            return View(contactRequest);
        }

        // POST: ContactRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactRequest contactRequest = db.ContactRequests.Find(id);
            db.ContactRequests.Remove(contactRequest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ContactRequests/Thanks
        public ActionResult Thanks()
        {
            return View();
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
