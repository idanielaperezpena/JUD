using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

public static class ExtensionsUtility
{
    public static string GetNotificacionPlantilla(this HttpServerUtilityBase server)
    {
        var _path = server.MapPath(Path.Combine(SettingsProvider.EmailNotificaciones, EnumNotificacionEmail.Plantilla.ToDescription()));
        var _html = File.ReadAllText(_path, Encoding.UTF8);

        _html = _html.Replace("@AppUrl@", SettingsProvider.Url)
            .Replace("@AppNombre@", SettingsProvider.AppNombre)
            .Replace("@Footer@", string.Format("{0} {1}", SettingsProvider.AppTitulo, DateTime.Now.Year));

        return _html;
    }

    public static string GetNotificacion(this HttpServerUtilityBase server, EnumNotificacionEmail notificacion, string titulo = null)
    {
        var plantilla = server.GetNotificacionPlantilla();
        var path = server.MapPath(Path.Combine(SettingsProvider.EmailNotificaciones, notificacion.ToDescription()));
        var html = File.ReadAllText(path, Encoding.UTF8);

        html = plantilla.Replace("@Header@", titulo ?? string.Empty)
            .Replace("@Body@", html);

        return html;
    }

    public static string ToErrorsString(this ModelStateDictionary modelState, string separador = "<br/>")
    {
        var _errores = modelState.SelectMany(e => e.Value.Errors).Select(s => s.ErrorMessage.Replace(Environment.NewLine, separador)).Distinct();

        return _errores.JoinElements(separador);
    }
}