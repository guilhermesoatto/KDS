using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tnf.Dto;

namespace KDSApi.Dto.Item
{
    public class ItemAdicionalDto : BaseDto
    {
        [Key]
        public int IdAdicional { get; set; }
        public int IdItem { get; set; }
        [StringLength(150)]
        public string Descricao { get; set; }
    }
}
