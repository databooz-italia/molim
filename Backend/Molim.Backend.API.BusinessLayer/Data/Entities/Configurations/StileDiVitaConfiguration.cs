using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class StileDiVitaConfiguration : IEntityTypeConfiguration<StileDiVita>
    {
        public void Configure(EntityTypeBuilder<StileDiVita> entity)
        {
            entity.HasKey(e => e.IdStileDiVita)
                    .HasName("PRIMARY");

            entity.ToTable("stili_di_vita");

            entity.Property(e => e.IdStileDiVita).HasMaxLength(5);

            entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

            entity.Property(e => e.Descrizione)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");
        }
    }
}
