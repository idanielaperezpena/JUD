using Entidades;
using Negocio;
using Negocio.ViewModels;
using Negocio.ViewModels.Catalogos;
using Negocio.ViewModels.Ciudadanos;
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

        //public ActionResult Nuevo()
        //{
        //    var _vm = _service.Nuevo();
        //    ViewBag.Titulo = "Credito Inicial";
        //    return View(_vm);
        //}
        
        //Acciones
        [HttpPost]
        public ActionResult Insertar(CiudadanoInsertarViewModel viewModel)
        {
            return Json(viewModel.ToJSON());
        }

        //Get partial Views
        [HttpPost]
        public ActionResult GetParejaViewModel()
        {
            return PartialView("../Pareja/_Insertar", _service.GetParejaViewModel());
        }

        [HttpPost]
        public ActionResult GetDomicilioViewModel()
        {
            return PartialView("../Domicilio/_Insertar", _service.GetDomicilioViewModel());
        }

    }
}