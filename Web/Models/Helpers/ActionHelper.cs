using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.Models.Helpers
{
    public static class ActionHelper
    {
        public static string ActionEncoded<TModel>(this HtmlHelper<TModel> htmlHelper, string actionName, object routeValues)
        {
            var _view = htmlHelper.ViewDataContainer as ViewPageBase<TModel>;
            var _encRoutes = _view.BuildRoutes(routeValues);

            return _view.Url.Action(actionName, _encRoutes);
        }

        public static string ActionEncoded<TModel>(this HtmlHelper<TModel> htmlHelper, string actionName, string controllerName, object routeValues)
        {
            var _view = htmlHelper.ViewDataContainer as ViewPageBase<TModel>;
            var _encRoutes = _view.BuildRoutes(routeValues);

            return _view.Url.Action(actionName, controllerName, _encRoutes);
        }

        private static RouteValueDictionary BuildRoutes<TModel>(this ViewPageBase<TModel> view, object routeValues)
        {
            if (view == null)
                throw new ArgumentException("La Vista debe heredar de Negocio/Base/ViewPageBase", "ViewDataContainer");

            if (routeValues == null)
                throw new ArgumentNullException("routeValues");

            var _routes = new RouteValueDictionary(routeValues);
            var _newRoutes = new RouteValueDictionary();

            foreach (var item in _routes)
                _newRoutes.Add(item.Key, view.Encriptador.Encode(item.Value));

            return _newRoutes;
        }
    }
}