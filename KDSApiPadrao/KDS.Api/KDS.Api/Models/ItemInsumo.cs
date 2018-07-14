﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KDS.Api.Models
{
    public class ItemInsumo
    {
        [Key]
        [Column(Order = 1)]
        public long idInsumo { get; set; }

        //[ForeignKey("Item")]
        //[Column(Order = 1)]
        public int idItem { get; set; }

        [StringLength(50)]
        public string objectId { get; set; }

        [StringLength(250)]
        public string descricao { get; set; }
        public int remover { get; set; }
        public int quantidade { get; set; }
    }
}