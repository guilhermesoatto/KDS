using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KDSWebApiMVC.Models
{
    [Table("Comanda")]
    public class Comanda
    {
        [Key]
        public int IdComanda { get; set; }
        [StringLength(50)]
        public string NumeroComanda { get; set; }
    }
}