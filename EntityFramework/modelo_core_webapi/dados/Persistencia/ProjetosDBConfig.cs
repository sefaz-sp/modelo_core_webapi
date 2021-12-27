using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelo.Core.Domain.Entities;

namespace Modelo.Core.Entity.Webapi.Persistencia
{
    internal class ProjetosDBConfig : IEntityTypeConfiguration<ProjetoEntity>
    {
        public void Configure(EntityTypeBuilder<ProjetoEntity> builder)
        {
            builder
                .Property(l => l.Nome)
                .HasColumnType("nvarchar(20)")
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(l => l.Descricao)
                .HasColumnType("nvarchar(255)");
        }
    }
}
