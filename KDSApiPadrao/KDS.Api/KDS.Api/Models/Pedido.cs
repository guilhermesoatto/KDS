using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KDS.Api.Models
{
    public class Pedido
    {
        //public Pedido()
        //{
        //    this.itensDoPedido = new HashSet<Item>();
        //}


        [Key]
        [Column(Order = 1)]
        public long idPedido { get; set; }

        //[ForeignKey("idComanda")]
        //[Column(Order = 1)]
        public int idComanda { get; set; }

        [StringLength(50)]
        public string canalAtendimento { get; set; }

        public int codigoPedido { get; set; }

        [StringLength(50)]
        public string statusAtualPedido { get; set; }

        public int codigoStatusAtualPedido { get; set; }

        //[NotMapped]
        [DisplayFormat(DataFormatString = "{0:s}")]
        public DateTime dataHoraInclusao { get; set; }

        public virtual ICollection<Item> itensDoPedido { get; set; }
    }
}
