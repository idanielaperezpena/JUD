using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Models.Filters
{
    public class ExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Controller.TempData["_error"] = new ErrorLog
            {
                Ex = filterContext.Exception,
                ERR_SessionID = filterContext.HttpContext.Session.SessionID,
                ERR_RemoteAddr = filterContext.HttpContext.Request.ServerVariables["REMOTE_ADDR"].ToString(),
                ERR_AllHttp = filterContext.HttpContext.Request.ServerVariables["ALL_HTTP"].ToString(),
                ERR_UserAgent = filterContext.HttpContext.Request.UserAgent,
                ERR_RequestMethod = filterContext.HttpContext.Request.ServerVariables["REQUEST_METHOD"].ToString(),
                ERR_Url = filterContext.HttpContext.Request.Url.ToString(),
                ERR_Query = filterContext.HttpContext.Request.Url.Query,
                ERR_Form = filterContext.HttpContext.Request.Form.ToString(),
                ERR_Type = filterContext.Exception.GetType().ToString(),
                ERR_Message = filterContext.Exception.Message,
                ERR_TargetSite = filterContext.Exception.TargetSite.ToString(),
                ERR_StackTrace = filterContext.Exception.StackTrace,
            };

            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("~/Exception/Log");
        }
    }
}