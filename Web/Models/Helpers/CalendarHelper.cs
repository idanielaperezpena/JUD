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
    public static class CalendarHelper
    {
        public static MvcHtmlString CustomCalendar<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, 
            CalendarControl control, object htmlAttributes)
        {
            var _attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            _attrs.Add(Constantes.ATTR_DATA_TOGGLE, control.DataToggle);

            if (!string.IsNullOrWhiteSpace(control.DateFormat))
                _attrs.Add(Constantes.ATTR_DATA_FORMAT, control.DateFormat);

            if (control.MinViewMode.HasValue)
                _attrs.Add(Constantes.ATTR_DATA_MIN_VIEWMODE, control.MinViewMode);

            if (control.EsRequerido)
            {
                _attrs.Add(Constantes.ATTR_DATA_VAL, "true");
                _attrs.Add(Constantes.ATTR_DATA_REQUIRED, Constantes.MESSAGE_REQUIRED_FIELD);
            }

            var _container = new TagBuilder("div");
            _container.AddCssClass("calendar-control");

            var _calIcon = new TagBuilder("i");
            _calIcon.AddCssClass("far fa-calendar icon-calendar");

            _container.InnerHtml = htmlHelper.EditorFor(expression, new { htmlAttributes = _attrs }).ToString();
            _container.InnerHtml += _calIcon.ToString();

            if (!control.EsRequerido)
            {
                var _clearIcon = new TagBuilder("i");
                _clearIcon.AddCssClass("fa fa-times icon-clear");
                _container.InnerHtml += _clearIcon.ToString();
            }

            return MvcHtmlString.Create(_container.ToString());
        }
    }
}