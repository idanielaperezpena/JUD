using JUDMB.Controllers_API;
using JUDMB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JUDMB.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "INVI | LOGIN";
            ViewBag.cadena_error = "";
            ViewBag.error = 0;
            return View();
        }

        public ActionResult Index_Error(int error = 1)
        {
            ViewBag.Title = "INVI | LOGIN";
            if(error == 1)
            {
                ViewBag.error = 1;
                ViewBag.cadena_error = "No puede acceder al sistema sin anter Logearse ";
            }
            else
            {
                ViewBag.error = 1;
                ViewBag.cadena_error = "Su sesion ha expirado, por favor ingrese nuevamente";
            }
            

            return View("~/Views/Login/Index.cshtml");
        }

        public ActionResult Recuperar()
        {
            ViewBag.Title = "INVI | Recuperar Contraseña";
            return View();
        }

        [AllowAnonymous]
        [AcceptVerbs("POST")]
        [ActionName("Logear")]
        public async Task<ActionResult> Logear(LoginRequest emp)
        {
            Notificacion mensaje = new Notificacion();
            if (String.IsNullOrWhiteSpace(emp.Password) || String.IsNullOrEmpty(emp.Password))
            {
                mensaje.Error = true;
                mensaje.Mensaje = "validaciones";
            }
            else
            {
                HttpClient client = new HttpClient();
                mensaje = new EmpleadoController().Logear(emp);
                if (mensaje.Error == false)
                {
                    Session["token"] = mensaje.Mensaje;

                    client.DefaultRequestHeaders.Add("TokenINVI", Session["token"].ToString());
                    var response = await client.GetAsync("http://localhost:54971/api/Empleado/Getlogeado");
                    var responseString = await response.Content.ReadAsAsync<Empleado>();

                    mensaje.Error = false;
                    mensaje.Mensaje = "Bienvenido" + responseString.Nombre;

                    client.Dispose();
                }
                
            }

            return Json(mensaje);
        }
    }
}
