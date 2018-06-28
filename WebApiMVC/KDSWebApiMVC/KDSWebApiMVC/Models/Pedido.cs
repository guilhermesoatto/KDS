using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KDSWebApiMVC.Models
{
    public class Pedido
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