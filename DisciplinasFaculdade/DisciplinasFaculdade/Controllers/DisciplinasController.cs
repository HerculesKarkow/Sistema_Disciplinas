using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DisciplinasFaculdade.Models;
using DisciplinasFaculdade.ViewModels;

namespace DisciplinasFaculdade.Controllers
{
    public class DisciplinasController : Controller
    {
        private DisciplinasContext db = new DisciplinasContext();

        // GET: Disciplinas
        public ActionResult Index()
        {
            var disciplinas = db.Disciplinas.Include(d => d.Professor).Include(d => d.Sala);
            return View(disciplinas.ToList());
        }

        // GET: Disciplinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplina disciplina = db.Disciplinas.Find(id);
            if (disciplina == null)
            {
                return HttpNotFound();
            }
            return View(disciplina);
        }

        // GET: Disciplinas/Create
        public ActionResult Create()
        {
            var predio = new SelectList(db.Predio, "IdPredio", "Nome");

            ViewBag.IdProfessor = new SelectList(db.Professor, "IdProfessor", "Nome");
            ViewBag.IdSala = new SelectList(db.Sala, "IdSala", "Nome");
            ViewBag.IdCurso = new SelectList(db.Curso, "IdCurso", "Nome");
            return View();
        }

        // POST: Disciplinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Turno,Semestre,QtdAlunos,DiaDaSemana,IdSala,IdProfessor,DisciplinaParcial")] Disciplina disciplina, DisciplinaViewModel DisciplinaVM, CursoDisciplina CD, DisponibilidadeSalas DS)
        {
            if (ModelState.IsValid)
            {
                db.Disciplinas.Add(disciplina);
                db.CursoDisciplina.Add(CD);
                db.DisponibilidadeSalas.Add(DS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProfessor = new SelectList(db.Professor, "IdProfessor", "Nome", disciplina.IdProfessor);
            ViewBag.IdSala = new SelectList(db.Sala, "IdSala", "Nome", disciplina.IdSala);
            ViewBag.IdCurso = new SelectList(db.Curso, "IdCurso", "Curso");
            return View(disciplina);
        }

        // GET: Disciplinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplina disciplina = db.Disciplinas.Find(id);
            if (disciplina == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProfessor = new SelectList(db.Professor, "IdProfessor", "Nome", disciplina.IdProfessor);
            ViewBag.IdSala = new SelectList(db.Sala, "IdSala", "Nome", disciplina.IdSala);
            ViewBag.IdCurso = new SelectList(db.Curso, "IdCurso", "Curso");
            return View(disciplina);
        }

        // POST: Disciplinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Turno,Semestre,QtdAlunos,DiaDaSemana,IdSala,IdProfessor,DisciplinaParcial")] Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disciplina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProfessor = new SelectList(db.Professor, "IdProfessor", "Nome", disciplina.IdProfessor);
            ViewBag.IdSala = new SelectList(db.Sala, "IdSala", "Nome", disciplina.IdSala);
            ViewBag.IdCurso = new SelectList(db.Curso, "IdCurso", "Curso");
            return View(disciplina);
        }

        // GET: Disciplinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplina disciplina = db.Disciplinas.Find(id);
            if (disciplina == null)
            {
                return HttpNotFound();
            }
            return View(disciplina);
        }

        // POST: Disciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disciplina disciplina = db.Disciplinas.Find(id);
            db.Disciplinas.Remove(disciplina);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #region Métodos Auxiliares

        public JsonResult GetProfessoresList (int? IdCurso)
        {
            if (IdCurso != null)
            {
                List<ProfessorCurso> ProfessorCursoList = db.ProfessorCurso.Where(x => x.IdCurso == IdCurso).ToList();
                List<Professor> ProfessorList = new List<Professor>();
                for (int i = 0; i < ProfessorCursoList.Count; i++)
                {

                    ProfessorList.Add(ProfessorCursoList[i].Professor);
                }
                return Json(ProfessorList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        //public JsonResult GetSalasQuantidade(int? QuantidadeAlunos, int? turno, int? diaSemana)
        //{
        //    if (QuantidadeAlunos != null)
        //    {
        //        List<DisponibilidadeSalas> DisponibilidadeSalaList = new List<DisponibilidadeSalas>();
        //        List<Sala> SalaQuantidadeList = db.Sala.Where(x => x.QtdLugares >= QuantidadeAlunos).ToList();
                
        //        for (int i = 0; i < SalaQuantidadeList.Count; i++)
        //        {
        //            DisponibilidadeSalaList[i] = SalaQuantidadeList[i].);
        //        }

        //        return Json(SalaQuantidadeList, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(null, JsonRequestBehavior.AllowGet);
        //    }
        //}

        #endregion Métods Auxiliares

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
