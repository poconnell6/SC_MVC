using System;
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
    public class WorksController : Controller
    {
        // we get a new controller for every request as per
        // https://stackoverflow.com/questions/5425920/asp-net-mvc-is-controller-created-for-every-request 
        // so we shouldnt have reuse issues here
        
        private ApplicationDbContext db = new ApplicationDbContext();
        
         

        // GET: Works
        public ActionResult Index()
        {

            //pare down the list of books to just sale items
            //I think this method seems like overkill here but is apparently what is necessary to prevent it whining about type errors
            List<WorksIndexViewModel> WIVMlist = new List<WorksIndexViewModel>();
            var salelist = (
                from saleitems in db.Works
                where saleitems.IsOnSale == true
                select new { saleitems.Title, saleitems.Description, saleitems.Genre }
                ).ToList();
            foreach (var item in salelist)
            {
                WorksIndexViewModel wivm = new WorksIndexViewModel();

                wivm.Title = item.Title;
                wivm.Description = item.Description;
                wivm.Genre = item.Genre;
                WIVMlist.Add(wivm);

            }
            if (HttpContext.Application["bookSaleCounter"] != null)
            {
                ViewBag.Participants = "People have participated in the current book sale " + HttpContext.Application["bookSaleCounter"] + " times.";
            }
            else
            {
               ViewBag.Participants = "Don't wait; we have a limited supply of sale items! ";
            }
            

            return View(WIVMlist);
        }

        // GET: Works/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }

        // GET: Works/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Works/Create
        public ActionResult Increment()
        {
            if (HttpContext.Application["bookSaleCounter"] == null)
            {
                //starting at 2 so i don't have to wory about pluralization ;)
                HttpContext.Application.Add("bookSaleCounter", 2);
            }
            else
            {
                HttpContext.Application["bookSaleCounter"] = Convert.ToInt32(HttpContext.Application["bookSaleCounter"]) + 1;
            }

            return RedirectToAction("Index");
        }



        // POST: Works/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrimaryKey,Title,Description,Genre")] Work work)
        {
            if (ModelState.IsValid)
            {
                db.Works.Add(work);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(work);
        }

        // GET: Works/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrimaryKey,Title,Description,Genre")] Work work)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(work);
        }

        // GET: Works/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Work work = db.Works.Find(id);
            db.Works.Remove(work);
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
