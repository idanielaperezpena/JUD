using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web
{
    public class UrlReferrerAttribute : ActionFilterAttribute
    {
        public bool Disabled { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Disabled && !filterContext.IsChildAction)
            {
                var _requestCtx = filterContext.HttpContext.Request;

                if (_requestCtx.UrlReferrer != null)
                {
                    if (!_requestCtx.UrlReferrer.Authority.Contains(_requestCtx.Url.Authority))
                        filterContext.Result = AuthProvider.SignOutAndRedirect();
                }
                else
                    filterContext.Result = AuthProvider.SignOutAndRedirect();
            }

            base.OnActionExecuting(filterContext);
        }
    }
}