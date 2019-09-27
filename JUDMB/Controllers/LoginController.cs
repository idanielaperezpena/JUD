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
            return View();
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
                //Un valor anonimo
                mensaje = new EmpleadoController().Logear(emp);
                if (mensaje.Error == false)
                {
                    Session["token"] = mensaje.Mensaje;

                    client.DefaultRequestHeaders.Add("TokenINVI", Session["token"].ToString());
                    var response = await client.GetAsync("http://localhost:54971/api/Empleado/Getlogeado");
                    var responseString = await response.Content.ReadAsAsync<Empleado>();

                    mensaje.Error = false;
                    mensaje.Mensaje = "Bienvenido perroooooooo" responseString.Nombre;

                    client.Dispose();
                }
                
            }

            return Json(mensaje);
        }
    }
}
