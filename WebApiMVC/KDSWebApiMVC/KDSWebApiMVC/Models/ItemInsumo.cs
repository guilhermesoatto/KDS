using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KDSWebApiMVC.Models
{
    [Table("dbo.ItemInsumo")]
    public class ItemInsumo
    {
        [Key]
        public int IdInsumo { get; set; }
        public int IdItem { get; set; }

        [StringLength(50)]
        public string ObjectId { get; set; }

        [StringLength(250)]
        public string Descricao { get; set; }
        public int Remover { get; set; }
        public int Quantidade { get; set; }
    }
}