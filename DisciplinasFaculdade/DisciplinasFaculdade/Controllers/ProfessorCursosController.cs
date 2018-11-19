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
    public class ProfessorCursosController : Controller
    {
        private DisciplinasContext db = new DisciplinasContext();

        // GET: ProfessorCursos
        public ActionResult Index()
        {
            var professorCurso = db.ProfessorCurso.Include(p => p.Curso).Include(p => p.Professor);
            return View(professorCurso.ToList());
        }

        // GET: ProfessorCursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorCurso professorCurso = db.ProfessorCurso.Find(id);
            if (professorCurso == null)
            {
                return HttpNotFound();
            }
            return View(professorCurso);
        }

        // GET: ProfessorCursos/Create
        public ActionResult Create()
        {
            ViewBag.IdCurso = new SelectList(db.Curso, "IdCurso", "Nome");
            ViewBag.IdProfessor = new SelectList(db.Professor, "IdProfessor", "Nome");
            return View();
        }

        // POST: ProfessorCursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProfessorCurso,IdProfessor,IdCurso")] ProfessorCurso professorCurso)
        {
            if (ModelState.IsValid)
            {
                db.ProfessorCurso.Add(professorCurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCurso = new SelectList(db.Curso, "IdCurso", "Nome", professorCurso.IdCurso);
            ViewBag.IdProfessor = new SelectList(db.Professor, "IdProfessor", "Nome", professorCurso.IdProfessor);
            return View(professorCurso);
        }

        // GET: ProfessorCursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorCurso professorCurso = db.ProfessorCurso.Find(id);
            if (professorCurso == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCurso = new SelectList(db.Curso, "IdCurso", "Nome", professorCurso.IdCurso);
            ViewBag.IdProfessor = new SelectList(db.Professor, "IdProfessor", "Nome", professorCurso.IdProfessor);
            return View(professorCurso);
        }

        // POST: ProfessorCursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProfessorCurso,IdProfessor,IdCurso")] ProfessorCurso professorCurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professorCurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCurso = new SelectList(db.Curso, "IdCurso", "Nome", professorCurso.IdCurso);
            ViewBag.IdProfessor = new SelectList(db.Professor, "IdProfessor", "Nome", professorCurso.IdProfessor);
            return View(professorCurso);
        }

        // GET: ProfessorCursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorCurso professorCurso = db.ProfessorCurso.Find(id);
            if (professorCurso == null)
            {
                return HttpNotFound();
            }
            return View(professorCurso);
        }

        // POST: ProfessorCursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfessorCurso professorCurso = db.ProfessorCurso.Find(id);
            db.ProfessorCurso.Remove(professorCurso);
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
