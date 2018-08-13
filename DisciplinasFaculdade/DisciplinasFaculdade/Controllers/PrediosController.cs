using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DisciplinasFaculdade.Models;

namespace DisciplinasFaculdade.Controllers
{
    public class PrediosController : Controller
    {
        private DisciplinasContext db = new DisciplinasContext();

        // GET: Predios
        public ActionResult Index()
        {
            return View(db.Predio.ToList());
        }

        // GET: Predios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predio predio = db.Predio.Find(id);
            if (predio == null)
            {
                return HttpNotFound();
            }
            return View(predio);
        }

        // GET: Predios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Predios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] Predio predio)
        {
            if (ModelState.IsValid)
            {
                db.Predio.Add(predio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(predio);
        }

        // GET: Predios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predio predio = db.Predio.Find(id);
            if (predio == null)
            {
                return HttpNotFound();
            }
            return View(predio);
        }

        // POST: Predios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] Predio predio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(predio);
        }

        // GET: Predios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predio predio = db.Predio.Find(id);
            if (predio == null)
            {
                return HttpNotFound();
            }
            return View(predio);
        }

        // POST: Predios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Predio predio = db.Predio.Find(id);
            db.Predio.Remove(predio);
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
