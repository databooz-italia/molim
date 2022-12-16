using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class RegioneDiInteresseConfiguration : IEntityTypeConfiguration<RegioneDiInteresse>
    {
        public void Configure(EntityTypeBuilder<RegioneDiInteresse> entity)
        {
            entity.ToTable("regioni_di_interesse");

            entity.HasIndex(e => e.IdImmagine)
                .HasName("fk_regions_of_interest_immagini1_idx");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

            entity.Property(e => e.DataCaricamento).HasColumnType("date");

            entity.Property(e => e.NomeFile)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

            entity.HasOne(d => d.Immagine)
                .WithMany(p => p.RegioniDiInteresse)
                .HasForeignKey(d => d.IdImmagine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_regions_of_interest_immagini1");
        }
    }
}
