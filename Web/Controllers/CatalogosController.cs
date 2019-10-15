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

        public ActionResult Index()
        {
            var _vm = _service.Index();
            ViewBag.Tittle = "Catalogos";

            return View(_vm);
        }


        public ActionResult Mostrar(string nombre)
        {
            var _vm = _service.Mostrar(nombre);
            ViewBag.Tittle = "Catalogos";

            return View(_vm);
        }

    }
}