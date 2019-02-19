namespace Evaluation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cao.cao_salario")]
    public partial class cao_salario
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string co_usuario { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime dt_alteracao { get; set; }

        public float brut_salario { get; set; }

        public float liq_salario { get; set; }
    }
}
