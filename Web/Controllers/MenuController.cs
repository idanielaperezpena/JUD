using Entidades;
using Negocio;
using Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class MenuController : BaseController
    {
        private AuthService _service;

        public MenuController()
        {
            _service = new AuthService(ModelState);
        }

        [ChildActionOnly]
        public ActionResult _Navbar()
        {
            if (SessionProvider.Modulos == null)
                SessionProvider.Modulos = _service.InitModulos(Usuario);

            var _vm = new MenuViewModel
            {
                ModulosUsuario = SessionProvider.Modulos[EnumTipoMenu.Lateral],
                ModulosAdmin = SessionProvider.Modulos[EnumTipoMenu.Administrador],
                Usuario = Usuario
            };
            return PartialView(_vm);
        }

        [ChildActionOnly]
        public ActionResult _Footer()
        {
            string IPAddress = "";
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }

            var _vm = new FooterViewModel
            {
                Usuario = Usuario,
                IPAddress = IPAddress,
                DateTime = DateTime.Now
            };

            return PartialView(_vm);
        }

        [Permiso(Disabled = true)]
        public ActionResult Logout()
        {
            return AuthProvider.SignOutAndRedirect();
        }
    }
}