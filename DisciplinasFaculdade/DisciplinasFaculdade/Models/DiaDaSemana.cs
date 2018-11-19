using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DisciplinasFaculdade.Models
{
    public enum DiaDaSemana
    {
        [Display(Name = "Domingo")]
        Domingo,
        [Display(Name = "Segunda-feira")]
        Segunda,
        [Display(Name = "Terça-feira")]
        Terca,
        [Display(Name = "Quarta-feira")]
        Quarta,
        [Display(Name = "Quinta-feira")]
        Quinta,
        [Display(Name = "Sexta-feira")]
        Sexta,
        [Display(Name = "Sábado")]
        Sabado        
    }
}