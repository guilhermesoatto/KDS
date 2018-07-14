using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KDS.Api.Models
{
    public class Historico
    {
        [Key]
        public long idHistorico { get; set; }
        public int id { get; set; }
        public int idStatus { get; set; }
        [StringLength(50)]
        public string tipo { get; set; }
        public DateTime dataHora { get; set; }
    }
}
