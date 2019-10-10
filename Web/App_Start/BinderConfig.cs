using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.Binders;

namespace Web
{
    public class BinderConfig
    {
        public static void RegisterModelBinders(ModelBinderDictionary binders)
        {
            binders.Add(typeof(decimal), new NumericModelBinder<decimal>());
            binders.Add(typeof(decimal?), new NumericModelBinder<decimal?>());
            binders.Add(typeof(int), new NumericModelBinder<int>());
            binders.Add(typeof(int?), new NumericModelBinder<int?>());
            binders.Add(typeof(long), new NumericModelBinder<long>());
            binders.Add(typeof(long?), new NumericModelBinder<long?>());
            binders.Add(typeof(CalendarControl), new CalendarModelBinder());
        }
    }
}