using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RotteHullet;

namespace WebApplication1.Controllers
{
    public class UdlånController : Controller
    {
        private FoeniksDB db = new FoeniksDB();

        // GET: Udlån
        public ActionResult Index()
        {
            var udlån = db.Udlån.Include(u => u.Medlem);
            return View(udlån.ToList());
        }

        // GET: Udlån/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Udlån udlån = db.Udlån.Find(id);
            if (udlån == null)
            {
                return HttpNotFound();
            }
            return View(udlån);
        }

        // GET: Udlån/Create
        public ActionResult Create()
        {
            ViewBag.medlemid = new SelectList(db.Medlem, "medlemid", "brugernavn");
            return View();
        }

        // POST: Udlån/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "udlånid,udlåningsdato,afleveringsdato,reeleafleveringsdato,medlemid")] Udlån udlån)
        {
            if (ModelState.IsValid)
            {
                db.Udlån.Add(udlån);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.medlemid = new SelectList(db.Medlem, "medlemid", "brugernavn", udlån.medlemid);
            return View(udlån);
        }

        // GET: Udlån/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Udlån udlån = db.Udlån.Find(id);
            if (udlån == null)
            {
                return HttpNotFound();
            }
            ViewBag.medlemid = new SelectList(db.Medlem, "medlemid", "brugernavn", udlån.medlemid);
            return View(udlån);
        }

        // POST: Udlån/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "udlånid,udlåningsdato,afleveringsdato,reeleafleveringsdato,medlemid")] Udlån udlån)
        {
            if (ModelState.IsValid)
            {
                db.Entry(udlån).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.medlemid = new SelectList(db.Medlem, "medlemid", "brugernavn", udlån.medlemid);
            return View(udlån);
        }

        // GET: Udlån/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Udlån udlån = db.Udlån.Find(id);
            if (udlån == null)
            {
                return HttpNotFound();
            }
            return View(udlån);
        }

        // POST: Udlån/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Udlån udlån = db.Udlån.Find(id);
            db.Udlån.Remove(udlån);
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
