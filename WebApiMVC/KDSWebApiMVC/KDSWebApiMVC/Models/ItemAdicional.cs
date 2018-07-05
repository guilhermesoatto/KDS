using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KDSWebApiMVC.Models
{
    [Table("dbo.ItemAdicional")]
    public class ItemAdicional
    {
        [Key]
        [Column(Order = 1)]
        public int idAdicional { get; set; }

        //[ForeignKey("Item")]
        //[Column(Order = 1)]
        public int idItem { get; set; }

        [StringLength(150)]
        public string descricao { get; set; }
    }
}