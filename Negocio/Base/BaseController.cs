using Entidades;
using Entidades.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace Negocio
{
    public class BaseController : Controller
    {
        private EncriptarUtility _encriptar;
        private Usuario _usuario;

        public EnumModulo Modulo { get; set; }
        public string ModuloEncoded { get; set; }
        public Usuario Usuario
        {
            get
            {
                if (User.Identity is FormsIdentity && _usuario == null)
                    _usuario = (User.Identity as FormsIdentity).Ticket.UserData.FromJSON<Usuario>();

                return _usuario;
            }
        }

        public EncriptarUtility Encriptador
        {
            get
            {
                if (_encriptar == null)
                    _encriptar = new EncriptarUtility();

                return _encriptar;
            }
        }

        protected JsonResult AjaxRedirectTo(string virtualPath, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return Json(new AjaxResult { Url = Url.Content(virtualPath), StatusCode = statusCode }, JsonRequestBehavior.AllowGet);
        }

        protected JsonResult AjaxRedirectToAction(string actionName, string controllerName, object routeValues, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return Json(new AjaxResult { Url = Url.Action(actionName, controllerName, routeValues), StatusCode = statusCode }, JsonRequestBehavior.AllowGet);
        }

        protected JsonResult Ajax(string mensaje = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return Json(new AjaxResult { Mensaje = mensaje, StatusCode = statusCode }, JsonRequestBehavior.AllowGet);
        }
    }
}
