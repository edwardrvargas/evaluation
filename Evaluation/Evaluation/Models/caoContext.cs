namespace Evaluation
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class caoContext : DbContext
    {
        public caoContext()
            : base("name=caoContext")
        {
        }

        public virtual DbSet<cao_cliente> cao_cliente { get; set; }
        public virtual DbSet<cao_fatura> cao_fatura { get; set; }
        public virtual DbSet<cao_os> cao_os { get; set; }
        public virtual DbSet<cao_salario> cao_salario { get; set; }
        public virtual DbSet<cao_sistema> cao_sistema { get; set; }
        public virtual DbSet<cao_usuario> cao_usuario { get; set; }
        public virtual DbSet<permissao_sistema> permissao_sistema { get; set; }
        public virtual DbSet<cao_view_receita_liquida> cao_view_receita_liquida { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.no_razao)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.no_fantasia)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.no_contato)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.nu_telefone)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.nu_ramal)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.nu_cnpj)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.ds_endereco)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.ds_complemento)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.no_bairro)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.nu_cep)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.no_pais)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.ds_site)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.ds_email)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.ds_cargo_contato)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.tp_cliente)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.ds_referencia)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.nu_fax)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.ddd2)
                .IsUnicode(false);

            modelBuilder.Entity<cao_cliente>()
                .Property(e => e.telefone2)
                .IsUnicode(false);

            modelBuilder.Entity<cao_fatura>()
                .Property(e => e.corpo_nf)
                .IsUnicode(false);

            modelBuilder.Entity<cao_os>()
                .Property(e => e.co_usuario)
                .IsUnicode(false);

            modelBuilder.Entity<cao_os>()
                .Property(e => e.ds_os)
                .IsUnicode(false);

            modelBuilder.Entity<cao_os>()
                .Property(e => e.ds_caracteristica)
                .IsUnicode(false);

            modelBuilder.Entity<cao_os>()
                .Property(e => e.ds_requisito)
                .IsUnicode(false);

            modelBuilder.Entity<cao_os>()
                .Property(e => e.diretoria_sol)
                .IsUnicode(false);

            modelBuilder.Entity<cao_os>()
                .Property(e => e.nu_tel_sol)
                .IsUnicode(false);

            modelBuilder.Entity<cao_os>()
                .Property(e => e.ddd_tel_sol)
                .IsUnicode(false);

            modelBuilder.Entity<cao_os>()
                .Property(e => e.nu_tel_sol2)
                .IsUnicode(false);

            modelBuilder.Entity<cao_os>()
                .Property(e => e.ddd_tel_sol2)
                .IsUnicode(false);

            modelBuilder.Entity<cao_os>()
                .Property(e => e.usuario_sol)
                .IsUnicode(false);

            modelBuilder.Entity<cao_salario>()
                .Property(e => e.co_usuario)
                .IsUnicode(false);

            modelBuilder.Entity<cao_sistema>()
                .Property(e => e.co_usuario)
                .IsUnicode(false);

            modelBuilder.Entity<cao_sistema>()
                .Property(e => e.no_sistema)
                .IsUnicode(false);

            modelBuilder.Entity<cao_sistema>()
                .Property(e => e.ds_sistema_resumo)
                .IsUnicode(false);

            modelBuilder.Entity<cao_sistema>()
                .Property(e => e.ds_caracteristica)
                .IsUnicode(false);

            modelBuilder.Entity<cao_sistema>()
                .Property(e => e.ds_requisito)
                .IsUnicode(false);

            modelBuilder.Entity<cao_sistema>()
                .Property(e => e.no_diretoria_solic)
                .IsUnicode(false);

            modelBuilder.Entity<cao_sistema>()
                .Property(e => e.ddd_telefone_solic)
                .IsUnicode(false);

            modelBuilder.Entity<cao_sistema>()
                .Property(e => e.nu_telefone_solic)
                .IsUnicode(false);

            modelBuilder.Entity<cao_sistema>()
                .Property(e => e.no_usuario_solic)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.co_usuario)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.no_usuario)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.ds_senha)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.co_usuario_autorizacao)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.nu_cpf)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.nu_rg)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.no_orgao_emissor)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.uf_orgao_emissor)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.ds_endereco)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.no_email)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.no_email_pessoal)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.nu_telefone)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.url_foto)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.instant_messenger)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.msn)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.yms)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.ds_comp_end)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.ds_bairro)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.nu_cep)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.no_cidade)
                .IsUnicode(false);

            modelBuilder.Entity<cao_usuario>()
                .Property(e => e.uf_cidade)
                .IsUnicode(false);

            modelBuilder.Entity<permissao_sistema>()
                .Property(e => e.co_usuario)
                .IsUnicode(false);

            modelBuilder.Entity<permissao_sistema>()
                .Property(e => e.in_ativo)
                .IsUnicode(false);

            modelBuilder.Entity<permissao_sistema>()
                .Property(e => e.co_usuario_atualizacao)
                .IsUnicode(false);

            modelBuilder.Entity<cao_view_receita_liquida>()
                .Property(e => e.co_usuario)
                .IsUnicode(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
