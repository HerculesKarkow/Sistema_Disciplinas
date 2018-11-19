using DisciplinasFaculdade.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DisciplinasFaculdade.ViewModels
{
    public class DisciplinaViewModel
    {
        [Key]
        [Column(Order = 0)]
        public int IdDisciplina { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nome Disciplina")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Curso")]
        [ForeignKey("Curso")]
        public int IdCurso { get; set; }
        [Required]
        [Display(Name = "Turno")]
        public Turno Turno { get; set; }
        [Required]
        [Display(Name = "Semestre")]
        public int Semestre { get; set; }
        [Required]
        [Display(Name = "Quantidade de alunos")]
        public int QtdAlunos { get; set; }
        [Required]
        [Display(Name = "Dia da semana")]
        public DiaDaSemana DiaDaSemana { get; set; }
        [Required]
        [ForeignKey("Sala")]
        public int IdSala { get; set; }
        [Required]
        [ForeignKey("Professor")]
        public int IdProfessor { get; set; }
        [Display(Name = "Disciplina de 36 Horas")]
        public bool DisciplinaParcial { get; set; }
        [Display(Name = "Usar sala em período Integral?")]
        public bool IndisponibilizarSala { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual Sala Sala { get; set; }
        public virtual Professor Professor { get; set; }

    }
}