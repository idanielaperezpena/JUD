using Entidades;
using Negocio;
using Negocio.ViewModels;
using Negocio.ViewModels.Catalogos;
using Negocio.ViewModels.Ciudadanos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.INVI;
namespace Web.Controllers
{
    [Permiso(Disabled = true)]
    public class CiudadanoController : BaseController
    {

        private CiudadanoService _service;

        public CiudadanoController()
        {
            _service = new CiudadanoService(ModelState);
        }

        // GET: Ciudadano
        public ActionResult Index(Notificacion notificacion = null)
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
            ViewBag.Titulo = "Lista de ciudadanos";
            return View(_vm);
        }



        public ActionResult Solicitudes(string ID)
        {
            if (String.IsNullOrEmpty(ID))
            {
                return RedirectToAction("Index", new Notificacion { Error = true, Mensaje = "Debe elegir un ciudadano para mostrar su informacion" });
            }
            var _vm = _service.Solicitudes(ID);
            ViewBag.Titulo = "Solicitudes del Ciudadano";
            return View(_vm);
        }


        public ActionResult Insertar()
        {
          
            _service.Edit(viewModel);

            if (ModelState.IsValid)
                return RedirectToAction("Solicitudes", new { m = ModuloEncoded, c = viewModel.ID_Encriptado });

            return View(viewModel);
        }

        //[HttpPost]
        //public ActionResult Insertar()
        //{
        //    return View();
        //}
    }
}