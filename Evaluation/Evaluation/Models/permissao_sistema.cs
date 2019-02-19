namespace Evaluation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cao.permissao_sistema")]
    public partial class permissao_sistema
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string co_usuario { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "ubigint")]
        public decimal co_tipo_usuario { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "ubigint")]
        public decimal co_sistema { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(1)]
        public string in_ativo { get; set; }

        [StringLength(20)]
        public string co_usuario_atualizacao { get; set; }

        public DateTime dt_atualizacao { get; set; }
    }
}
