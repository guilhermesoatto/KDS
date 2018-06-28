using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KDSWebApiMVC.Models
{
    public class Historico
    {
        [Key]
        public int IdHistorico { get; set; }
        public int Id { get; set; }
        public int IdStatus { get; set; }
        [StringLength(50)]
        public string Tipo { get; set; }
        public DateTime DataHora { get; set; }
    }
}