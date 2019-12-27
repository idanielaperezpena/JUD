using Negocio;
using Negocio.ViewModels.CreditoSustentabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CreditoSustentabilidadController : BaseController
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
            ViewBag.Titulo = "Lista de Creditos de Sustentabilidad";
            _vm.user = this.Usuario;
            return View(_vm);
        }

        // GET: CreditoSustentabilidad/Insertar
        public ActionResult Insertar(int IDCreditoInicial, string IDCreditoSustentabilidad)
        {
            int? IDCreditoSustentabilidad2 = null;
            if (!String.IsNullOrEmpty(IDCreditoSustentabilidad))
            {
                IDCreditoSustentabilidad2 = Int32.Parse(IDCreditoSustentabilidad);
            }
            var _vm = _service.Insertar(IDCreditoInicial, IDCreditoSustentabilidad2);
            return View(_vm);
        }

        [HttpPost]
        [Permiso(Disabled = true)]
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