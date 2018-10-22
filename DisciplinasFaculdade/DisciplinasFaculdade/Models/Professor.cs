
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DisciplinasFaculdade.Models
{
    [Table("Professor")]
    public class Professor
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nome Professor")]
        public string Nome { get; set; }
        [Required]
        [ForeignKey("Curso")]
        public int Id_Curso { get; set; }

        public virtual Curso Curso { get; set; }
    }
}