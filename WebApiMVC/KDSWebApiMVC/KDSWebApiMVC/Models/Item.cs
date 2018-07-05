using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace KDSWebApiMVC.Models
{
    [Table("dbo.Item")]
    public class Item
    {

        //public Item()
        //{
        //    this.adicionaisItem = new HashSet<ItemAdicional>();
        //    this.insumoItem = new HashSet<ItemInsumo>();
        //}


        [Key]
        [Column(Order = 1)]
        public int idItem { get; set; }

        //[ForeignKey("Pedido")]
        //[Column(Order = 1)]
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

        [DisplayFormat(DataFormatString = "{0:s}")]
        public DateTime dataHoraInclusao { get; set; }

        public int tempoMedioPreparacaoEmMinutos { get; set; }

        public ICollection<ItemAdicional> adicionaisItem { get; set; }
        public ICollection<ItemInsumo> insumoItem { get; set; }
    }
}
