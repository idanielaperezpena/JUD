using JUDMB.Controllers_API;
using JUDMB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JUDMB.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "INVI | LOGIN";
            return View();
        }


        public ActionResult Recuperar()
        {
            ViewBag.Title = "INVI | Recuperar Contraseña";
            return View();
        }


        [AcceptVerbs("POST")]
        [ActionName("Logear")]
        public ActionResult Logear(LoginRequest emp)
        {
            Notificacion mensaje = new Notificacion();
            if (String.IsNullOrWhiteSpace(emp.Password) || String.IsNullOrEmpty(emp.Password))
            {
                mensaje.Error = true;
                mensaje.Mensaje = "validaciones";
            }
            else
            {
                var mensaje_api = new Controllers_API.LoginController().Authenticate(emp);
                return Json(mensaje_api);
            }

            return Json(mensaje);
        }
    }
}
