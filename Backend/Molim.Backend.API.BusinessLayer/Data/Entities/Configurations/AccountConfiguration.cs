using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();

            entity.Property(x => x.Username).HasMaxLength(100);
            entity.Property(x => x.Cognome).HasMaxLength(250);
            entity.Property(x => x.Nome).HasMaxLength(250);

            entity.Property(x => x.Version).IsConcurrencyToken();

            entity.HasOne(x => x.Profilo)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.TipoRuolo)
                .HasConstraintName("fk_account_role");
        }
    }
}
