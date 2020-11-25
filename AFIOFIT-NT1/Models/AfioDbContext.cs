using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFIOFIT_NT1.Models
{
    public class AfioDbContext : DbContext
    {
        public AfioDbContext(DbContextOptions<AfioDbContext> options) : base(options)
        {
        }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<UsuarioCurso> UsuarioCurso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UsuarioCurso>()
              //  .HasKey(uc => new { uc.UsuarioId, uc.CursoId });

            modelBuilder.Entity<UsuarioCurso>()
                .HasOne(uc => uc.ApplicationUser)
                .WithMany(au => au.Cursos)
                .HasForeignKey(uc => uc.UsuarioId);

            modelBuilder.Entity<UsuarioCurso>()
                .HasOne(uc => uc.Curso)
                .WithMany(uc => uc.Usuarios)
                .HasForeignKey(uc => uc.CursoId);
        }

    }
}
