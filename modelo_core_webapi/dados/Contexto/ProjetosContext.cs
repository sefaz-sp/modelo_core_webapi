using Microsoft.EntityFrameworkCore;
using modelo.projetos;
using modelo_core_webapi.Persistencia;

namespace modelo_core_webapi.Contexto
{
    public class ProjetosContext : DbContext
    {
        public DbSet<Projetos> Projetos { get; set; }

        public ProjetosContext(DbContextOptions<ProjetosContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Projetos>(new ProjetosDBConfig());
            modelBuilder.Entity<Projetos>().HasKey(t => t.Id);
        }
    }
}
