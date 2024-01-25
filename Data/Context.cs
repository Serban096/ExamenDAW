using examen.Models;
using Microsoft.EntityFrameworkCore;

namespace examen.Data
{
    public class Context : DbContext
    {
      

        public DbSet<Profesor> Profesori {get;set;}
        public DbSet<Materie> Materii { get; set; }

        public DbSet<Models.ProfesoriMaterii> ProfesoriMaterii { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfesoriMaterii>()
                .HasKey(pm => new { pm.ProfesorId, pm.MaterieId });

            modelBuilder.Entity<ProfesoriMaterii>()
                .HasOne(pm => pm.Profesor)
                .WithMany(p => p.ProfesoriMaterii)
                .HasForeignKey(pm => pm.ProfesorId);

            modelBuilder.Entity<ProfesoriMaterii>()
                .HasOne(pm => pm.Materie)
                .WithMany(m => m.ProfesoriMaterii)
                .HasForeignKey(pm => pm.MaterieId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
