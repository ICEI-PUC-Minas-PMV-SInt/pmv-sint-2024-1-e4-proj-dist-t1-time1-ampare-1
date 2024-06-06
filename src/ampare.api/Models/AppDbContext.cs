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

        public DbSet<Project> Projetos { get; set; }

        public DbSet<Voluntario> Voluntarios { get; set; }
    }
  
}
