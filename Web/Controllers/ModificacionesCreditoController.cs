using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ModificacionesCreditoController : Controller
    {
        // GET: ModificacionesCredito
        public ActionResult Index()
        {
            return View();
        }
        // GET: ModificacionesCredito/insertar
        public ActionResult Insertar()
        {
            return View();
        }
    }
}