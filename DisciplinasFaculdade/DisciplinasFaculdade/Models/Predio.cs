using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DisciplinasFaculdade.Models
{
    [Table("Predio")]
    public class Predio
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Nome Prédio")]
        public string Descricao { get; set; }
    }
}