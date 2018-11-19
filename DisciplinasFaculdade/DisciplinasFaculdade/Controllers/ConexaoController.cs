using DisciplinasFaculdade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisciplinasFaculdade.Controllers
{
    public class ConexaoController : Controller
    {
        private DisciplinasContext db = new DisciplinasContext();
        // GET: Conexao
        public ActionResult Index()
        {
            ViewBag.Curso = new SelectList(db.Curso, "IdCurso", "Nome");
            return View();
        }

        // GET: Conexao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Conexao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conexao/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Conexao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Conexao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Conexao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Conexao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
