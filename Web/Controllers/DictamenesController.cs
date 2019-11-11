using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult InsertarDictamenJuridico()
        {
            var _vm = _service.InsertarDictamenJuridico();
            return View(_vm);
        }
        public ActionResult InsertarDictamenSocial()
        {
            var _vm = _service.InsertarDictamenSocial();
            return View(_vm);
        }
        public ActionResult InsertarDictamenTecnico()
        {
            var _vm = _service.InsertarDictamenTecnico();
            return View(_vm);
        }
        public ActionResult InsertarDictamenFinanciero()
        {
            var _vm = _service.InsertarDictamenFinanciero();
            return View(_vm);
        }
    }
}