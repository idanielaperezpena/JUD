using JUDMB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JUDMB.Controllers_API
{
    public class EmpleadoController : ApiController
    {

        Empleado[] empleados = new Empleado[]
        {
            new Empleado { No_empleado = 45072, Nombre = "Andres", Password = "1234"},
            new Empleado { No_empleado = 12345, Nombre = "Daniela", Password = "1234"},
            new Empleado { No_empleado = 54321, Nombre = "Carlos", Password = "1234" }
        };



        [AcceptVerbs("POST")]
        [ActionName("Logear")]
        public Notificacion Logear([FromBody] Empleado emp)
        {
            Notificacion mensaje = new Notificacion();
            var empleado = empleados.FirstOrDefault((p) => p.No_empleado == emp.No_empleado);
            if (empleado == null)
            {
                mensaje.Error = true;
                mensaje.Mensaje = "No existe el empleado";
            }
            else
            {
                if (empleado.Password == emp.Password)
                {
                    mensaje.Error = false;
                    mensaje.Mensaje = "Bienvenido " + empleado.Nombre;
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
