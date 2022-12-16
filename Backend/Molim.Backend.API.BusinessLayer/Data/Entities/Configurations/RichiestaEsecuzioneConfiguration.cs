using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class RichiestaEsecuzioneConfiguration : IEntityTypeConfiguration<RichiestaEsecuzione>
    {
        public void Configure(EntityTypeBuilder<RichiestaEsecuzione> entity)
        {
            entity.ToTable("richiesteesecuzione");

            entity.HasKey(x => x.ID);
            entity.Property(x => x.ID).ValueGeneratedOnAdd();

            entity.Property(x => x.IdPaziente).HasMaxLength(50).IsRequired();
            entity.Property(x => x.IdPatologia).HasMaxLength(5).IsRequired();
            entity.Property(x => x.IdImmagine).IsRequired();
            entity.Property(x => x.IdRegioneDiInteresse).IsRequired(false);

            entity.Property(x => x.IdEsecutore).HasMaxLength(30).IsRequired();

            entity.HasOne(x => x.Paziente)
                .WithMany(x => x.RichiesteEsecuzione)
                .HasForeignKey(x => x.IdPaziente);

            entity.HasOne(x => x.Algoritmo)
                .WithMany(x => x.RichiesteEsecuzione)
                .HasForeignKey(x => x.IdAlgoritmo);

            entity.HasOne(x => x.Esecutore)
                .WithMany(x => x.RichiesteEsecuzione)
                .HasForeignKey(x => x.IdEsecutore);

            entity.HasOne(x => x.Immagine)
                .WithMany(x => x.RichiesteEsecuzione)
                .HasForeignKey(x => x.IdImmagine);

            entity.HasOne(x => x.RegioneDiInteresse)
                .WithMany(x => x.RichiesteEsecuzione)
                .HasForeignKey(x => x.IdRegioneDiInteresse);
        }
    }
}
