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
    public static class AutocompleteHelper
    {
        public static MvcHtmlString Autocomplete<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
            string url, object htmlAttributes)
        {
            return htmlHelper.BuildEditor(expression, url, htmlAttributes);
        }

        public static MvcHtmlString Autocomplete<TModel, TPropEditor, TPropHidden>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TPropEditor>> expressionEditor,
            Expression<Func<TModel, TPropHidden>> expressionIdHolder, string url, object htmlAttributes)
        {
            var _meta = ModelMetadata.FromLambdaExpression(expressionIdHolder, htmlHelper.ViewData);
            var _editor = htmlHelper.BuildEditor(expressionEditor, url, htmlAttributes, _meta);

            return MvcHtmlString.Create(_editor.ToString() + htmlHelper.HiddenFor(expressionIdHolder).ToString());
        }

        private static MvcHtmlString BuildEditor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string url, 
            object htmlAttributes, ModelMetadata metadata = null)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException("url");

            var _attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            _attrs.Add(Constantes.ATTR_DATA_TOGGLE, "autocomplete");
            _attrs.Add(Constantes.ATTR_DATA_URL, url);

            if (metadata != null)
                _attrs.Add(Constantes.ATTR_DATA_ID_HOLDER, string.Format("#{0}", metadata.PropertyName));

            return htmlHelper.EditorFor(expression, new { htmlAttributes = _attrs });
        }
    }
}