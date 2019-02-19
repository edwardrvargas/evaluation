namespace Evaluation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cao.cao_usuario")]
    public partial class cao_usuario
    {
        [Key]
        [StringLength(20)]
        public string co_usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string no_usuario { get; set; }

        [Required]
        [StringLength(14)]
        public string ds_senha { get; set; }

        [StringLength(20)]
        public string co_usuario_autorizacao { get; set; }

        [Column(TypeName = "ubigint")]
        public decimal? nu_matricula { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dt_nascimento { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dt_admissao_empresa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dt_desligamento { get; set; }

        public DateTime? dt_inclusao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dt_expiracao { get; set; }

        [StringLength(14)]
        public string nu_cpf { get; set; }

        [StringLength(20)]
        public string nu_rg { get; set; }

        [StringLength(10)]
        public string no_orgao_emissor { get; set; }

        [StringLength(2)]
        public string uf_orgao_emissor { get; set; }

        [StringLength(150)]
        public string ds_endereco { get; set; }

        [StringLength(100)]
        public string no_email { get; set; }

        [StringLength(100)]
        public string no_email_pessoal { get; set; }

        [StringLength(64)]
        public string nu_telefone { get; set; }

        public DateTime dt_alteracao { get; set; }

        [StringLength(255)]
        public string url_foto { get; set; }

        [StringLength(80)]
        public string instant_messenger { get; set; }

        [Column(TypeName = "uint")]
        public long? icq { get; set; }

        [StringLength(50)]
        public string msn { get; set; }

        [StringLength(50)]
        public string yms { get; set; }

        [StringLength(50)]
        public string ds_comp_end { get; set; }

        [StringLength(30)]
        public string ds_bairro { get; set; }

        [StringLength(10)]
        public string nu_cep { get; set; }

        [StringLength(50)]
        public string no_cidade { get; set; }

        [StringLength(2)]
        public string uf_cidade { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dt_expedicao { get; set; }
    }
}
