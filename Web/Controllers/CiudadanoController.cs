﻿using Entidades;
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
            ViewBag.Titulo = "Lista de Ciudadanos";
            return View(_vm);
        }

        public ActionResult Validar()
        {
            return View();
        }

        public ActionResult Insertar(string ID)
        {
            if (String.IsNullOrEmpty(ID))
            {
                return RedirectToAction("Index", new Notificacion { Error = true, Mensaje = "Debe elegir un ciudadano para mostrar su información." });
            }
            var _vm = _service.Insertar(ID);
            ViewBag.Titulo = "Solicitudes del Ciudadano";
            return View(_vm);
        }

        public ActionResult Nuevo()
        {
            return View("Insertar");
        }

        public ActionResult Informacion(string ID)
        {
            if (!String.IsNullOrEmpty(ID))
            {
                var vm = new CiudadanoInformacionViewModel();
                vm = _service.Informacion(ID);
                return View(vm);
            }
            else
            {
                return RedirectToAction("Index", new Notificacion { Error = true, Mensaje = "Debe elegir un ciudadano para mostrar su información." });
            }
            
        }

        [HttpPost]
        [Permiso(Disabled = true)]
        public ActionResult Insertar(CiudadanoInsertarViewModel viewModel)
        {
            _service.Edit(viewModel);
            var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
            return Json(errors);
        }

        [HttpPost]
        [Permiso(Disabled = true)]
        public ActionResult GetParejaViewModel()
        {
            return PartialView("../Pareja/_Insertar", _service.GetParejaCiudadano());
        }

        [HttpPost]
        [Permiso(Disabled = true)]
        public ActionResult GetDomicilioViewModel()
        {
            return PartialView("../Domicilio/_Insertar", _service.GetDomicilio());
        }

        [HttpPost]
        [Permiso(Disabled = true)]
        public ActionResult BusquedaExistente(string CadenaBusqueda)
        {
            return PartialView("../Ciudadano/_ValidarTabla", _service.BusquedaCURPNOMBRE(CadenaBusqueda));
        }

    }
}
