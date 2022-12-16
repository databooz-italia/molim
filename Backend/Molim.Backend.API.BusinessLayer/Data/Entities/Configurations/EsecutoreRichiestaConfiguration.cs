using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class EsecutoreRichiestaConfiguration : IEntityTypeConfiguration<EsecutoreRichiesta>
    {
        public void Configure(EntityTypeBuilder<EsecutoreRichiesta> entity)
        {
            entity.ToTable("esecutoririchieste");

            entity.HasKey(x => x.ID);
            entity.Property(x => x.ID).HasMaxLength(30);            
        }
    }
}
