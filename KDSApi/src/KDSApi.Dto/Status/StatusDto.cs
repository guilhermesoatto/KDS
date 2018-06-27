using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tnf.Dto;

namespace KDSApi.Dto.Status
{
    public class StatusDto : BaseDto
    {
        [Key]
        public int IdStatus { get; set; }

        [StringLength(50)]
        public string Descricao { get; set; }
    }
}
