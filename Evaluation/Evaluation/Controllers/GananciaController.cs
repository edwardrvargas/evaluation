using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Evaluation.Models;
using Evaluation.Models.ViewModel;
using Newtonsoft.Json.Linq;

namespace Evaluation.Controllers
{
    public class viewData
    {
        public IOrderedEnumerable<cao_view_receita_liquida> details { get; set; }
        public List<viewModelReceita> totales { get; set; }
    }

    public class GananciaController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get([FromUri] string consultors, [FromUri] string beganno, [FromUri] string endanno, [FromUri] string begmonth, [FromUri] string endmonth)
        {
            var inClausule = consultors.Split(';');
            caoContext db = new caoContext();
            var ganancias = db.Database.SqlQuery<cao_view_receita_liquida>("SELECT * FROM cao_view_receita_liquida").Where(x=>inClausule.Contains(x.co_usuario) && x.anno_data_emissao >=  Convert.ToInt16(beganno) && x.anno_data_emissao <= Convert.ToInt16(endanno) && x.mes_data_emissao >= Convert.ToInt16(begmonth) && x.mes_data_emissao <= Convert.ToInt16(endmonth)).ToList().OrderBy(e => e.no_usuario);
            List<viewModelReceita> totales = ganancias.GroupBy(u => u.no_usuario).Select(cl => new viewModelReceita()
            {
                consultor = cl.First().no_usuario,
                totalreceitaliquida = cl.Sum(c => c.valorliquido),
                totalcomision = cl.Sum(c => c.comision),
                totalcostofijo = cl.Sum(c => c.salario),
                totallucro = cl.Sum(c => c.lucro),
                details = ganancias.Where(e=>e.no_usuario == cl.First().no_usuario).ToList()
            }).ToList();
            return Ok(totales);
        }
    }


}