using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class PatologiaConfiguration : IEntityTypeConfiguration<Patologia>
    {
        public void Configure(EntityTypeBuilder<Patologia> entity)
        {
            entity.HasKey(e => e.IdPatologia)
                    .HasName("PRIMARY");

            entity.ToTable("patologie");

            entity.Property(e => e.IdPatologia).HasMaxLength(5);

            entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

            entity.Property(e => e.Descrizione)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");
        }
    }
}
