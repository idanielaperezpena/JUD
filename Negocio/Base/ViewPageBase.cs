using Entidades;
using Entidades.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Negocio
{
    public interface IViewPageBase
    {
        BaseController Controller { get; }
        EnumModulo Modulo { get; }
        EncriptarUtility Encriptador { get; }
        bool this[EnumModuloPermiso Permiso] { get; }
        string LoaderId { get; }
    }

    public abstract class ViewPageBase : WebViewPage, IViewPageBase
    {
        public virtual BaseController Controller => ViewContext.Controller as BaseController;
        public virtual EnumModulo Modulo => Controller.Modulo;
        public virtual EncriptarUtility Encriptador => Controller.Encriptador;
        public virtual bool this[EnumModuloPermiso Permiso] => User.IsInRole(RoleProviderBase.GetRoleFormat(Modulo, Permiso));
        public virtual string LoaderId => "divLoader";
    }

    public abstract class ViewPageBase<T> : WebViewPage<T>, IViewPageBase
    {
        public virtual BaseController Controller => ViewContext.Controller as BaseController;
        public virtual EnumModulo Modulo => Controller.Modulo;
        public virtual EncriptarUtility Encriptador => Controller.Encriptador;
        public virtual bool this[EnumModuloPermiso Permiso] => User.IsInRole(RoleProviderBase.GetRoleFormat(Modulo, Permiso));
        public virtual string LoaderId => "divLoader";
    }
}
