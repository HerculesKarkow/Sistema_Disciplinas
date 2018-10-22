using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DisciplinasFaculdade.Models
{
    [Table("CursoDisciplina")]
    public class CursoDisciplina
    {
        public int Id { get; set; }

        [ForeignKey("Disciplina")]
        public int IdDiscipplina { get; set; }
        [ForeignKey("Curso")]
        public int IdCurso { get; set; }

        public virtual Disciplina Disciplina { get; set; }
        public virtual Curso Curso { get; set; }
    }
}