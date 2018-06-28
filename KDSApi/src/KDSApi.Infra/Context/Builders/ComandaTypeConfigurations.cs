using KDSApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KDSApi.Infra.Context.Builders
{
    public class ComandaTypeConfigurations : IEntityTypeConfiguration<Comanda>
    {
        public void Configure(EntityTypeBuilder<Comanda> builder)
        {
            builder.ToTable("Comanda");

            builder.HasKey(k => k.IdComanda);
            builder.Property(p => p.NumeroComanda).IsRequired();
        }
    }
}
