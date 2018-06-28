using System;
using System.Collections.Generic;
using System.Text;

namespace KDSApi.Domain.Entities
{
    public partial class Pedido : IEntity
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int IdPedido { get; set; }

        public int IdComanda { get; set; }

        public string CanalAtendimento { get; set; }

        public int CodigoPedido { get; set; }

        public string StatusAtualPedido { get; set; }

        public int CodigoStatusAtualPedido { get; set; }

        public DateTime DataHoraInclusao { get; set; }

    }
}
 