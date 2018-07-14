using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KDS.Api.Models
{
    public class Status
    {
        [Key]
        public long idStatus { get; set; }

        [StringLength(50)]
        public string descricao { get; set; }
    }
}
