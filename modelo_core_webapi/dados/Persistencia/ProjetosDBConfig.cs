using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using modelo.projetos;

namespace modelo_core_webapi.Persistencia
{
    internal class ProjetosDBConfig : IEntityTypeConfiguration<Projetos>
    {
        public void Configure(EntityTypeBuilder<Projetos> builder)
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
