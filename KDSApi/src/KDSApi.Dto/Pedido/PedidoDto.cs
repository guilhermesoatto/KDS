using KDSApi.Dto.Comanda;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tnf.Dto;

namespace KDSApi.Dto.Pedido
{
    public class PedidoDto : BaseDto
    {
        [Key]
        public int IdPedido { get; set; }

        public int IdComanda { get; set; }

        [StringLength(50)]
        public string CanalAtendimento { get; set; }

        public int CodigoPedido { get; set; }

        [StringLength(50)]
        public string StatusAtualPedido { get; set; }

        public int CodigoStatusAtualPedido { get; set; }
        public DateTime DataHoraInclusao { get; set; }

    }
}
