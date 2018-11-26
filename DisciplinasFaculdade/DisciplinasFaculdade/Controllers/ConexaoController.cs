using DisciplinasFaculdade.Models;
using ExcelLibrary.SpreadSheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

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

        [HttpPost]
        public ActionResult Index(int? IdCurso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var curso = db.Curso.FirstOrDefault(x => x.IdCurso == IdCurso);
                    List<CursoDisciplina> cursoDisciplina = db.CursoDisciplina.Where(x => x.IdCurso == IdCurso).ToList();

                    List<Disciplina> disciplinas = new List<Disciplina>();
                    foreach (var item in cursoDisciplina.OrderBy(x => x.Disciplina.Semestre).OrderBy(y=>y.Disciplina.DiaDaSemana).ToList())
                    {
                        disciplinas.Add(item.Disciplina);
                    }
                    disciplinas.OrderBy(x => x.Semestre).ToList();

                    GerarExcel(curso.Nome, disciplinas);

                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
        public ActionResult Create(string teste)
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

        public ActionResult GerarExcel(string Curso, List<Disciplina> disciplinas)
        {
            #region Atributos

            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet ws;
            Excel.Range oRng;
            //Start Excel and get Application object.
            oXL = new Excel.Application();


            //Get a new workbook.
            oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));

            ws = (Excel._Worksheet)oWB.ActiveSheet;

            int linha = 1;

            #endregion Atributos



            #region Construção do Cabeçalho

            #region Curso
            oRng = ws.get_Range("A" + linha, "O" + linha);
            oRng.Font.Bold = true;
            oRng.Merge(Missing.Value);
            oRng.Value2 = Curso;
            oRng.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oRng.Interior.Color = System.Drawing.Color.Aqua;
            oRng.Borders.Color = System.Drawing.Color.Black;
            oRng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            linha++;
            #endregion Curso



            #region Dia da Semana
            oRng = ws.get_Range("A" + linha, "B" + linha);
            oRng.Font.Bold = true;
            oRng.Merge(Missing.Value);
            oRng.Value2 = "Dia da Semana";
            oRng.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oRng.Borders.Color = System.Drawing.Color.Black;
            oRng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            #endregion Dia da Semana

            #region Disciplina
            oRng = ws.get_Range("C" + linha, "H" + linha);
            oRng.Font.Bold = true;
            oRng.Merge(Missing.Value);
            oRng.Value2 = "Disciplina";
            oRng.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oRng.Borders.Color = System.Drawing.Color.Black;
            oRng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            #endregion Disciplina

            #region Professor
            oRng = ws.get_Range("I" + linha, "M" + linha);
            oRng.Font.Bold = true;
            oRng.Merge(Missing.Value);
            oRng.Value2 = "Professor";
            oRng.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oRng.Borders.Color = System.Drawing.Color.Black;
            oRng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            #endregion Professor

            #region Sala
            oRng = ws.get_Range("N" + linha, "O" + linha);
            oRng.Font.Bold = true;
            oRng.Merge(Missing.Value);
            oRng.Value2 = "Sala";
            oRng.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oRng.Borders.Color = System.Drawing.Color.Black;
            oRng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            linha++;
            #endregion Sala



            #endregion Construção do Cabeçalho

            #region Inserção de Dados
            int semestre = 0;
            foreach (var item in disciplinas)
            {
                if (item.Semestre != semestre)
                {
                    #region Semestre
                    oRng = ws.get_Range("A" + linha, "O" + linha);
                    oRng.Font.Bold = true;
                    oRng.Merge(Missing.Value);
                    oRng.Value2 = String.Format("{0}º Semestre", item.Semestre.ToString());
                    semestre = item.Semestre;
                    oRng.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    oRng.Borders.Color = System.Drawing.Color.Black;
                    oRng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    linha++;
                    #endregion Semestre
                }

                #region Dia da Semana
                oRng = ws.get_Range("A" + linha, "B" + linha);
                oRng.Merge(Missing.Value);
                oRng.Value2 = item.DiaDaSemana.ToString();
                oRng.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oRng.Borders.Color = System.Drawing.Color.Black;
                oRng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                #endregion Dia da Semana

                #region Disciplina
                oRng = ws.get_Range("C" + linha, "H" + linha);
                oRng.Merge(Missing.Value);
                oRng.Value2 = item.Nome.ToString(); ;
                oRng.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oRng.Borders.Color = System.Drawing.Color.Black;
                oRng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                #endregion Disciplina

                #region Professor
                oRng = ws.get_Range("I" + linha, "M" + linha);
                oRng.Merge(Missing.Value);
                oRng.Value2 = item.Professor.Nome.ToString();
                oRng.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oRng.Borders.Color = System.Drawing.Color.Black;
                oRng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                #endregion Professor

                #region Sala
                oRng = ws.get_Range("N" + linha, "O" + linha);
                oRng.Merge(Missing.Value);
                oRng.Value2 = String.Concat(item.Sala.Nome, " - ", item.Sala.Predio.Descricao).ToString();
                oRng.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oRng.Borders.Color = System.Drawing.Color.Black;
                oRng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                #endregion Sala

                linha++;
            }

            #endregion Inserção de Dados
            oXL.Visible = true;

            return null;
        }






        //       public ActionResult TesteExcelLibrary()
        //       {
        //           Workbook workbook = new Workbook();
        //           Worksheet worksheet = new Worksheet("First Sheet");

        //           #region Criação das células

        //           int row = 0;
        //           worksheet.Cells[row, 0] = new Cell("Sistemas de Informação - 2019/01");
        //           //worksheet.Cells[row, 0].



        //           worksheet.Cells[row, 0] = new Cell("1° Semestre - SIS1");
        //           //worksheet.Cells[row, 2] = new Cell((decimal)3.45);
        //           //worksheet.Cells[row, 3] = new Cell("Text string");
        //           //worksheet.Cells[row, 4] = new Cell("Second string");
        //           //worksheet.Cells[row, 5] = new Cell(32764.5, "#,##0.00");
        //           //worksheet.Cells[row, 6] = new Cell(DateTime.Now, @"YYYY\-MM\-DD");

        //           #endregion Criação das células

        //           #region Configurações de células
        //           worksheet.Cells.ColumnWidth[0, 0] = 10000;
        //           worksheet.Cells.ColumnWidth[1, 0] = 20000;

        //           #endregion Configurações de células


        //           //worksheet.Cells[row, 0] = new Cell((short)1);
        //           //worksheet.Cells[row, 1] = new Cell(9999999);
        //           //worksheet.Cells[row, 2] = new Cell((decimal)3.45);
        //           //worksheet.Cells[row, 3] = new Cell("Text string");
        //           //worksheet.Cells[row, 4] = new Cell("Second string");
        //           //worksheet.Cells[row, 5] = new Cell(32764.5, "#,##0.00");
        //           //worksheet.Cells[row, 6] = new Cell(DateTime.Now, @"YYYY\-MM\-DD");
        //           //worksheet.Cells.ColumnWidth[0, 0] = 3000;
        //           //worksheet.Cells.ColumnWidth[2, 2] = 3000;
        //           //worksheet.Cells.ColumnWidth[6, 6] = 8000;

        //           //Resolve problema: O Excel encontrou conteúdo ilegível / Invalid or corrupt file (unreadable content)
        //           while (row < 100)
        //{
        //               row++;
        //               worksheet.Cells[row, 0] = new Cell(" ");
        //           }

        //           workbook.Worksheets.Add(worksheet);

        //           MemoryStream stream = new MemoryStream();
        //           workbook.Save(stream);

        //           Response.Clear();
        //           Response.ContentType = "application/vnd.ms-excel";
        //           Response.AddHeader("content-disposition", string.Format("attachment;filename=Teste_{0}.xls", DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")));

        //           stream.WriteTo(Response.OutputStream);

        //           Response.End();

        //           return null;
        //       }
    }
}
