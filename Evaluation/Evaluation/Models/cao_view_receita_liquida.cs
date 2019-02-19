using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Evaluation
{
    [Table("cao_view_receita_liquida")]
    public partial class cao_view_receita_liquida
    {
        public int mes_data_emissao { get; set; }
        public int anno_data_emissao { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string co_usuario { get; set; }

        [StringLength(50)]
        public string no_usuario { get; set; }
        [StringLength(20)]
        public string datename { get; set; }
        public float valorliquido { get; set; }
        public float comision { get; set; }
        public float salario { get; set; }
        public float lucro { get; set; }
        
    }
}