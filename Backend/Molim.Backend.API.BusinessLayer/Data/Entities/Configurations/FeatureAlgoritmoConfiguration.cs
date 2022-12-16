using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class FeatureAlgoritmoConfiguration : IEntityTypeConfiguration<FeatureAlgoritmo>
    {
        public void Configure(EntityTypeBuilder<FeatureAlgoritmo> entity)
        {
            entity.ToTable("features_algoritmi");

            entity.HasKey(x => new { x.IdAlgoritmo, x.IdFeature });

            entity.HasOne(d => d.Algoritmo)
                .WithMany(p => p.Features)
                .HasForeignKey(d => d.IdAlgoritmo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_algoritmifeatures_algoritmi");

            entity.HasOne(d => d.Feature)
               .WithMany(p => p.Algoritmi)
               .HasForeignKey(d => d.IdFeature)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("fk_algoritmifeatures_features");
        }
    }
}
