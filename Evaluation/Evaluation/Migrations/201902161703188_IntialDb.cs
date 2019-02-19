namespace Evaluation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "cao.cao_cliente",
                c => new
                    {
                        co_cliente = c.Long(nullable: false, identity: true, storeType: "uint"),
                        no_razao = c.String(maxLength: 50, unicode: false),
                        no_fantasia = c.String(maxLength: 50, unicode: false),
                        no_contato = c.String(maxLength: 30, unicode: false),
                        nu_telefone = c.String(maxLength: 15, unicode: false),
                        nu_ramal = c.String(maxLength: 6, unicode: false),
                        nu_cnpj = c.String(maxLength: 18, unicode: false),
                        ds_endereco = c.String(maxLength: 150, unicode: false),
                        nu_numero = c.Int(),
                        ds_complemento = c.String(maxLength: 150, unicode: false),
                        no_bairro = c.String(nullable: false, maxLength: 50, unicode: false),
                        nu_cep = c.String(maxLength: 10, unicode: false),
                        no_pais = c.String(maxLength: 50, unicode: false),
                        co_ramo = c.Long(),
                        co_cidade = c.Long(nullable: false),
                        co_status = c.Long(storeType: "uint"),
                        ds_site = c.String(maxLength: 50, unicode: false),
                        ds_email = c.String(maxLength: 50, unicode: false),
                        ds_cargo_contato = c.String(maxLength: 50, unicode: false),
                        tp_cliente = c.String(maxLength: 2, fixedLength: true, unicode: false, storeType: "char"),
                        ds_referencia = c.String(maxLength: 100, unicode: false),
                        co_complemento_status = c.Long(storeType: "uint"),
                        nu_fax = c.String(maxLength: 15, unicode: false),
                        ddd2 = c.String(maxLength: 10, unicode: false),
                        telefone2 = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.co_cliente);
            
            CreateTable(
                "cao.cao_fatura",
                c => new
                    {
                        co_fatura = c.Long(nullable: false, identity: true, storeType: "uint"),
                        co_cliente = c.Int(nullable: false),
                        co_sistema = c.Int(nullable: false),
                        co_os = c.Int(nullable: false),
                        num_nf = c.Int(nullable: false),
                        total = c.Single(nullable: false),
                        valor = c.Single(nullable: false),
                        data_emissao = c.DateTime(nullable: false, storeType: "date"),
                        corpo_nf = c.String(nullable: false, unicode: false, storeType: "text"),
                        comissao_cn = c.Single(nullable: false),
                        total_imp_inc = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.co_fatura);
            
            CreateTable(
                "cao.cao_os",
                c => new
                    {
                        co_os = c.Int(nullable: false, identity: true),
                        nu_os = c.Int(),
                        co_sistema = c.Int(),
                        co_usuario = c.String(maxLength: 50, unicode: false),
                        co_arquitetura = c.Int(),
                        ds_os = c.String(maxLength: 200, unicode: false),
                        ds_caracteristica = c.String(unicode: false, storeType: "text"),
                        ds_requisito = c.String(maxLength: 200, unicode: false),
                        dt_inicio = c.DateTime(storeType: "date"),
                        dt_fim = c.DateTime(storeType: "date"),
                        co_status = c.Int(),
                        diretoria_sol = c.String(maxLength: 50, unicode: false),
                        dt_sol = c.DateTime(storeType: "date"),
                        nu_tel_sol = c.String(maxLength: 20, unicode: false),
                        ddd_tel_sol = c.String(maxLength: 5, unicode: false),
                        nu_tel_sol2 = c.String(maxLength: 20, unicode: false),
                        ddd_tel_sol2 = c.String(maxLength: 5, unicode: false),
                        usuario_sol = c.String(maxLength: 50, unicode: false),
                        dt_imp = c.DateTime(storeType: "date"),
                        dt_garantia = c.DateTime(storeType: "date"),
                        co_email = c.Int(),
                        co_os_prospect_rel = c.Int(),
                    })
                .PrimaryKey(t => t.co_os);
            
            CreateTable(
                "cao.cao_salario",
                c => new
                    {
                        co_usuario = c.String(nullable: false, maxLength: 20, unicode: false),
                        dt_alteracao = c.DateTime(nullable: false, storeType: "date"),
                        brut_salario = c.Single(nullable: false),
                        liq_salario = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.co_usuario, t.dt_alteracao });
            
            CreateTable(
                "cao.cao_sistema",
                c => new
                    {
                        co_sistema = c.Int(nullable: false, identity: true),
                        co_cliente = c.Long(storeType: "uint"),
                        co_usuario = c.String(maxLength: 50, unicode: false),
                        co_arquitetura = c.Long(storeType: "uint"),
                        no_sistema = c.String(maxLength: 200, unicode: false),
                        ds_sistema_resumo = c.String(unicode: false, storeType: "text"),
                        ds_caracteristica = c.String(unicode: false, storeType: "text"),
                        ds_requisito = c.String(unicode: false, storeType: "text"),
                        no_diretoria_solic = c.String(maxLength: 100, unicode: false),
                        ddd_telefone_solic = c.String(maxLength: 5, unicode: false),
                        nu_telefone_solic = c.String(maxLength: 20, unicode: false),
                        no_usuario_solic = c.String(maxLength: 100, unicode: false),
                        dt_solicitacao = c.DateTime(storeType: "date"),
                        dt_entrega = c.DateTime(storeType: "date"),
                        co_email = c.Int(),
                    })
                .PrimaryKey(t => t.co_sistema);
            
            CreateTable(
                "cao.cao_usuario",
                c => new
                    {
                        co_usuario = c.String(nullable: false, maxLength: 20, unicode: false),
                        no_usuario = c.String(nullable: false, maxLength: 50, unicode: false),
                        ds_senha = c.String(nullable: false, maxLength: 14, unicode: false),
                        co_usuario_autorizacao = c.String(maxLength: 20, unicode: false),
                        nu_matricula = c.Decimal(storeType: "ubigint"),
                        dt_nascimento = c.DateTime(storeType: "date"),
                        dt_admissao_empresa = c.DateTime(storeType: "date"),
                        dt_desligamento = c.DateTime(storeType: "date"),
                        dt_inclusao = c.DateTime(precision: 0),
                        dt_expiracao = c.DateTime(storeType: "date"),
                        nu_cpf = c.String(maxLength: 14, unicode: false),
                        nu_rg = c.String(maxLength: 20, unicode: false),
                        no_orgao_emissor = c.String(maxLength: 10, unicode: false),
                        uf_orgao_emissor = c.String(maxLength: 2, unicode: false),
                        ds_endereco = c.String(maxLength: 150, unicode: false),
                        no_email = c.String(maxLength: 100, unicode: false),
                        no_email_pessoal = c.String(maxLength: 100, unicode: false),
                        nu_telefone = c.String(maxLength: 64, unicode: false),
                        dt_alteracao = c.DateTime(nullable: false, precision: 0),
                        url_foto = c.String(maxLength: 255, unicode: false),
                        instant_messenger = c.String(maxLength: 80, unicode: false),
                        icq = c.Long(storeType: "uint"),
                        msn = c.String(maxLength: 50, unicode: false),
                        yms = c.String(maxLength: 50, unicode: false),
                        ds_comp_end = c.String(maxLength: 50, unicode: false),
                        ds_bairro = c.String(maxLength: 30, unicode: false),
                        nu_cep = c.String(maxLength: 10, unicode: false),
                        no_cidade = c.String(maxLength: 50, unicode: false),
                        uf_cidade = c.String(maxLength: 2, unicode: false),
                        dt_expedicao = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.co_usuario);
            
            CreateTable(
                "cao.permissao_sistema",
                c => new
                    {
                        co_usuario = c.String(nullable: false, maxLength: 20, unicode: false),
                        co_tipo_usuario = c.Decimal(nullable: false, storeType: "ubigint"),
                        co_sistema = c.Decimal(nullable: false, storeType: "ubigint"),
                        in_ativo = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        co_usuario_atualizacao = c.String(maxLength: 20, unicode: false),
                        dt_atualizacao = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => new { t.co_usuario, t.co_tipo_usuario, t.co_sistema });
            
        }
        
        public override void Down()
        {
            DropTable("cao.permissao_sistema");
            DropTable("cao.cao_usuario");
            DropTable("cao.cao_sistema");
            DropTable("cao.cao_salario");
            DropTable("cao.cao_os");
            DropTable("cao.cao_fatura");
            DropTable("cao.cao_cliente");
        }
    }
}
