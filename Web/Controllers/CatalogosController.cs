using Entidades;
using Negocio;
using Negocio.ViewModels;
using Negocio.ViewModels.Catalogos;
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

        // Vistas

        public ActionResult Index()
        {
            var _vm = _service.Index();
            ViewBag.Titulo = "Catalogos";
            return View(_vm);
        }

        public ActionResult Mostrar(string nombre)
        {
            var _vm = _service.Mostrar(nombre);
            ViewBag.Titulo = "Detalle Catalogo ";
            _vm.Tabla = nombre;
            return View(_vm);
        }


        //Funciones

        [HttpPost]
        public ActionResult GetVistaModal(string Tabla,int ID)
        {
            var _vm = _service.GetModal(Tabla, ID);
            return PartialView("_MostrarModal",_vm);
        }


        [HttpPost]
        public ActionResult Edit(CatalogosMostrarModalViewModel Formulario)
        {
            var _vm = _service.GetModal(Tabla, ID);
            return PartialView("_MostrarModal", _vm);
        }

    }
}