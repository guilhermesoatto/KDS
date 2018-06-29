using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KDSWebApiMVC.Models
{
    [Table("dbo.Status")]
    public class Status
    {
        [Key]
        public int IdStatus { get; set; }

        [StringLength(50)]
        public string Descricao { get; set; }
    }
}