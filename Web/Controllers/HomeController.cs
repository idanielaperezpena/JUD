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
            Notificacion noti = new Notificacion();

            if (ModelState.IsValid)
            {
                var _usuario = _service.Login(viewModel);
                if (_usuario != null)
                {
                    noti.Error = false;
                    noti.Mensaje = "Bienvenido " + _usuario.USU_Usuario;
                    this.SetAuthCookieAndRedirect(_usuario);
                    return Json(noti);
                }            
            }

            noti.Error = true;
            noti.Mensaje = "Error en las credenciales, intente otra vez.";
            return Json(noti);
        }

    }
}