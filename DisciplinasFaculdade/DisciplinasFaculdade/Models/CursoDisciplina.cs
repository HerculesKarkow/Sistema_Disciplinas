using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DisciplinasFaculdade.Models
{
    [Table("CursoDisciplina")]
    public class CursoDisciplina
    {
        [Key]
        [Column(Order = 0)]
        public int IdCursoDisciplina { get; set; }

        [ForeignKey("Disciplina")]
        public int IdDisciplina { get; set; }
        [ForeignKey("Curso")]
        public int IdCurso { get; set; }

        public virtual Disciplina Disciplina { get; set; }
        public virtual Curso Curso { get; set; }
    }
}