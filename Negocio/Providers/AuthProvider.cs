using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

public static class AuthProvider
{
    public static string LoginUrl => FormsAuthentication.LoginUrl;

    public static ActionResult SetAuthCookieAndRedirect(this BaseController controller, Usuario usuario)
    {
        usuario.UrlDefault = controller.Url.Action(usuario.MDL_DefaultAction, usuario.MDL_DefaultController, new { m = controller.Encriptador.Encode(usuario.MDL_Default) });
        controller.Response.SetAuthCookie(usuario);

        return new RedirectResult(usuario.UrlDefault);
    }

    public static ActionResult SignOutAndRedirect()
    {
        SignOut();

        return new RedirectResult(LoginUrl);
    }

    private static void SetAuthCookie(this HttpResponseBase response, Usuario usuario)
    {
        var _authCookie = FormsAuthentication.GetAuthCookie(usuario.USU_Id.ParseTo<string>(), false);
        var _ticket = FormsAuthentication.Decrypt(_authCookie.Value);
        var _newTicket = new FormsAuthenticationTicket(_ticket.Version, _ticket.Name, _ticket.IssueDate, _ticket.Expiration, _ticket.IsPersistent, usuario.ToJSON());
        
        _authCookie.Value = FormsAuthentication.Encrypt(_newTicket);
        response.Cookies.Add(_authCookie);
    }

    private static void SignOut()
    {
        SessionProvider.Abandon();
        FormsAuthentication.SignOut();
    }
}