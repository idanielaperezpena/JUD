using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web
{
    public class PermisoAttribute : ActionFilterAttribute
    {
        public bool Disabled { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var _controller = filterContext.Controller as BaseController;

            if (_controller != null)
            {
                _controller.ModuloEncoded = filterContext.HttpContext.Request.QueryString["m"];
                _controller.Modulo = _controller.Encriptador.Decode<EnumModulo>(_controller.ModuloEncoded);
            }

            if (!Disabled && !filterContext.IsChildAction)
            {
                if (_controller != null)
                {
                    if(_controller.Modulo == EnumModulo.NoDefinido || !filterContext.HttpContext.User.IsInRole(RoleProviderBase.GetRoleFormat(_controller.Modulo, EnumModuloPermiso.Consulta)))
                        filterContext.Result = AuthProvider.SignOutAndRedirect();
                }
                else
                    filterContext.Result = AuthProvider.SignOutAndRedirect();
            }

            base.OnActionExecuting(filterContext);
        }
    }
}