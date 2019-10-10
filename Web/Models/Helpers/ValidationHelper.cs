using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Web.Models.Helpers
{
    public static class ValidationHelper
    {
        public static MvcHtmlString CustomValidationSummary(this HtmlHelper helper, string tipo = null, string titulo = null)
        {
            if (helper.ViewData.ModelState.IsValid)
                return MvcHtmlString.Create(string.Empty);

            var _string = new StringBuilder();

            _string.Append("<script>");
            _string.AppendFormat("$(document).ready(function(){{mostrarAlerta(\"{0}\", \"{1}\", \"{2}\");}});", helper.ViewData.ModelState.ToErrorsString(), tipo, titulo);
            _string.Append("</script>");

            foreach (var item in helper.ViewData.ModelState.Values)
                item.Errors.Clear();

            return MvcHtmlString.Create(_string.ToString());
        }
    }
}
