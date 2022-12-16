using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class PredizioneConfiguration : IEntityTypeConfiguration<Predizione>
    {
        public void Configure(EntityTypeBuilder<Predizione> entity)
        {
            entity.ToTable("predizioni");

            entity.HasIndex(e => e.IdAlgoritmo)
                .HasName("fk_predizioni_algoritmi1_idx");

            entity.HasIndex(e => e.IdPatologia)
                .HasName("fk_predizioni_patologie1_idx");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

            entity.Property(e => e.DataStato).HasColumnType("date");

            entity.Property(e => e.Esito).HasMaxLength(500);

            entity.Property(e => e.Stato).HasMaxLength(250);

            entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

            entity.HasOne(d => d.Algoritmo)
                .WithMany(p => p.Predizioni)
                .HasForeignKey(d => d.IdAlgoritmo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_predizioni_algoritmi1");

            entity.HasOne(d => d.Patologia)
                .WithMany(p => p.Predizioni)
                .HasForeignKey(d => d.IdPatologia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_predizioni_patologie1");

            entity.HasOne(d => d.Paziente)
                .WithMany(p => p.Predizioni)
                .HasForeignKey(d => d.IdPaziente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_predizioni_pazienti1");
        }
    }
}
