namespace Evaluation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cao.cao_sistema")]
    public partial class cao_sistema
    {
        [Key]
        public int co_sistema { get; set; }

        [Column(TypeName = "uint")]
        public long? co_cliente { get; set; }

        [StringLength(50)]
        public string co_usuario { get; set; }

        [Column(TypeName = "uint")]
        public long? co_arquitetura { get; set; }

        [StringLength(200)]
        public string no_sistema { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string ds_sistema_resumo { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string ds_caracteristica { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string ds_requisito { get; set; }

        [StringLength(100)]
        public string no_diretoria_solic { get; set; }

        [StringLength(5)]
        public string ddd_telefone_solic { get; set; }

        [StringLength(20)]
        public string nu_telefone_solic { get; set; }

        [StringLength(100)]
        public string no_usuario_solic { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dt_solicitacao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dt_entrega { get; set; }

        public int? co_email { get; set; }
    }
}
