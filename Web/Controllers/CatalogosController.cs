using Entidades;
using Negocio;
using Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Web.Controllers
{
    [Permiso(Disabled = true)]
    public class CatalogosController : BaseController
    {
        private CatalogosService _service;

        public CatalogosController(){
            _service = new CatalogosService(ModelState);
        }

        [HttpGet]
        [AllowAnonymous]
        [Permiso(Disabled = true)]
        public ActionResult Prueba(string catalago)
        {
            if (Request.IsAuthenticated)
            {
                var resultado_catalogo = _service.Listado(catalago);
                return Json(resultado_catalogo);
            }
            else
            {
                var resultado_catalogo = _service.Listado(catalago);
                return Json(resultado_catalogo);
            }

        }


        // GET: Catalogos
        [AllowAnonymous]
        [Permiso(Disabled = true)]
        public ActionResult Index()
        {
            return View();
        }

        


    }
}