using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tnf.Dto;

namespace KDSApi.Dto.Comanda
{
    public class ComandaDto : BaseDto
    {
        [Key]
        public int IdComanda { get; set; }
        [StringLength(50)]
        public string NumeroComanda { get; set; }
    }
}
