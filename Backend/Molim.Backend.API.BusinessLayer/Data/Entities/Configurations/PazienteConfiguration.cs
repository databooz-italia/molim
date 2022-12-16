using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class PazienteConfiguration : IEntityTypeConfiguration<Paziente>
    {
        public void Configure(EntityTypeBuilder<Paziente> entity)
        {
            entity.HasKey(e => e.IdPaziente)
                    .HasName("PRIMARY");

            entity.ToTable("pazienti");

            entity.Property(e => e.IdPaziente).HasMaxLength(50);

            entity.Property(e => e.City).HasMaxLength(500);

            entity.Property(e => e.CodiceFiscale).HasMaxLength(20);

            entity.Property(e => e.CognomePaziente).HasMaxLength(20);

            entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

            entity.Property(e => e.Indirizzo).HasMaxLength(500);

            entity.Property(e => e.IndirizzoMail).HasMaxLength(500);

            entity.Property(e => e.NomePaziente).HasMaxLength(20);

            entity.Property(e => e.NumeroCellulare).HasMaxLength(20);

            entity.Property(e => e.Sesso).HasMaxLength(10);

            entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");
        }
    }
}
