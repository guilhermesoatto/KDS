using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KDSWebApiMVC.Models
{
    [Table("dbo.pedido")]
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