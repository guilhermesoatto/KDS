using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KDSWebApiMVC.Models
{
    public class ItemAdicional
    {
        [Key]
        public int IdAdicional { get; set; }
        public int IdItem { get; set; }
        [StringLength(150)]
        public string Descricao { get; set; }
    }
}