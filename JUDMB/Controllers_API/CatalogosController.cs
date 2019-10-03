using JUDMB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace JUDMB.Controllers_API
{
    public class CatalogosController : ApiController
    {

        [AcceptVerbs("POST")]
        [ActionName("GetData")]
        public Object GetData([FromBody] string cat)
        {
            Notificacion mensaje = new Notificacion();
            if (cat == null)
            {
                mensaje.Error = true;
                mensaje.Mensaje = "Parametros Erroneos";
                return mensaje;
            }
            else
            {
                try {
                    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["MejoramientoJUD"].ConnectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from " + cat, con);
                    SqlDataReader reader = cmd.ExecuteReader();


                    DataTable tabla = new DataTable();
                    tabla.Load(reader);

                    Catalogos catalogo = new Catalogos();
                    catalogo.Nombre_Tabla = cat;
                    catalogo.Data = tabla;

                    return catalogo.Data;
                }
                catch (SqlException ex) {
                    mensaje.Error = true;
                    mensaje.Mensaje = ex.ToString();
                    return mensaje;
                }
                
            }

        }
    }
}