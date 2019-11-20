using Negocio;
using Negocio.ViewModels.CreditoSustentabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CreditoSustentabilidadController : Controller
    {
        private CreditoSustentabilidadService _service;

        public CreditoSustentabilidadController()
        {
            _service = new CreditoSustentabilidadService(ModelState);
        }

        // GET: CreditoSustentabilidad/Index
        public ActionResult Index()
        {
            var _vm = _service.Index();

            return View(_vm);
        }

        // GET: CreditoSustentabilidad/Insertar
        public ActionResult Insertar(int IDCreditoInicial, int? IDCreditoSustentabilidad)
        {

            var _vm = _service.Insertar(IDCreditoInicial, IDCreditoSustentabilidad);
            return View(_vm);
        }

        [HttpPost]
        public ActionResult Insertar(CreditoSustentabilidadInsertarViewModel _viewModel)
        {
            _service.EditCreditoSustentabilidad(_viewModel);
            var errors = ModelState.Select(x => x.Value.Errors)
                     .Where(y => y.Count > 0)
                     .ToList();
            return Json(errors.ToJSON());

        }
    }
}