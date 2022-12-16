using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class StileDiVitaPazienteConfiguration : IEntityTypeConfiguration<StileDiVitaPaziente>
    {
        public void Configure(EntityTypeBuilder<StileDiVitaPaziente> entity)
        {
            entity.HasKey(e => new { e.IdStileDiVita, e.IdPaziente })
                   .HasName("PRIMARY");

            entity.ToTable("stili_di_vita_pazienti");

            entity.HasIndex(e => e.IdPaziente)
                .HasName("IX_StiliDiVitaPazienti_IdPaziente");

            entity.Property(e => e.IdStileDiVita).HasMaxLength(5);

            entity.Property(e => e.IdPaziente).HasMaxLength(50);

            entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

            entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

            entity.HasOne(d => d.Paziente)
                .WithMany(p => p.StiliDiVitaPazienti)
                .HasForeignKey(d => d.IdPaziente)
                .HasConstraintName("FK_StiliDiVitaPazienti_Pazienti_IdPaziente");

            entity.HasOne(d => d.StileDiVita)
                .WithMany(p => p.StiliDiVitaPazienti)
                .HasForeignKey(d => d.IdStileDiVita)
                .HasConstraintName("FK_StiliDiVitaPazienti_StiliDiVita_IdStileDiVita");
        }
    }
}
