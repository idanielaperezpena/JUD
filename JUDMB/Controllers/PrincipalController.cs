using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JUDMB.Funciones;
using JUDMB.Models;

namespace JUDMB.Controllers
{
    public class PrincipalController : Controller
    {
        Validar_Login validar;


  
        // GET: Principal
        public async Task<ActionResult> Index()
        {
            if (Session["token"] is null ) {
                return RedirectToAction("Index_Error", "Login", new { error = 1});
            }
            else
            {
                validar = new Validar_Login(Session["token"].ToString());
                bool estatus = await validar.Verificar_LoginAsync();
                if (estatus)
                {
                    Empleado logeado =await validar.Datos_Logeado();
                    ViewBag.Nombre = logeado.Nombre;
                    ViewBag.Perfil = logeado.Perfil;
                    //ViewBag.IP = validar.GetIPAddress();
                    ViewBag.IP = "127.0.0.1";
                    ViewBag.Title = "INVI | Menu principal ";
                    return View();
                }
                else
                {
                    return RedirectToAction("Index_Error", "Login", 2);
                }     
            }
        }


    }
}