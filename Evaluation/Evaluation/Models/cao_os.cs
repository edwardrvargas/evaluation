namespace Evaluation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cao.cao_os")]
    public partial class cao_os
    {
        [Key]
        public int co_os { get; set; }

        public int? nu_os { get; set; }

        public int? co_sistema { get; set; }

        [StringLength(50)]
        public string co_usuario { get; set; }

        public int? co_arquitetura { get; set; }

        [StringLength(200)]
        public string ds_os { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string ds_caracteristica { get; set; }

        [StringLength(200)]
        public string ds_requisito { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dt_inicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dt_fim { get; set; }

        public int? co_status { get; set; }

        [StringLength(50)]
        public string diretoria_sol { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dt_sol { get; set; }

        [StringLength(20)]
        public string nu_tel_sol { get; set; }

        [StringLength(5)]
        public string ddd_tel_sol { get; set; }

        [StringLength(20)]
        public string nu_tel_sol2 { get; set; }

        [StringLength(5)]
        public string ddd_tel_sol2 { get; set; }

        [StringLength(50)]
        public string usuario_sol { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dt_imp { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dt_garantia { get; set; }

        public int? co_email { get; set; }

        public int? co_os_prospect_rel { get; set; }
    }
}
