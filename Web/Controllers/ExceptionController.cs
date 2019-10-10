using Entidades;
using Negocio;
using Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Permiso(Disabled = true)]
    public class ExceptionController : BaseController
    {
        private ExceptionService _service;
        protected virtual string RegresarUrl
        {
            get
            {
                return Usuario == null ? AuthProvider.LoginUrl : Usuario.UrlDefault;
            }
        }

        public ExceptionController()
        {
            _service = new ExceptionService(ModelState);
        }

        [AllowAnonymous]
        public async Task<ActionResult> Log()
        {
            var _error = TempData["_error"] as ErrorLog;

            if (_error != null)
            {
                if (_error.Ex is HttpAntiForgeryException)
                    return Redirect(RegresarUrl);

                var _vm = await _service.Log(Server, _error, Usuario);
                _vm.RegresarUrl = RegresarUrl;
                _vm.IsAjax = Request.IsAjaxRequest();

                if (_vm.IsAjax)
                    return PartialView("_Ex", _vm);

                return View(_vm);
            }

            return Redirect(AuthProvider.LoginUrl);
        }
    }
}