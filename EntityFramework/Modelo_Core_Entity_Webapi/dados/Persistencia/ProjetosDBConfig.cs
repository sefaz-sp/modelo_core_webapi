﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using modelo.projetos;

namespace Modelo_Core_Entity_Webapi.Persistencia
{
    internal class ProjetosDBConfig : IEntityTypeConfiguration<Projetos>
    {
        public void Configure(EntityTypeBuilder<Projetos> builder)
        {
            builder
                .Property(l => l.nm_projeto)
                .HasColumnType("nvarchar(20)")
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(l => l.ds_projeto)
                .HasColumnType("nvarchar(255)");
        }
    }
}
