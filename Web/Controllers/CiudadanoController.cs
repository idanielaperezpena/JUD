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
    public class CiudadanoController : BaseController
    {

        private CiudadanoService _service;

        public CiudadanoController()
        {
            _service = new CiudadanoService(ModelState);
        }

        // GET: Ciudadano
        public ActionResult Index()
        {
            var _vm = _service.Index();
            ViewBag.Titulo = "Lista de ciudadanos";
            return View(_vm);
        }
        public ActionResult Insertar()
        {
            return View();
        }

        [AcceptVerbs ("POST")]
        public ActionResult Solicitudes()
        {
            var _vm = _service.Index();
            ViewBag.Titulo = "Solicitudes del Ciudadano";
            return View(_vm);
        }
    }
}