using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Permiso(Disabled = true)]
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Index()
        {
            ViewBag.Titulo = "Menu Principal";
            return View();
        }

    }
}