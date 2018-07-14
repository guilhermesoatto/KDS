using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KDS.Api.Models
{
    public class ItemAdicional
    {
        [Key]
        [Column(Order = 1)]
        public long idAdicional { get; set; }

        //[ForeignKey("Item")]
        //[Column(Order = 1)]
        public int idItem { get; set; }

        [StringLength(150)]
        public string descricao { get; set; }
    }
}
