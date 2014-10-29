using ITS.Dichiarativi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITS.Dichiarativi.Portal.Controllers
{
    public class DichiarativiController : Controller
    {
        private IDichiarativiQueries _dichiarativiQueries;


        public DichiarativiController(IDichiarativiQueries dichiarativiQueries)
        {
            _dichiarativiQueries = dichiarativiQueries;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Data()
        {
            var data = _dichiarativiQueries.GetAll();

            return Json(data.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}