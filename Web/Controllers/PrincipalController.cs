using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Permiso(Disabled = true)]
    public class PrincipalController : BaseController
    {
        private PrincipalService _service;

        public PrincipalController()
        {
            _service = new PrincipalService(ModelState);
        }

        // GET: Principal
        public ActionResult Index()
        {
            ViewBag.Titulo = "Menú Principal";
            var vm= _service.ObtenerPrincipal();
            return View(vm);
        }

    }
}