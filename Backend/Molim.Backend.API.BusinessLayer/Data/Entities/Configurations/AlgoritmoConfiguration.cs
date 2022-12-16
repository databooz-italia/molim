using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class AlgoritmoConfiguration : IEntityTypeConfiguration<Algoritmo>
    {
        public void Configure(EntityTypeBuilder<Algoritmo> entity)
        {
            entity.ToTable("algoritmi");

            entity.HasIndex(e => new { e.IdTipoEsame, e.IdPatologia })
                .HasName("fk_algoritmi_tipi_esami1_idx");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Descrizione)
                .IsRequired()
                .HasMaxLength(45);

            entity.Property(e => e.EndpointRest)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.IdPatologia)
                .IsRequired()
                .HasMaxLength(5);

            entity.Property(e => e.OggettoDiPredizione)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.IdTipoEsame)
                .IsRequired()
                .HasMaxLength(5);

            entity.Property(e => e.Tipo)
                .IsRequired()
                .HasMaxLength(20);

            entity.HasOne(d => d.TipoEsame)
                .WithMany(p => p.Algoritmi)
                .HasForeignKey(d => new { d.IdTipoEsame, d.IdPatologia })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_algoritmi_tipi_esami1");
        }
    }
}
