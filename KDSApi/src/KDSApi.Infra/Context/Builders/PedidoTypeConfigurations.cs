using KDSApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KDSApi.Infra.Context.Builders
{
    class PedidoTypeConfigurations : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(k => k.IdPedido);
            builder.Property(p => p.IdComanda).IsRequired();
            builder.Property(p => p.CanalAtendimento).IsRequired();
            builder.Property(p => p.CodigoPedido).IsRequired();
            builder.Property(p => p.StatusAtualPedido).IsRequired();
            builder.Property(p => p.CodigoStatusAtualPedido).IsRequired();
            builder.Property(p => p.DataHoraInclusao);
        }
    }
}