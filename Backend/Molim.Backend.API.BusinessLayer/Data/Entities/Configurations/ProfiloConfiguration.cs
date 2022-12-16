using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class ProfiloConfiguration : IEntityTypeConfiguration<Profilo>
    {
        public void Configure(EntityTypeBuilder<Profilo> entity)
        {
            entity.HasKey(e => e.Tipo)
                     .HasName("PRIMARY");

            entity.ToTable("profili");

            entity.Property(e => e.Tipo).HasMaxLength(20);

            entity.Property(e => e.Descrizione).HasMaxLength(50);
        }
    }
}
