using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KDSWebApiMVC.Models
{
    [Table("dbo.Comanda")]
    public class Comanda
    {
        [Key]
        public int idComanda { get; set; }
        [StringLength(50)]
        public string numeroComanda { get; set; }
        [NotMapped]
        public DateTime dataHoraInclusao { get; set; }

        public List<Pedido> pedidos { get; set; }

        [NotMapped]
        public bool success { get; set; }
    }


}