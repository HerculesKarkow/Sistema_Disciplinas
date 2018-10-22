using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DisciplinasFaculdade.Models
{
    [Table("DisponibilidadeSalas")]
    public class DisponibilidadeSalas
    {
        public int Id { get; set; }

        [ForeignKey("Sala")]
        public int IdSala { get; set; }

        public DiaDaSemana diaDaSemana { get; set; }

        public Turno turno { get; set; }

        public StatusSala statusSala { get; set; }
        
        public virtual Sala Sala { get; set; }
    }
}