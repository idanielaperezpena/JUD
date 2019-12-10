using Negocio;
using Negocio.ViewModels.ReporteCGMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using Web.Models.INVI;

namespace Web.Controllers
{
    [Permiso(Disabled = true)]
    public class ReporteCGMAController : Controller
    {
        private ReporteCGMAService _service;

        public ReporteCGMAController()
        {
            _service = new ReporteCGMAService(ModelState); 
        }

        // GET: ReporteCGMA
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
            return View(_vm);
        }

        [HttpPost]
        public ActionResult IndexToExcel()
        {

            var _file = _service.IndexToExcel();

            if (ModelState.IsValid)
                return File(_file.FileBytes, _file.MimeType, _file.ContentDisposition.FileName);

            var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
            var notificacion = new Notificacion { Error = false, Mensaje = "" };
            if (errors.Count > 0)
            {
                notificacion.Error = true;
                foreach (var item in errors)
                {
                    foreach (var item2 in item)
                    {
                        notificacion.Mensaje += item2.ErrorMessage + "<br>";
                    }
                }

            }
            return Json(notificacion);
        }
    }
}