using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tnf.Dto;

namespace KDSApi.Dto.Item
{
    public class ItemInsumoDto
    {
        [Key]
        public int IdInsumo { get; set; }
        public int IdItem { get; set; }

        [StringLength(50)]
        public string ObjectId { get; set; }

        [StringLength(250)]
        public string Descricao { get; set; }
        public int Remover { get; set; }
        public int Quantidade { get; set; }
    }
}
