using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class RichiestaEsecuzioneFaseConfiguration : IEntityTypeConfiguration<RichiestaEsecuzioneFase>
    {
        public void Configure(EntityTypeBuilder<RichiestaEsecuzioneFase> entity)
        {
            entity.ToTable("richiestaesecuzionefasi");

            entity.HasKey(x => new { x.IdRichiestaEsecuzione, x.IdFase, x.Ordine });
            entity.Property(x => x.IdFase).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Status).HasMaxLength(250).IsRequired(false);

            entity.HasOne(x => x.Richiesta)
                .WithMany(x => x.Fasi)
                .HasForeignKey(x => x.IdRichiestaEsecuzione);
        }
    }
}
