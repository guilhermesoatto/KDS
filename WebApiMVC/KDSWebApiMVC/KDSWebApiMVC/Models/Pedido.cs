using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KDSWebApiMVC.Models
{
    [Table("dbo.Pedido")]
    public class Pedido
    {
        [Key]
        public int idPedido { get; set; }

        public int idComanda { get; set; }

        [StringLength(50)]
        public string canalAtendimento { get; set; }

        public int codigoPedido { get; set; }

        [StringLength(50)]
        public string statusAtualPedido { get; set; }

        public int codigoStatusAtualPedido { get; set; }

        [NotMapped]
        public DateTime dataHoraInclusao { get; set; }

        public List<Item> itensDoPedido { get; set; }

    }
}