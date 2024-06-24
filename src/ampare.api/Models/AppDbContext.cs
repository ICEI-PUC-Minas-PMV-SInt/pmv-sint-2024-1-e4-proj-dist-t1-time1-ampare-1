using ampare.api.Controllers;
using Microsoft.EntityFrameworkCore;

namespace ampare.api.Models
{
    public class AppDbContext : DbContext
    {
        // Construtor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets para as tabelas das classes
        public DbSet<Ong> Ongs { get; set; }

        public DbSet<Projeto> Projetos { get; set; }

        public DbSet<Voluntario> Voluntarios { get; set; }

        public DbSet<ProjetoVoluntario> ProjetoVoluntario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjetoVoluntario>()
            .HasKey(pv => new { pv.ProjetoId, pv.VoluntarioId });

        modelBuilder.Entity<ProjetoVoluntario>()
            .HasOne(pv => pv.Projeto)
            .WithMany(p => p.ProjetoVoluntario)
            .HasForeignKey(pv => pv.ProjetoId);

        modelBuilder.Entity<ProjetoVoluntario>()
            .HasOne(pv => pv.Voluntario)
            .WithMany(v => v.ProjetoVoluntario)
            .HasForeignKey(pv => pv.VoluntarioId);
    }
    }
  
}
