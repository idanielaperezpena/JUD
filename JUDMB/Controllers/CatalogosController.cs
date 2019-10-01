using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JUDMB.Controllers
{
    public class CatalogosController : Controller
    {
        // GET: Catalogos
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Principal");
        }

        [ActionName("Mostrar")]
        public ActionResult Mostrar()
        {
            return View();
        }



    }
}