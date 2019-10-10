using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Web.Models.Helpers
{
    public static class EditorHelper
    {
        public static MvcHtmlString CustomEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes,
            bool enabled = true, bool visible = true)
        {
            var _attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            if (!enabled)
                _attrs.Add(Constantes.ATTR_READONLY, Constantes.ATTR_READONLY);

            if (!visible)
                _attrs[Constantes.ATTR_CLASS] = string.Format("{0} d-none", _attrs[Constantes.ATTR_CLASS]);

            return htmlHelper.EditorFor(expression, new { htmlAttributes = _attrs });
        }
    }
}