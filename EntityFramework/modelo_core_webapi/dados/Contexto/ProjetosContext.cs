using Microsoft.EntityFrameworkCore;
using Modelo.Core.Entity.Webapi.Persistencia;
using Modelo.Core.Domain.Entities;

namespace Modelo.Core.Entity.Webapi.Contexto
{
    public class ProjetosContext : DbContext
    {
        public DbSet<ProjetoEntity> ProjetoEntity { get; set; }

        public ProjetosContext(DbContextOptions<ProjetosContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<ProjetoEntity>(new ProjetosDBConfig());
            modelBuilder.Entity<ProjetoEntity>().HasKey(t => t.Id);
        }
    }
}
