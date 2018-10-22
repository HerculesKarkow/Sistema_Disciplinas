using DisciplinasFaculdade.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DisciplinasFaculdade.Models
{
    [Table("Sala")]
    public class Sala
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Predio")]
        public int IdPredio { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Nome Sala")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Quantidade de Lugares")]
        public int QtdLugares { get; set; }

        public virtual Predio Predio { get; set; }
    }
}