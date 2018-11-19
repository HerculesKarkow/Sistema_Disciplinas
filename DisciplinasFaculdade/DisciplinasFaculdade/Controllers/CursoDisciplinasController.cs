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
    public class CursoDisciplinasController : Controller
    {
        private DisciplinasContext db = new DisciplinasContext();

        // GET: CursoDisciplinas
        public ActionResult Index()
        {
            var cursoDisciplina = db.CursoDisciplina.Include(c => c.Curso).Include(c => c.Disciplina);
            return View(cursoDisciplina.ToList());
        }

        // GET: CursoDisciplinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoDisciplina cursoDisciplina = db.CursoDisciplina.Find(id);
            if (cursoDisciplina == null)
            {
                return HttpNotFound();
            }
            return View(cursoDisciplina);
        }

        // GET: CursoDisciplinas/Create
        public ActionResult Create()
        {
            ViewBag.IdCurso = new SelectList(db.Curso, "IdCurso", "Nome");
            ViewBag.IdDisciplina = new SelectList(db.Disciplinas, "Id", "Nome");
            return View();
        }

        // POST: CursoDisciplinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCursoDisciplina,IdDisciplina,IdCurso")] CursoDisciplina cursoDisciplina)
        {
            if (ModelState.IsValid)
            {
                db.CursoDisciplina.Add(cursoDisciplina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCurso = new SelectList(db.Curso, "IdCurso", "Nome", cursoDisciplina.IdCurso);
            ViewBag.IdDisciplina = new SelectList(db.Disciplinas, "Id", "Nome", cursoDisciplina.IdDisciplina);
            return View(cursoDisciplina);
        }

        // GET: CursoDisciplinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoDisciplina cursoDisciplina = db.CursoDisciplina.Find(id);
            if (cursoDisciplina == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCurso = new SelectList(db.Curso, "IdCurso", "Nome", cursoDisciplina.IdCurso);
            ViewBag.IdDisciplina = new SelectList(db.Disciplinas, "Id", "Nome", cursoDisciplina.IdDisciplina);
            return View(cursoDisciplina);
        }

        // POST: CursoDisciplinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCursoDisciplina,IdDisciplina,IdCurso")] CursoDisciplina cursoDisciplina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursoDisciplina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCurso = new SelectList(db.Curso, "IdCurso", "Nome", cursoDisciplina.IdCurso);
            ViewBag.IdDisciplina = new SelectList(db.Disciplinas, "Id", "Nome", cursoDisciplina.IdDisciplina);
            return View(cursoDisciplina);
        }

        // GET: CursoDisciplinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoDisciplina cursoDisciplina = db.CursoDisciplina.Find(id);
            if (cursoDisciplina == null)
            {
                return HttpNotFound();
            }
            return View(cursoDisciplina);
        }

        // POST: CursoDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CursoDisciplina cursoDisciplina = db.CursoDisciplina.Find(id);
            db.CursoDisciplina.Remove(cursoDisciplina);
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
