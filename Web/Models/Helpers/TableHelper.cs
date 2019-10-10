using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Models.Helpers
{
    public static class TableHelper
    {
        public static MvcHtmlString CustomTableEmptyResult(this HtmlHelper html, string texto = "No tenemos registros para mostrarte", string icono = "inbox", int colspan = 20)
        {
            var _content = new System.Text.StringBuilder();

            _content.AppendFormat("<span class=\"fa-stack fa-2x\"><i class=\"fas fa-circle fa-stack-2x\"></i><i class=\"fas fa-{0} fa-stack-1x fa-inverse\"></i></span>", icono);
            _content.AppendFormat("<span>{0}</span>", texto);

            var _td = new TagBuilder("td");
            _td.Attributes["colspan"] = colspan.ToString();
            _td.InnerHtml = _content.ToString();
            _td.AddCssClass("empty-content");

            var _tr = new TagBuilder("tr");
            _tr.AddCssClass("empty-container");
            _tr.InnerHtml = _td.ToString();

            return MvcHtmlString.Create(_tr.ToString());
        }

        public static MvcHtmlString CustomTablePager<T>(this HtmlHelper html, PagedViewModel<T> model)
        {
            if (model.Listado.HasCaption || model.Listado.HasPages)
            {
                TagBuilder _generic = null;
                var _divContainer = new TagBuilder("div");
                _divContainer.AddCssClass("pager-container");

                if (model.Listado.HasCaption)
                {
                    _generic = new TagBuilder("label");

                    _generic.AddCssClass("pager-caption");
                    _generic.InnerHtml = string.Format("{0:n0} registros encontrados", model.Listado.ItemCount);
                    _divContainer.InnerHtml = _generic.ToString();
                }

                if (model.Listado.HasPages)
                {
                    var _ddl = new TagBuilder("select");
                    _ddl.AddCssClass("form-control form-control-sm");
                    _ddl.Attributes["name"] = model.NameControlSelectedPage;
                    _ddl.Attributes["onchange"] = "this.form.submit();";

                    TagBuilder _opt = null;

                    for (int i = 1; i <= model.Listado.PageCount; i++)
                    {
                        _opt = new TagBuilder("option");
                        _opt.Attributes["value"] = i.ToString();
                        _opt.InnerHtml = string.Format("{0:n0}", i);

                        if (i == model.ddlSelectedPage)
                            _opt.Attributes["selected"] = "selected";

                        _ddl.InnerHtml += _opt.ToString();
                    }

                    _generic = new TagBuilder("div");
                    _generic.AddCssClass("pager-controls");
                    _generic.InnerHtml = string.Format("<p>Página</p>{0}<p>de {1:n0}</p>", _ddl, model.Listado.PageCount);

                    var _btn = new TagBuilder("button");
                    _btn.AddCssClass("btn btn-sm btn-link text-secondary");
                    _btn.Attributes["name"] = model.NameControlPrevNext;
                    _btn.Attributes["value"] = "-1";
                    _btn.InnerHtml = "<i class='fa fa-chevron-left'></i>";

                    if (model.ddlSelectedPage <= 1)
                        _btn.Attributes["disabled"] = "disabled";

                    _generic.InnerHtml += _btn.ToString();

                    _btn = new TagBuilder("button");
                    _btn.AddCssClass("btn btn-sm btn-link text-secondary");
                    _btn.Attributes["name"] = model.NameControlPrevNext;
                    _btn.Attributes["value"] = "1";
                    _btn.InnerHtml = "<i class='fa fa-chevron-right'></i>";

                    if (model.ddlSelectedPage + 1 > model.Listado.PageCount)
                        _btn.Attributes["disabled"] = "disabled";

                    _generic.InnerHtml += _btn.ToString();
                    _divContainer.InnerHtml += _generic.ToString();

                }

                return MvcHtmlString.Create(_divContainer.ToString());
            }

            return MvcHtmlString.Empty;
        }
    }
}