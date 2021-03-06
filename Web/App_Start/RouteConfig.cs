﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Dictamenes",
               url: "Dictamenes/{action}/{TipoCredito}/{ID}",
               defaults: new { controller = "Dictamenes", TipoCredito = "", ID = 0 }
           );

            routes.MapRoute(
               name: "CreditoComplementario",
               url: "CreditoComplementario/Insertar/{IDCreditoInicial}/{IDCreditoComplementario}",
               defaults: new {
                   controller = "CreditoComplementario",
                   action = "Insertar",
                   IDCreditoInicial = 0,
                   IDCreditoComplementario = UrlParameter.Optional
               }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/",
                defaults: new { controller = "Home", action = "Index" }
            );

           

            routes.MapRoute(
              name: "Ciudadano",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Ciudadano", action = "Index", id = UrlParameter.Optional }
          );
           

        }
    }
}
