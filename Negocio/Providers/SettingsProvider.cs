using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

public class SettingsProvider
{
    public static string AppNombre
    {
        get { return ConfigurationManager.AppSettings["app:nombre"]; }
    }
    public static string AppTitulo
    {
        get { return ConfigurationManager.AppSettings["app:titulo"]; }
    }
    public static string AppVersion
    {
        get { return ConfigurationManager.AppSettings["app:version"]; }
    }
    public static string Url
    {
        get { return ConfigurationManager.AppSettings["app:url"]; }
    }
    public static string PathUpload
    {
        get { return ConfigurationManager.AppSettings["dir:uploads"]; }
    }
    public static string PathUploadTemporales
    {
        get { return string.Format("{0}/Temporales/", PathUpload); }
    }
    public static string EmailNotificaciones
    {
        get { return ConfigurationManager.AppSettings["notif:templates"]; }
    }
    public static string EmailDireccion
    {
        get { return ConfigurationManager.AppSettings["notif:email"]; }
    }
    public static string EmailNombre
    {
        get { return ConfigurationManager.AppSettings["notif:nombre"]; }
    }
    public static string SendgridApiKey
    {
        get { return ConfigurationManager.AppSettings["notif:sendGrid"]; }
    }
}