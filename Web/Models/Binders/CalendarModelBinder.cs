using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Models.Binders
{
    public class CalendarModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var _val = base.BindModel(controllerContext, bindingContext) as CalendarControl;

            if (_val != null && !string.IsNullOrWhiteSpace(_val.FechaString))
            {
                var _dates = _val.FechaString.Replace(" -", string.Empty)
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (_dates.Length > 0)
                    _val.FechaInicio = _dates[0].ParseTo<DateTime?>(_val.DateFormat);

                if (_dates.Length > 1)
                    _val.FechaFin = _dates[1].ParseTo<DateTime?>(_val.DateFormat);
            }

            return _val;
        }
    }
}