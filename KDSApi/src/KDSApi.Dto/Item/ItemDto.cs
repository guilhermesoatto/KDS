using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tnf.Dto;

namespace KDSApi.Dto.Item
{
    public class ItemDto : BaseDto
    {
        [Key]
        public int IdItem { get; set; }
        public int IdPedido { get; set; }

        [StringLength(50)]
        public string ObjectId { get; set; }

        [StringLength(50)]
        public string StatusAtualItem { get; set; }
        public int CodigoStatusAtualItem { get; set; }

        [StringLength(150)]
        public string Descricao { get; set; }

        [StringLength(150)]
        public string Observacao { get; set; }
        public DateTime DataHoraInclusao { get; set; }
        public int TempoMedioPreparacaoEmMinutos { get; set; }
    }
}
