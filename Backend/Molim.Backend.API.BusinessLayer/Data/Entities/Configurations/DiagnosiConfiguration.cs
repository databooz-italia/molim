using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class DiagnosiConfiguration : IEntityTypeConfiguration<Diagnosi>
    {
        public void Configure(EntityTypeBuilder<Diagnosi> entity)
        {
            entity.ToTable("diagnosi");

            entity.HasIndex(e => e.IdPaziente)
                .HasName("fk_diagnosi_pazienti1_idx");

            entity.HasIndex(e => e.IdPatologia)
                .HasName("fk_diagnosi_patologie1_idx");

            entity.HasKey(e => new { e.IdPaziente, e.IdPatologia, e.Date });

            entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

            entity.Property(e => e.Esito).HasMaxLength(500);

            entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

            entity.HasOne(d => d.Paziente)
                .WithMany(p => p.Diagnosi)
                .HasForeignKey(d => d.IdPaziente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_diagnosi_pazienti1");

            entity.HasOne(d => d.Patologia)
                .WithMany(p => p.Diagnosi)
                .HasForeignKey(d => d.IdPatologia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_diagnosi_patologie1");
        }
    }
}
