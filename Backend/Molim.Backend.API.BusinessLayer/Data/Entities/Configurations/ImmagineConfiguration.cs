using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class ImmagineConfiguration : IEntityTypeConfiguration<Immagine>
    {
        public void Configure(EntityTypeBuilder<Immagine> entity)
        {
            entity.ToTable("immagini");

            entity.HasIndex(e => e.IdEsame)
                .HasName("fk_immagini_esami1_idx");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

            entity.Property(e => e.DataCaricamento).HasColumnType("date");

            entity.Property(e => e.NomeFile)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

            entity.HasOne(d => d.Esame)
                .WithMany(p => p.Immagini)
                .HasForeignKey(d => d.IdEsame)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_immagini_esami1");
        }
    }
}
