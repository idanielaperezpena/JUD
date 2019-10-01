using JUDMB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace JUDMB.Controllers_API
{
    public class EmpleadoController : ApiController
    {

        Empleado[] empleados = new Empleado[]
        {
            new Empleado { No_empleado = "45072", Nombre = "Andres", Password = "1234" , Perfil ="ADMIN"},
            new Empleado { No_empleado = "12345", Nombre = "Daniela", Password = "1234",Perfil ="NORMAL"},
            new Empleado { No_empleado = "54321", Nombre = "Carlos", Password = "1234",Perfil ="ADMIN" }
        };

        [AcceptVerbs("POST" , "GET")]
        [ActionName("Getlogeado")]
        public Empleado GetCurrent_User()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            var empleado = empleados.FirstOrDefault((p) => p.No_empleado == identity.Name);
            return empleado;  
        }

        [AcceptVerbs("POST", "GET")]
        [ActionName("IsLogin")]
        public bool Get_Login()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            if (identity.IsAuthenticated)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        [AllowAnonymous]
        [AcceptVerbs("POST")]
        [ActionName("Logear")]
        public Notificacion Logear([FromBody] LoginRequest login)
        {
            Notificacion mensaje = new Notificacion();
            if (login == null){
                mensaje.Error = true;
                mensaje.Mensaje = "Datos erroneos";
                return mensaje;
            }

            var empleado = empleados.FirstOrDefault((p) => p.No_empleado == login.No_empleado);
            if (empleado == null)
            {
                mensaje.Error = true;
                mensaje.Mensaje = "No existe el empleado";
            }
            else
            {
                if (empleado.Password == login.Password)
                {
                    var token = TokenGenerator.GenerateTokenJwt(login.No_empleado);
                    mensaje.Error = false;
                    mensaje.Mensaje = token;
                }
                else
                {
                    mensaje.Error = true;
                    mensaje.Mensaje = "Datos erroneos";
                }
            }

            return mensaje;

        }

    }
}
