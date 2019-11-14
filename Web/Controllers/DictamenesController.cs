using Entidades;
using Negocio;
using Negocio.ViewModels.DictamenFinanciero;
using Negocio.ViewModels.DictamenJuridico;
using Negocio.ViewModels.DictamenSocial;
using Negocio.ViewModels.DictamenTecnico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.INVI;

namespace Web.Controllers
{
    [Permiso(Disabled = true)]
    public class DictamenesController : Controller
    {
        private DictamenesService _service;

        public DictamenesController()
        {
            _service = new DictamenesService(ModelState);
        }

        // GET: Dictamenes
        public ActionResult InsertarDictamenJuridico(String TipoCredito, int ID)
        {

            var _vm = _service.InsertarDictamenJuridico(TipoCredito, ID);
            return View(_vm);
            

        }

        public ActionResult InsertarDictamenSocial(String TipoCredito, int ID )
        {
               var _vm = _service.InsertarDictamenSocial(TipoCredito, ID);
               return View(_vm);
            
        }
        public ActionResult InsertarDictamenTecnico(String TipoCredito, int ID)
        {
            var _vm = _service.InsertarDictamenTecnico(TipoCredito, ID);
            return View(_vm);
        }
        public ActionResult InsertarDictamenFinanciero(String TipoCredito, int ID)
        {
            var _vm = _service.InsertarDictamenFinanciero(TipoCredito, ID
);
            return View(_vm);
        }

        //POST:Dictamenes
        [HttpPost]
        public ActionResult InsertarDictamenJuridico(DictamenJuridicoViewModel _viewModel)
        {
                _service.EditDitamenJuridico(_viewModel);
            var errors = ModelState.Select(x => x.Value.Errors)
                     .Where(y => y.Count > 0)
                     .ToList();
            return Json(errors.ToJSON());
        }
        [HttpPost]
        public ActionResult InsertarDictamenSocial(DictamenSocialViewModel _viewModel)
        {
            _service.EditDitamenSocial(_viewModel);
            var errors = ModelState.Select(x => x.Value.Errors)
                         .Where(y => y.Count > 0)
                         .ToList();
            return Json(errors.ToJSON());
        }

        [HttpPost]
        public ActionResult InsertarDictamenTecnico(DictamenTecnicoViewModel _viewModel)
        {
            _service.EditDitamenTecnico(_viewModel);
            var errors = ModelState.Select(x => x.Value.Errors)
                         .Where(y => y.Count > 0)
                         .ToList();
            return Json(errors.ToJSON());
        }
        [HttpPost]
        public ActionResult InsertarDictamenFinanciero(DictamenFinancieroViewModel _viewModel)
        {
            _service.EditDitamenFinanciero(_viewModel);
            var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();
            return Json(errors.ToJSON());
        }

    }
}