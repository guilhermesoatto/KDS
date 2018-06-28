using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KDSWebApiMVC.Models
{
    public class Status
    {
        [Key]
        public int IdStatus { get; set; }

        [StringLength(50)]
        public string Descricao { get; set; }
    }
}