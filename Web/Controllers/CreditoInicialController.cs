using Entidades;
using Negocio;
using Negocio.ViewModels;
using Negocio.ViewModels.Catalogos;
using Negocio.ViewModels.Ciudadanos;
using Negocio.ViewModels.CreditoInicial;
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

        //Acciones

        [HttpPost]
        public ActionResult Insertar(CreditoInicialInsertarViewModel viewModel)
        {
            _service.EditarCreditoInicial(viewModel);
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
            ViewBag.Adicional = " En donde se pretende aplicar el credito";
            return PartialView("../Domicilio/_Insertar", _service.GetDomicilioViewModel());
        }

        [HttpPost]
        public ActionResult GetCiudadanoInsertar(string ID = null)
        {
            return PartialView("../Ciudadano/_InsertarPrueba", _service.CiudadanoInsertar(ID));
        }

        [HttpPost]
        public ActionResult GetDeudorSolidarioViewModel()
        {
            return PartialView("../DeudorSolidario/_Insertar", _service.GetDeudorSolidario());
        }

    }
}