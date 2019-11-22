using Negocio;
using Negocio.ViewModels.ModificacionesCredito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ModificacionesCreditoController : Controller
    {
        private ModificacionesCreditoService _service;

        public ModificacionesCreditoController()
        {
            _service = new ModificacionesCreditoService(ModelState);
        }

        // GET: ModificacionesCredito
        public ActionResult Index()
        {
            var _vm = _service.Index();

            return View(_vm);
        }
        // GET: ModificacionesCredito/insertar
         public ActionResult Insertar(int IDCreditoInicial, string IDModificacionesCredito)
        {
            int? IDModificacionesCredito2 = null;
            if (!String.IsNullOrEmpty(IDModificacionesCredito))
            {
                IDModificacionesCredito2 = Int32.Parse(IDModificacionesCredito);
            }
            var _vm=_service.Insertar(IDCreditoInicial, IDModificacionesCredito2);
            return View(_vm);
        }

        [HttpPost]
        public ActionResult Insertar(ModificacionesCreditoInsertarViewModel _viewModel)
        {
            _service.EditModificacionesCredito(_viewModel);
            var errors = ModelState.Select(x => x.Value.Errors)
                     .Where(y => y.Count > 0)
                     .ToList();
            return Json(errors.ToJSON());

        }
    }
}