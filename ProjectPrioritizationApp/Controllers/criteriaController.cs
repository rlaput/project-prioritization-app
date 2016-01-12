using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectPrioritizationApp.Models;

namespace ProjectPrioritizationApp.Controllers
{
    public partial class criteriaController : Controller
    {
        private ppaContext db = new ppaContext();

        // GET: criteria
        public virtual ActionResult Index()
        {
            return View(db.criteria.OrderBy(s => s.CriterionName).ToList());
        }

        // GET: criteria/Details/5
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            criterion criteria = db.criteria.Find(id);
            if (criteria == null)
            {
                return HttpNotFound();
            }
            return View(criteria);
        }

        // GET: criteria/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: criteria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create([Bind(Include = "Id,CriterionName,Weight")] criterion criteria)
        {
            if (ModelState.IsValid)
            {
                db.criteria.Add(criteria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(criteria);
        }

        // GET: criteria/Edit/5
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            criterion criteria = db.criteria.Find(id);
            if (criteria == null)
            {
                return HttpNotFound();
            }
            return View(criteria);
        }

        // POST: criteria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit([Bind(Include = "Id,CriterionName,Weight")] criterion criteria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(criteria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(criteria);
        }

        // GET: criteria/Delete/5
        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            criterion criteria = db.criteria.Find(id);
            if (criteria == null)
            {
                return HttpNotFound();
            }
            return View(criteria);
        }

        // POST: criteria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            criterion criteria = db.criteria.Find(id);
            db.criteria.Remove(criteria);
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
