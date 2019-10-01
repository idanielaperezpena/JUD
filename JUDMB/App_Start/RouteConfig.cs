using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace JUDMB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Default_Catalogo",
                url: "Catalogos",
                defaults: new { controller = "Catalogos", action = "Index", catalogo = RouteParameter.Optional }
            );


            routes.MapRoute(
                name: "Catalogo_Mostrar",
                url: "Catalogos/{catalogo}/{action}",
                defaults: new { controller = "Catalogos", action = "Mostrar", catalogo = RouteParameter.Optional }
            );

            routes.MapRoute(
                name: "Default_Parametro",
                url: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Login", action = "Index" }
            );

            

            

        }
    }
}
