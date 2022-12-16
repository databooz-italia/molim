using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class PermessoProfiloConfiguration : IEntityTypeConfiguration<PermessoProfilo>
    {
        public void Configure(EntityTypeBuilder<PermessoProfilo> entity)
        {
            entity.HasKey(e => new { e.TipoRuolo, e.Permesso })
                    .HasName("PRIMARY");

            entity.ToTable("permessi_profili");

            entity.Property(e => e.TipoRuolo).HasMaxLength(20);

            entity.Property(e => e.Permesso).HasMaxLength(50);

            entity.Property(e => e.CreatorAccountId).HasColumnName("CreatorAccount_ID");

            entity.Property(e => e.UpdaterAccountId).HasColumnName("UpdaterAccount_ID");

            entity.HasOne(d => d.Profilo)
                .WithMany(p => p.PermessiProfili)
                .HasForeignKey(d => d.TipoRuolo)
                .HasConstraintName("fk_roles_permissions");
        }
    }
}
