using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KDS.Api.Models
{
    [Table("Comanda")]
    public class Comanda
    {
        //public Comanda()
        //{
        //    this.pedidos = new HashSet<Pedido>();
        //}

        //public Comanda()
        //{
        //    pedidos = new HashSet<Pedido>();
        //}

        [Key]
        [Column(Order = 1)]
        public long idComanda { get; set; }

        [StringLength(50)]
        public string numeroComanda { get; set; }

        [DisplayFormat(DataFormatString = "{0:s}")]
        public DateTime dataHoraInclusao { get; set; }

        public ICollection<Pedido> pedidos { get; set; }

        [NotMapped]
        public bool success { get; set; }
    }
}
