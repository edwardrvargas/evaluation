using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Evaluation.Models;


namespace Evaluation.Controllers
{
    public class ConsultorController : ApiController
    {
        public IHttpActionResult GetAllConsultors()
        {
            caoContext db = new caoContext();
            var consultors = db.cao_usuario.Join(db.permissao_sistema,
                p => p.co_usuario,
                u => u.co_usuario,
                (usuario, permiso_sistema) => new
                {
                    IdUsuario = usuario.co_usuario,
                    Name = usuario.no_usuario,
                    System = permiso_sistema.co_sistema,
                    Active = permiso_sistema.in_ativo,
                    UserType = permiso_sistema.co_tipo_usuario,
                    Selected = false
                }).Where(c => c.System == 1 && c.Active == "S" && c.UserType >= 0 && c.UserType <= 2);
                                        
                return Ok(consultors);
        }
    }   
}
