using Microsoft.EntityFrameworkCore;
using modelo.projetos;
using Modelo.Core.Entity.Webapi.Persistencia;

namespace Modelo.Core.Entity.Webapi.Contexto
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
            modelBuilder.Entity<Projetos>().HasKey(t => t.cd_projeto);
        }
    }
}
