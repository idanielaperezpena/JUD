using Entidades;
using Negocio;
using Negocio.ViewModels;
using Negocio.ViewModels.Catalogos;
using Negocio.ViewModels.Ciudadanos;
using Negocio.ViewModels.CreditoInicial;
using Negocio.ViewModels.Domicilio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.INVI;

namespace Web.Controllers
{
    [Permiso(Disabled = true)]
    public class CreditoInicialController : BaseController
    {
        private CreditoInicialService _service;

        public CreditoInicialController()
        {
            _service = new CreditoInicialService(ModelState);
        }

        public ActionResult Index(Notificacion notificacion = null)
        {
            if (notificacion != null)
            {
                ViewBag.Error = notificacion.Error;
                ViewBag.MensajeError = notificacion.Mensaje;
            }
            else
            {
                ViewBag.Error = false;
            }
            var _vm = _service.Index(Usuario);
            ViewBag.Titulo = "Lista de Créditos Iniciales";
            return View(_vm);
        }


        public ActionResult Insertar(String ID )
        {
            var _vm = new CreditoInicialInsertarViewModel();
            if (String.IsNullOrEmpty(ID))
                _vm = _service.Insertar();
            else
                _vm = _service.Insertar(ID);
            ViewBag.Titulo = "Crédito Inicial";
            return View(_vm);
        }

        //Acciones

        [HttpPost]
        public ActionResult Insertar(CreditoInicialInsertarViewModel viewModel)
        {
            _service.EditarCreditoInicial(viewModel);

            var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
            var notificacion = new Notificacion{ Error = false, Mensaje = "" };
            if (errors.Count > 0)
            {
                notificacion.Error = true;
                foreach (var item in errors)
                {
                    foreach (var item2 in item)
                    {
                        notificacion.Mensaje+= item2.ErrorMessage + "<br>";
                    }
                }
                
            }
            
            return Json(notificacion);
        }

        //Get partial Views
        [HttpPost]
        public ActionResult GetParejaViewModel()
        {
            return PartialView("../Pareja/_Insertar", _service.GetParejaViewModel());
        }

        [HttpPost]
        public ActionResult GetDomicilioViewModel(string ID =null)
        {
            ViewBag.Adicional = "En donde se pretende aplicar el crédito";
            var vm = new DomicilioFormViewModel();
            if (ID == null)
                vm = _service.GetDomicilioViewModel();
            else
                vm =  _service.GetDomicilioViewModel(Int32.Parse(ID));

            return PartialView("../Domicilio/_Insertar", vm);
        }

        [HttpPost]
        public ActionResult GetCiudadanoInsertar(string ID = null)
        {
            return PartialView("../Ciudadano/_Insertar", _service.CiudadanoInsertar(ID));
        }

        [HttpPost]
        public ActionResult GetDeudorSolidarioViewModel()
        {
            return PartialView("../DeudorSolidario/_Insertar", _service.GetDeudorSolidario());
        }

        [HttpPost]
        public ActionResult GetListadoSE(string claveSE)
        {
            return Json(_service.ListadoSelectSeccionElectoral(Int32.Parse(claveSE)));
        }

    }
}