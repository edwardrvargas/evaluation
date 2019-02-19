using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluation.Models.ViewModel
{
    public class viewModelReceita
    {
        public string consultor {get;set;}
        public int mes { get; set; }
        public int anno { get; set; }
        public float totalreceitaliquida { get; set; }
        public float totalcostofijo { get; set; }
        public float totalcomision { get; set; }
        public float totallucro { get; set; }

        public List<cao_view_receita_liquida> details { get; set; }
    }
}