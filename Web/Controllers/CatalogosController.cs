using Entidades;
using Negocio;
using Negocio.ViewModels;
using Negocio.ViewModels.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.INVI;

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

        public ActionResult Index(Notificacion notificacion = null )
        {
            if (notificacion != null)
            {
                ViewBag.Error = notificacion.Error;
                ViewBag.MensajeError = notificacion.Mensaje;
            }
            else
            {
                ViewBag.Error = false;
            }
            var _vm = _service.Index();
            ViewBag.Titulo = "Catálogos";
            return View(_vm);
        }

        [AcceptVerbs("GET")]
        public ActionResult Mostrar(string nombre)
        {
            if (String.IsNullOrEmpty(nombre))
            {
                ViewBag.Titulo = "Detalle Nulo ";
                return RedirectToAction("Index",new Notificacion { Error = true , Mensaje = "Debe elegir un catálogo para mostrar su información"});
            }
            var _vm = _service.Mostrar(nombre);
            ViewBag.Titulo = "Detalle Catálogo ";
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

        /*
        [HttpPost]
        public ActionResult Edit(CatalogosMostrarModalViewModel Formulario)
        {
            var _vm = _service.GetModal(Tabla, ID);
            return PartialView("_MostrarModal", _vm);
        }*/

    }
}