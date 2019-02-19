namespace Evaluation.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Evaluation.caoContext>
    {
        public Configuration()
        {
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(Evaluation.caoContext context)
        {
            string createView = @"SELECT DATA.co_usuario, cu.no_usuario,
                                    CONCAT(MONTHNAME(DATA.data_emissao), ' of ', CAST(YEAR(DATA.data_emissao) AS CHAR(4))) AS datename,
                                    SUM(DATA.valor_liquido) AS valorliquido, SUM(DATA.comision) AS comision, MAX(cs.brut_salario) AS salario,
                                    SUM(DATA.valor_liquido) -(MAX(cs.brut_salario) + SUM(DATA.comision)) AS lucro
                                    FROM
                                    (
                                        SELECT
                                            cao_usuario.co_usuario,
                                            cao_fatura.data_emissao,
                                            cao_fatura.valor,
                                            cao_fatura.total_imp_inc,
                                            (cao_fatura.valor * cao_fatura.total_imp_inc / 100) AS impuesto,
                                                cao_fatura.valor - (cao_fatura.valor * cao_fatura.total_imp_inc / 100) AS valor_liquido,
                                            (cao_fatura.valor - (cao_fatura.valor * cao_fatura.total_imp_inc / 100)) * cao_fatura.comissao_cn / 100 AS comision
                                            FROM cao_usuario
                                            INNER JOIN cao_os
                                                ON cao_usuario.co_usuario = cao_os.co_usuario
                                            INNER JOIN cao_fatura
                                                ON cao_os.co_os = cao_fatura.co_os
                                            INNER JOIN cao_salario ON cao_usuario.co_usuario = cao_salario.co_usuario
                                    ) DATA INNER JOIN cao_usuario cu ON cu.co_usuario = DATA.co_usuario
                                    INNER JOIN cao_salario cs ON cs.co_usuario = cu.co_usuario
                                    GROUP BY DATA.co_usuario";
            string dropView = "DROP VIEW IF EXISTS cao_view_receita_liquida;"; 
            context.Database.ExecuteSqlCommand(dropView);
            context.Database.ExecuteSqlCommand(createView);
        }
    }
}
