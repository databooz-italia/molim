using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> entity)
        {
            entity.ToTable("features");

            entity.HasIndex(e => e.IdPatologia)
                .HasName("IX_ProgettiTest_IdProgetto");

            entity.HasIndex(e => e.IdTipoEsame)
                .HasName("IX_ProgettiTest_IdTipoTest");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

            entity.Property(e => e.Descrizione)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.IdFeature)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.IdPatologia)
                .IsRequired()
                .HasMaxLength(5);

            entity.Property(e => e.IdTipoEsame)
                .IsRequired()
                .HasMaxLength(5);

            entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

            entity.HasOne(d => d.Patologia)
                .WithMany(p => p.Features)
                .HasForeignKey(d => d.IdPatologia)
                .HasConstraintName("FK_ProgettiTest_Progetti_IdProgetto");

            entity.HasOne(x => x.TipoEsame)
                .WithMany(x => x.Features)
                .HasForeignKey(x => new { x.IdTipoEsame, x.IdPatologia });
        }
    }
}
