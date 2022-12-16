using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class EsameConfiguration : IEntityTypeConfiguration<Esame>
    {
        public void Configure(EntityTypeBuilder<Esame> entity)
        {
            entity.HasKey(e => e.IdEsame)
                    .HasName("PRIMARY");

            entity.ToTable("esami");

            entity.HasIndex(e => e.IdPatologia)
                .HasName("fk_patologia_esami_idx");

            entity.HasIndex(e => e.IdPaziente)
                .HasName("IX_EsitiTestPazienti_IdPaziente");

            entity.HasIndex(e => e.IdTipoEsame)
                .HasName("fk_esami_tipi_esami1_idx");

            entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

            entity.Property(e => e.IdPatologia)
                .IsRequired()
                .HasMaxLength(5);

            entity.Property(e => e.IdPaziente)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.IdTipoEsame)
                .IsRequired()
                .HasMaxLength(5);

            entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

            entity.HasOne(d => d.Patologia)
                .WithMany(p => p.Esami)
                .HasForeignKey(d => d.IdPatologia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_patologia_esami");

            entity.HasOne(d => d.Paziente)
                .WithMany(p => p.Esami)
                .HasForeignKey(d => d.IdPaziente)
                .HasConstraintName("FK_EsitiTestPazienti_Pazienti_IdPaziente");

            entity.HasOne(d => d.TipoEsame)
               .WithMany(p => p.Esami)
               .HasForeignKey(d => new { d.IdTipoEsame, d.IdPatologia });
        }
    }
}
