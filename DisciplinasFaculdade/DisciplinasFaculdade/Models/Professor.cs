
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
        [Key]
        [Column(Order = 0)]
        public int IdProfessor { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nome Professor")]
        public string Nome { get; set; }
    }
}