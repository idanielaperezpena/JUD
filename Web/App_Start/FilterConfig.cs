using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.Filters;

namespace Web
{
    public class FilterConfig
    {
        public static void RegisterFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new AuthorizeAttribute());
            //filters.Add(new ExceptionAttribute());
            //filters.Add(new UrlReferrerAttribute());
            //filters.Add(new PermisoAttribute());
        }
    }
}