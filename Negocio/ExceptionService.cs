using Entidades;
using Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Negocio
{
    public class ExceptionService : ServiceBase
    {
        public ExceptionService(ModelStateDictionary modelState) : base(modelState) { }

        public void Index(ExceptionIndexViewModel viewModel)
        {
            try
            {
                var _listado = UoW.ErrorLog.ObtenerListado(new ErrorLog
                {
                    ERR_FechaInicio = viewModel.ERR_Fecha.FechaInicio,
                    ERR_FechaFin = viewModel.ERR_Fecha.FechaFin,
                    ERR_Folio = viewModel.ERR_Folio
                });

                viewModel.PaginarListado(_listado);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }

        public ErrorLog Details(string e)
        {
            try
            {
                return UoW.ErrorLog.ObtenerEntidad(new ErrorLog { ERR_Id = UoW.Encriptador.Decode<int?>(e) });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return null;
        }

        public async Task<ExceptionLogViewModel> Log(HttpServerUtilityBase server, ErrorLog error, Usuario usuario)
        {
            var _resultado = new ExceptionLogViewModel();

            try
            {
                if (error != null)
                {
                    if (usuario != null)
                        error.USU_Id = usuario.USU_Id;

                    var _log = UoW.ErrorLog.Alta(error);

                    if (_log != null)
                    {
                        _resultado.MensajeView = _log.MensajeView;

                        var _body = server.GetNotificacion(EnumNotificacionEmail.Errores);

                        _body = _body.Replace("@Folio@", _log.ERR_Folio)
                            .Replace("@Fecha@", _log.ERR_Fecha.ParseTo<string>("dd/MM/yyyy HH:mm:ss"))
                            .Replace("@Usuario@", _log.USU_Nombre)
                            .Replace("@SessionId@", _log.ERR_SessionID)
                            .Replace("@RemoteAddress@", _log.ERR_RemoteAddr)
                            .Replace("@RequestMethod@", _log.ERR_RequestMethod)
                            .Replace("@Url@", _log.ERR_Url)
                            .Replace("@UserAgent@", _log.ERR_UserAgent)
                            .Replace("@QueryString@", _log.ERR_Query)
                            .Replace("@Form@", _log.ERR_Form)
                            .Replace("@AllHttp@", _log.ERR_AllHttp)
                            .Replace("@Type@", _log.ERR_Type)
                            .Replace("@Message@", _log.ERR_Message)
                            .Replace("@TargetSite@", _log.ERR_TargetSite)
                            .Replace("@StackTrace@", _log.ERR_StackTrace);

                        var _emailRes = await UoW.EmailSender.Enviar(_log.SoporteAsunto, _body, _log.SoporteEmail);

                        if (_emailRes.StatusCode != HttpStatusCode.Accepted)
                            ModelState.AddModelError(string.Empty, _emailRes.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return _resultado;
        }
    }
}

