using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class ScorePredizioniConfiguration : IEntityTypeConfiguration<ScorePredizione>
    {
        public void Configure(EntityTypeBuilder<ScorePredizione> entity)
        {
            entity.HasKey(e => new { e.Descrizione, e.IdPredizione })
                    .HasName("PRIMARY");

            entity.ToTable("score_predizioni");

            entity.HasIndex(e => e.IdPredizione)
                .HasName("fk_score_predizioni_diagnosi1_idx");

            entity.Property(e => e.Descrizione).HasMaxLength(200);

            entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

            entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

            entity.Property(e => e.Valore).HasMaxLength(50);

            entity.HasOne(d => d.Predizione)
                .WithMany(p => p.ScoreDiagnosi)
                .HasForeignKey(d => d.IdPredizione)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_score_predizioni_diagnosi1");
        }
    }
}
