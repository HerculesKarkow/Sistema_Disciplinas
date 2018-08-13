using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DisciplinasFaculdade.Models
{
    [Table("Curso")]
    public class Curso
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Nome Curso")]
        public string Nome { get; set; }
    }
}