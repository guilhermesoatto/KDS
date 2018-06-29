using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KDSWebApiMVC.Models
{
    [Table("dbo.item")]
    public class Item
    {
        [Key]
        public int IdItem { get; set; }
        public int IdPedido { get; set; }

        [StringLength(50)]
        public string ObjectId { get; set; }

        [StringLength(50)]
        public string StatusAtualItem { get; set; }
        public int CodigoStatusAtualItem { get; set; }

        [StringLength(150)]
        public string Descricao { get; set; }

        [StringLength(150)]
        public string Observacao { get; set; }
        public DateTime DataHoraInclusao { get; set; }
        public int TempoMedioPreparacaoEmMinutos { get; set; }
    }
}