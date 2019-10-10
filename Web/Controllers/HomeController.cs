using Entidades;
using Negocio;
using Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Permiso(Disabled = true)]
    public class HomeController : BaseController
    {
        private AuthService _service;

        public HomeController()
        {
            _service = new AuthService(ModelState);
        }

        [AllowAnonymous]
        [UrlReferrer(Disabled = true)]
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
                return AuthProvider.SignOutAndRedirect();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Index(HomeIndexViewModel viewModel)
        {
            var _usuario = _service.Login(viewModel);

            if (ModelState.IsValid)
                return this.SetAuthCookieAndRedirect(_usuario);

            return View(viewModel);
        }
    }
}