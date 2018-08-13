using DisciplinasFaculdade.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Curso_ASP_MVC_EF.Models
{
    [Table("Sala")]
    public class Sala
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Nome Sala")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Quantidade de alunos")]
        public int QtdAlunos { get; set; }
        [Required]
        [Display(Name = "Quantidade de disciplinas")]
        public int QtdDisciplinas { get; set; }
        [Required]
        [ForeignKey("Predio")]
        public int IdPredio { get; set; }

        public virtual Predio Predio { get; set; }
    }
}