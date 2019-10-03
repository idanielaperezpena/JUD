using JUDMB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JUDMB.Controllers
{
    public class CatalogosController : Controller
    {
        

        // GET: Catalogos
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Principal");
        }

        [ActionName("Mostrar")]
        public ActionResult Mostrar()
        {
            return View();
        }

        [ActionName("Insertar")]
        public ActionResult Insertar(string catalogo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54971/api/Catalogos/"+ catalogo+"/GetData");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<string>("cat", catalogo);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Datos = result.ToString();
                }
            }
            ViewBag.Tabla = catalogo;

            return View();
        }



    }
}