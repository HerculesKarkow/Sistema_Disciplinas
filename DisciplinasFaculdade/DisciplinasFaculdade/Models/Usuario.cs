using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DisciplinasFaculdade.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nome Usuário")]
        public string Nome { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required]
        public TipoUsuario Tipo { get; set; }
    }
}