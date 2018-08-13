using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DisciplinasFaculdade.Models
{
    [Table("Disciplina")]
    public class Disciplina
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Curso")]
        public int IdCurso{ get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nome Disciplina")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Quantidade de alunos")]
        public int QtdAlunos { get; set; }
        [Required]
        [Display(Name = "Período")]
        public Periodo Periodo { get; set; }
        [Required]
        [Display(Name = "Dia da semana")]
        public DiaDaSemana DiaDaSemana { get; set; }

        public virtual Curso Curso { get; set; }
    }
}