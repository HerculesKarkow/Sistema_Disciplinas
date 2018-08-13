using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Curso_ASP_MVC_EF.Models;

namespace DisciplinasFaculdade.Models
{
    public class DisciplinasContext : DbContext
    {
        public DisciplinasContext():base("DisciplinasFaculdade")
        {
            
        }
        public DbSet<Predio> Predio { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public System.Data.Entity.DbSet<DisciplinasFaculdade.Models.Disciplina> Disciplinas { get; set; }
    }
}