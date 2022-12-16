using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class FeatureEsameConfiguration : IEntityTypeConfiguration<FeatureEsame>
    {
        public void Configure(EntityTypeBuilder<FeatureEsame> entity)
        {
            entity.HasKey(e => e.ID )
                    .HasName("PRIMARY");
            
            entity.ToTable("features_esame");

            entity.HasIndex(e => e.IdFeature)
                .HasName("IX_DettagliEsitiTestPazienti_IdProgettoTest");

            entity.HasIndex(e => e.IdRegioneDiInteresse)
                .HasName("fk_dettagli_esami_regions_of_interest1_idx");

            entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

            entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

            entity.Property(e => e.Valore)
                .IsRequired()
                .HasMaxLength(500);

            entity.HasOne(d => d.Esame)
                .WithMany(p => p.FeaturesEsame)
                .HasForeignKey(d => d.IdEsame)
                .HasConstraintName("FK_DettagliEsitiTestPazienti_EsitiTestPazienti_IdEsitoTestPazie~");

            entity.HasOne(d => d.Feature)
                .WithMany(p => p.FeaturesEsame)
                .HasForeignKey(d => d.IdFeature)
                .HasConstraintName("FK_DettagliEsitiTestPazienti_ProgettiTest_IdProgettoTest");

            entity.HasOne(d => d.RegioneDiInteresse)
                .WithMany(p => p.FeaturesEsame)
                .HasForeignKey(d => d.IdRegioneDiInteresse)
                .HasConstraintName("fk_dettagli_esami_regions_of_interest1");

            entity.HasOne(d => d.Immagine)
                .WithMany(p => p.Features)
                .HasForeignKey(d => d.IdImmagine);
        }
    }
}
