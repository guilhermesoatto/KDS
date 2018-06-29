using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KDSWebApiMVC.Models
{
    [Table("dbo.Item")]
    public class Item
    {
        [Key]
        public int idItem { get; set; }
        public int idPedido { get; set; }

        [StringLength(50)]
        public string objectId { get; set; }

        [StringLength(50)]
        public string statusAtualItem { get; set; }
        public int codigoStatusAtualItem { get; set; }

        [StringLength(150)]
        public string descricao { get; set; }

        [StringLength(150)]
        public string observacao { get; set; }
        [NotMapped]
        public DateTime dataHoraInclusao { get; set; }
        public int tempoMedioPreparacaoEmMinutos { get; set; }

        public List<ItemAdicional> adicionaisItem { get; set; }
        public List<ItemInsumo> insumoItem { get; set; }
    }
}
