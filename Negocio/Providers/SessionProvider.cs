using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class SessionProvider
{
    public const string KEY_MODULOS = "_spModulos";

    public static void Abandon()
    {
        if (HttpContext.Current.Session != null)
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }
    }

    public static ModulosHelper Modulos
    {
        get { return HttpContext.Current.Session[KEY_MODULOS] as ModulosHelper; }
        set { HttpContext.Current.Session[KEY_MODULOS] = value; }
    }
}