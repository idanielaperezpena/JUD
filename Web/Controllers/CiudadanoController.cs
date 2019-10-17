using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Permiso(Disabled = true)]
    public class CiudadanoController : Controller
    {
        // GET: Ciudadano
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Insertar()
        {
            return View();
        }
    }
}