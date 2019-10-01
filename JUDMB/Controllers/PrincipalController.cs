using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JUDMB.Controllers
{
    public class PrincipalController : Controller
    {
        HttpClient client = new HttpClient();

        // GET: Principal
        public async Task<ActionResult> Index()
        {

            if (Session["token"] is null ) {
                ViewBag.Title = "Error inicio de sesion";
                return RedirectToAction("Index_Error", "Login", 1);
            }
            else
            {
                bool estatus = await Verificar_LoginAsync();
                if (estatus)
                {
                    ViewBag.Title = "INVI | Menu principal ";
                    return View();
                }
                else
                {
                    ViewBag.Title = "Token Invalido ";
                    return View();
                }
                
            }

            
        }


        public async Task<bool> Verificar_LoginAsync()
        {
            client.DefaultRequestHeaders.Add("TokenINVI", Session["token"].ToString());
            var response = await client.GetAsync("http://localhost:54971/api/Empleado/IsLogin");
            var responseString = await response.Content.ReadAsAsync<Boolean>();
            client.Dispose();

            return responseString;
        }
    }
}