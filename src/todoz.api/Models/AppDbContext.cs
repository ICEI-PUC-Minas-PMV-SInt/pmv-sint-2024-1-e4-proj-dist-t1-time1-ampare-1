using Microsoft.EntityFrameworkCore;

namespace ampare.api.Models
{
    public class AppDbContext : DbContext
    {
        // Construtor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet para a tabela de cadastros
        public DbSet<Cadastro> Cadastros { get; set; }

        public DbSet<Ong> Ongs { get; set; }

        public DbSet<Project> Projetos { get; set; }
    }
  
}
