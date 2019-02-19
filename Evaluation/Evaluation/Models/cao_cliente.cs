namespace Evaluation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cao.cao_cliente")]
    public partial class cao_cliente
    {
        [Key]
        [Column(TypeName = "uint")]
        public long co_cliente { get; set; }

        [StringLength(50)]
        public string no_razao { get; set; }

        [StringLength(50)]
        public string no_fantasia { get; set; }

        [StringLength(30)]
        public string no_contato { get; set; }

        [StringLength(15)]
        public string nu_telefone { get; set; }

        [StringLength(6)]
        public string nu_ramal { get; set; }

        [StringLength(18)]
        public string nu_cnpj { get; set; }

        [StringLength(150)]
        public string ds_endereco { get; set; }

        public int? nu_numero { get; set; }

        [StringLength(150)]
        public string ds_complemento { get; set; }

        [Required]
        [StringLength(50)]
        public string no_bairro { get; set; }

        [StringLength(10)]
        public string nu_cep { get; set; }

        [StringLength(50)]
        public string no_pais { get; set; }

        public long? co_ramo { get; set; }

        public long co_cidade { get; set; }

        [Column(TypeName = "uint")]
        public long? co_status { get; set; }

        [StringLength(50)]
        public string ds_site { get; set; }

        [StringLength(50)]
        public string ds_email { get; set; }

        [StringLength(50)]
        public string ds_cargo_contato { get; set; }

        [Column(TypeName = "char")]
        [StringLength(2)]
        public string tp_cliente { get; set; }

        [StringLength(100)]
        public string ds_referencia { get; set; }

        [Column(TypeName = "uint")]
        public long? co_complemento_status { get; set; }

        [StringLength(15)]
        public string nu_fax { get; set; }

        [StringLength(10)]
        public string ddd2 { get; set; }

        [StringLength(20)]
        public string telefone2 { get; set; }
    }
}
