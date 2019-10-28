using Entidades;
using Negocio;
using Negocio.ViewModels;
using Negocio.ViewModels.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.INVI;

namespace Web.Controllers
{
    [Permiso(Disabled = true)]
    public class CreditoInicialController : Controller
    {
        private CreditoInicialService _service;

        public CreditoInicialController()
        {
            _service = new CreditoInicialService(ModelState);
        }

        // GET: CreditoInicial
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Nuevo()
        {
            var _vm = _service.Nuevo();
            ViewBag.Titulo = "Credito Inicial";
            return View(_vm);
        }
    }
}