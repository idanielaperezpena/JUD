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
    public static class DropDownListHelper
    {
        public static MvcHtmlString CustomDropDownListFor<TModel, TProperty, TList>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<TList> listado, string dataValueField, string dataTextField, object htmlAttributes, bool enabled = true, bool visible = true, string optionLabel = "Seleccione...")
        {
            var _selectList = new SelectList(listado, dataValueField, dataTextField);

            return htmlHelper.CustomDropDownListFor(expression, _selectList, htmlAttributes, enabled, visible, optionLabel);
        }

        public static MvcHtmlString CustomDropDownListFor<TModel, TProperty, TList>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, ICustomSelectList<TList> listado, object htmlAttributes, bool enabled = true, bool visible = true, string optionLabel = "Seleccione...") where TList : ICustomSelectList
        {
            var _selectList = new SelectList(listado, listado.DataValueField, listado.DataTextField);

            return htmlHelper.CustomDropDownListFor(expression, _selectList, htmlAttributes, enabled, visible, optionLabel);
        }

        private static MvcHtmlString CustomDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, SelectList selectList, object htmlAttributes, bool enabled, bool visible, string optionLabel)
        {
            var _attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var _htmlString = string.Empty;

            if (!enabled)
            {
                _attrs.Add(Constantes.ATTR_DISABLED, Constantes.ATTR_DISABLED);
                _htmlString = htmlHelper.HiddenFor(expression).ToString();
            }

            if (!visible)
                _attrs[Constantes.ATTR_CLASS] = string.Format("{0} d-none", _attrs[Constantes.ATTR_CLASS]);

            _htmlString += htmlHelper.DropDownListFor(expression, selectList, optionLabel, _attrs).ToString();

            return MvcHtmlString.Create(_htmlString);
        }
    }
}