using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evaluation.Models.EF;

namespace Evaluation.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        public JsonResult Index()
        {
            var cities = new List<City>()
            {
                new City() {Id = 1, Name = "Barquisimeto"},
                new City() {Id = 2, Name = "Valencia"},
                new City() {Id = 3, Name = "Caracas"}
            };
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
    }
}