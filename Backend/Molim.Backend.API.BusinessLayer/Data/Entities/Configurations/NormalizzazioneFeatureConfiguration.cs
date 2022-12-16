using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class NormalizzazioneFeatureConfiguration : IEntityTypeConfiguration<NormalizzazioneFeature>
    {
        public void Configure(EntityTypeBuilder<NormalizzazioneFeature> entity)
        {
            entity.ToTable("normalizzazione_features");

            entity.HasIndex(e => e.IdFeature)
                .HasName("IX_NormalizzazioneRisultatiTest_IdProgettoTest");

            entity.Property(e => e.Avalore)
                .HasColumnName("AValore")
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

            entity.Property(e => e.DaValore).HasColumnType("decimal(18,2)");

            entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

            entity.HasOne(d => d.Feature)
                .WithMany(p => p.NormalizzazioneFeatures)
                .HasForeignKey(d => d.IdFeature)
                .HasConstraintName("FK_NormalizzazioneRisultatiTest_ProgettiTest_IdProgettoTest");
        }
    }
}
