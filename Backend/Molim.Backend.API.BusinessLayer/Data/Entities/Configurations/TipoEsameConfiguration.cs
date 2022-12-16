using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class TipoEsameConfiguration : IEntityTypeConfiguration<TipoEsame>
    {
        public void Configure(EntityTypeBuilder<TipoEsame> entity)
        {
            entity.HasKey(e => new { e.IdTipoEsame, e.IdPatologia })
                    .HasName("PRIMARY");

            entity.ToTable("tipi_esami");

            entity.HasIndex(e => e.IdPatologia)
                .HasName("fk_tipi_esami_patologie1_idx");

            entity.Property(e => e.IdTipoEsame).HasMaxLength(5);

            entity.Property(e => e.IdPatologia).HasMaxLength(5);

            entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

            entity.Property(e => e.Descrizione)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.RichiedeImmagini).HasColumnType("bit(1)");

            entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

            entity.HasOne(d => d.Patologia)
                .WithMany(p => p.TipiEsami)
                .HasForeignKey(d => d.IdPatologia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tipi_esami_patologie1");
        }
    }
}
