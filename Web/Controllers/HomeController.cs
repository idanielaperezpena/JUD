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
        private AuthService _service2;

        private CatalogosService _service;
        

        public HomeController()
        {
            _service = new CatalogosService(ModelState);
            _service2 = new AuthService(ModelState);
        }

        [HttpPost]
        [AcceptVerbs("POST","GET")]
        [AllowAnonymous]
        public ActionResult Prueba(string id)
        {
            var resultado_catalogo = _service.Listado(id);
            return Json(resultado_catalogo);
        }

        
        [AllowAnonymous]
        [UrlReferrer(Disabled = true)]
        public ActionResult Index()
        {
            
            if (Request.IsAuthenticated)
                return AuthProvider.SignOutAndRedirect();


            ViewBag.error = 0;
            ViewBag.Titulo = "Login";
            return View();
        }

        
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Index(HomeIndexViewModel viewModel)
        {
            var _usuario = _service2.Login(viewModel);

            if (ModelState.IsValid)
                return this.SetAuthCookieAndRedirect(_usuario);

            return View(viewModel);
        }*/


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Index(HomeIndexViewModel viewModel)
        {
            var _usuario = _service2.Login(viewModel);

            if (ModelState.IsValid)
                return Json("exito");

            return Json("mal");
        }

    }
}