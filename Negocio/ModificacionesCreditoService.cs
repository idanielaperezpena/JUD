using Entidades;
using Negocio.ViewModels.ModificacionesCredito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Mvc;

namespace Negocio
{
   public class ModificacionesCreditoService : ServiceBase
    {
        public ModificacionesCreditoService(ModelStateDictionary modelState) : base(modelState)
        {
        }
        #region ViewModels
        public ModificacionesCreditoIndexViewModel Index()
        {

            return Listado();
        }

        public ModificacionesCreditoInsertarViewModel Insertar(int IDCreditoInicial, int? IDModificacionesCredito)
        {
            var _viewModel = new ModificacionesCreditoInsertarViewModel();
            _viewModel.Problematica = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_20_Problematica", ID =0 }).SelectListado();
            _viewModel.TipoTramite = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_42_TipoTramite", ID = 0 }).SelectListado();
            _viewModel.Dictaminacion = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_54_Dictaminacion", ID = 0 }).SelectListado();

            if (IDModificacionesCredito != null)
            {
                int _id = IDModificacionesCredito.GetValueOrDefault();
                try
                {
                    ObtenerModificacionesCredito(_viewModel, _id);
                    return _viewModel;

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message + "Service : Insertar");
                }
            }

            _viewModel.MC_IDCreditoInicial = IDCreditoInicial;
            return _viewModel;

        }
        #endregion

        #region Consultas
        //Index
        public ModificacionesCreditoIndexViewModel Listado()
        {
            var _viewModel = new ModificacionesCreditoIndexViewModel();
            try
            {
                var _listaMC = UoW.ModificacionesCredito.ObtenerListado(new ModificacionesCredito());
                foreach (ModificacionesCredito _mc in _listaMC)
                {

                    var _temp = new ModificacionesCreditoIndexListadoViewModel();
                    var _CI = UoW.CreditoInicial.ObtenerEntidad(new CreditoInicial
                    {
                        CI_IDCreditoInicial = _mc.MC_IDCreditoInicial
                    });
                    var _ciudadano = UoW.Ciudadano.ObtenerEntidad(new Ciudadano
                    {
                        CIU_IDCiudadano = _CI.CI_IDCiudadano
                    });
                    _temp.MC_IDModificacionesCredito = _mc.MC_IDModificacionesCredito;
                    _temp.MC_IDCreditoInicial = _CI.CI_IDCreditoInicial.Value;
                    _temp.CI_CURP = _ciudadano.CIU_CURP;
                    _temp.NombreCiudadano = _ciudadano.CIU_Nombre + " " + _ciudadano.CIU_ApellidoPaterno + " " + _ciudadano.CIU_ApellidoMaterno + ".";
                    _temp.MC_FechaSolicitud = _mc.MC_FechaSolicitud.ToString();
                    _temp.MC_FolioSolicitud = _mc.MC_FolioSolicitud;
                    _temp.CI_FolioSolicitud = _CI.CI_FolioSolicitud;
                    _viewModel.Listado.Add(_temp);

                }
                return _viewModel;

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado");
            }

            return _viewModel;
        }

        public ModificacionesCreditoInsertarViewModel ObtenerModificacionesCredito(ModificacionesCreditoInsertarViewModel _viewModel, int IDModificacionesCredito)
        {
            try
            {
                var _entidad = UoW.ModificacionesCredito.ObtenerEntidad(new ModificacionesCredito
                {
                    MC_IDModificacionesCredito = IDModificacionesCredito
                });
                if (_entidad != null)
                {
                    _viewModel.MC_IDModificacionesCredito = _entidad.MC_IDModificacionesCredito;
                    _viewModel.MC_IDCreditoInicial = _entidad.MC_IDCreditoInicial;
                    _viewModel.MC_FolioSolicitud = _entidad.MC_FolioSolicitud;
                    _viewModel.MC_FechaCaptura = _entidad.MC_FechaCaptura;
                    _viewModel.MC_FechaSolicitud = _entidad.MC_FechaSolicitud;
                    _viewModel.MC_IDProblema = _entidad.MC_IDProblema;
                    _viewModel.MC_IDCiudadano = _entidad.MC_IDCiudadano;
                    _viewModel.MC_Procedencia = _entidad.MC_Procedencia;
                    _viewModel.MC_IDTipoTramite = _entidad.MC_IDTipoTramite;
                    _viewModel.MC_Ingreso = _entidad.MC_Ingreso;

                }
                return _viewModel;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : ObtenerModificacionesCredito");
            }
            return _viewModel;
        }
        #endregion

        #region Insertar Editar
        public void EditModificacionesCredito(ModificacionesCreditoInsertarViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.ModificacionesCredito.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.ModificacionesCredito.Alta(new ModificacionesCredito
                        {
                            MC_IDModificacionesCredito = _viewModel.MC_IDModificacionesCredito,
                            MC_IDCreditoInicial = _viewModel.MC_IDCreditoInicial,
                            MC_FolioSolicitud = _viewModel.MC_FolioSolicitud,
                            MC_FechaCaptura = _viewModel.MC_FechaCaptura,
                            MC_FechaSolicitud = _viewModel.MC_FechaSolicitud,
                            MC_IDProblema = _viewModel.MC_IDProblema,
                            MC_IDCiudadano = _viewModel.MC_IDCiudadano,
                            MC_Procedencia = _viewModel.MC_Procedencia,
                            MC_IDTipoTramite=_viewModel.MC_IDTipoTramite,
                            MC_Ingreso =_viewModel.MC_Ingreso

                        });
                        UoW.ModificacionesCredito.TxScope.Complete();
                    }

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : EditModificacionesCredito");
            }
        }
        #endregion
    }
}
