using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

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
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<DisponibilidadeSalas> DisponibilidadeSalas { get; set; }
        public DbSet<CursoDisciplina> CursoDisciplina { get; set; }
        public DbSet<ProfessorCurso> ProfessorCurso { get; set; }
    }
}