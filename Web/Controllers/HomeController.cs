using Entidades;
using Negocio;
using Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.INVI;

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

            ViewBag.error = 0;
            ViewBag.Titulo = "Login";
            return View();
        }


        [ChildActionOnly]
        public Usuario GetUsuario()
        {
            return this.Usuario;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Index(HomeIndexViewModel viewModel)
        {
            var notificacion = new Notificacion { Error = false, Mensaje = "" };

            if (ModelState.IsValid)
            {
                var _usuario = _service.Login(viewModel);

                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();

                if (errors.Count > 0)
                {
                    notificacion.Error = true;
                    foreach (var item in errors)
                    {
                        foreach (var item2 in item)
                        {
                            notificacion.Mensaje += item2.ErrorMessage + "<br>";
                        }
                    }

                }
                else {
                    notificacion.Error = false;
                    notificacion.Mensaje = "Bienvenido " + _usuario.USU_Usuario;
                    this.SetAuthCookieAndRedirect(_usuario);
                }
            }
            return Json(notificacion);
        }

        [Permiso(Disabled = true)]
        public ActionResult CerrarSesion()
        {
            return AuthProvider.SignOutAndRedirect();
        }
    }
}