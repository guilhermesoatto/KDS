using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tnf.Dto;

namespace KDSApi.Dto.Historico
{
    public class HistoricoDto : BaseDto
    {
        [Key]
        public int IdHistorico { get; set; }
        public int Id { get; set; }
        public int IdStatus { get; set; }
        [StringLength(50)]
        public string Tipo { get; set; }
        public DateTime DataHora { get; set; }
    }
}
