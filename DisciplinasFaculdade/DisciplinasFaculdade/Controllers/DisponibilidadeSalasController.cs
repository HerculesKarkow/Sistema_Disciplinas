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
    public class DisponibilidadeSalasController : Controller
    {
        private DisciplinasContext db = new DisciplinasContext();

        // GET: DisponibilidadeSalas
        public ActionResult Index()
        {
            var disponibilidadeSalas = db.DisponibilidadeSalas.Include(d => d.Sala);
            return View(disponibilidadeSalas.ToList());
        }

        // GET: DisponibilidadeSalas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisponibilidadeSalas disponibilidadeSalas = db.DisponibilidadeSalas.Find(id);
            if (disponibilidadeSalas == null)
            {
                return HttpNotFound();
            }
            return View(disponibilidadeSalas);
        }

        // GET: DisponibilidadeSalas/Create
        public ActionResult Create()
        {
            ViewBag.IdSala = new SelectList(db.Sala, "Id", "Nome");
            return View();
        }

        // POST: DisponibilidadeSalas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdSala,diaDaSemana,turno,statusSala")] DisponibilidadeSalas disponibilidadeSalas)
        {
            if (ModelState.IsValid)
            {
                db.DisponibilidadeSalas.Add(disponibilidadeSalas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSala = new SelectList(db.Sala, "Id", "Nome", disponibilidadeSalas.IdSala);
            return View(disponibilidadeSalas);
        }

        // GET: DisponibilidadeSalas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisponibilidadeSalas disponibilidadeSalas = db.DisponibilidadeSalas.Find(id);
            if (disponibilidadeSalas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSala = new SelectList(db.Sala, "Id", "Nome", disponibilidadeSalas.IdSala);
            return View(disponibilidadeSalas);
        }

        // POST: DisponibilidadeSalas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdSala,diaDaSemana,turno,statusSala")] DisponibilidadeSalas disponibilidadeSalas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disponibilidadeSalas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSala = new SelectList(db.Sala, "Id", "Nome", disponibilidadeSalas.IdSala);
            return View(disponibilidadeSalas);
        }

        // GET: DisponibilidadeSalas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisponibilidadeSalas disponibilidadeSalas = db.DisponibilidadeSalas.Find(id);
            if (disponibilidadeSalas == null)
            {
                return HttpNotFound();
            }
            return View(disponibilidadeSalas);
        }

        // POST: DisponibilidadeSalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DisponibilidadeSalas disponibilidadeSalas = db.DisponibilidadeSalas.Find(id);
            db.DisponibilidadeSalas.Remove(disponibilidadeSalas);
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
