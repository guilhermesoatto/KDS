using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KDSWebApiMVC.Models
{
    [Table("dbo.Comanda")]
    public class Comanda
    {
        [Key]
        public int IdComanda { get; set; }
        [StringLength(50)]
        public string NumeroComanda { get; set; }

        public List<Pedido> Pedidos { get; set; }

        [NotMapped]
        public bool success { get; set; }
    }
}