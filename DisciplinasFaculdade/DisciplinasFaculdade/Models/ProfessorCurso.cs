using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DisciplinasFaculdade.Models
{
    [Table("ProfessorCurso")]
    public class ProfessorCurso
    {
        public int Id { get; set; }

        [ForeignKey("Professor")]
        public int IdProfessor { get; set; }

        [ForeignKey("Curso")]
        public int IdCurso { get; set; }

        public virtual Professor Professor { get; set; }
        public virtual Curso Curso { get; set; }
    }
}