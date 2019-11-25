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
        public CreditoInicialService _serviceCI;

        public ModificacionesCreditoService(ModelStateDictionary modelState) : base(modelState)
        {
            _serviceCI = new CreditoInicialService(modelState, 0);

        }

        public ModificacionesCreditoService(ModelStateDictionary modelState, int opc) : base(modelState)
        {
        }
        #region ViewModels
        public ModificacionesCreditoIndexViewModel Index()
        {
            var _viewModel = new ModificacionesCreditoIndexViewModel();
            try
            {
                var _listaMC =  Listado(); 
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
                    _temp.MC_FechaSolicitud = _mc.MC_FechaSolicitud.ToShortDateString().ToString();
                    _temp.MC_FolioSolicitud = _mc.MC_FolioSolicitud;
                    _temp.CI_FolioSolicitud = _CI.CI_FolioSolicitud;

                    var estatus = EstatusMC(_mc.MC_IDModificacionesCredito);

                    var cadena = estatus.Resultado.Split('-');

                    _temp.ImgDS = ImagenIndex(cadena[0]);
                    _temp.ImgDT = ImagenIndex(cadena[1]);
                    _temp.ImgDJ = ImagenIndex(cadena[2]);
                    _temp.ImgDF = ImagenIndex(cadena[3]);

                    _viewModel.Listado.Add(_temp);

                }


                var _listaCI = _serviceCI.Listado();

                foreach (CreditoInicial _cat in _listaCI)
                {
                    var _entidadCiudadano = UoW.Ciudadano.ObtenerEntidad(new Ciudadano
                    {
                        CIU_IDCiudadano = _cat.CI_IDCiudadano
                    });

                    var _temp = new ModificacionesCreditoIndexCIListadoViewModel();

                    _temp.CI_ID = _cat.CI_IDCreditoInicial;
                    _temp.CI_FolioSolicitud = _cat.CI_FolioSolicitud;
                    _temp.CURPCiudadano = _entidadCiudadano.CIU_CURP;
                    _temp.NombreCiudadano = _entidadCiudadano.CIU_Nombre + " " + _entidadCiudadano.CIU_ApellidoPaterno + " " + _entidadCiudadano.CIU_ApellidoMaterno;
                    _temp.CI_FechaSolicitud = _cat.CI_FechaSolicitud.Date.ToShortDateString().ToString();
                    _temp.CI_IDSeccionElectoral = _cat.CI_IDSeccionElectoral;

                    var estatus = _serviceCI.EstatusCI(_cat.CI_IDCreditoInicial);

                    var cadena = estatus.Resultado.Split('-');
                    if (cadena[3] == "2")
                    {
                        _viewModel.ListadoCI.Add(_temp);
                    }

                }

                return _viewModel;

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado");
            }

            return _viewModel;            
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

        public String[] ImagenIndex(string cadena)
        {
            String[] Imagen = new String[2];
            switch (cadena)
            {
                case "0":
                    Imagen[0] = "darkgray";
                    Imagen[1] = "fas fa-folder-minus";
                    break;
                case "1":
                    Imagen[0] = "orange";
                    Imagen[1] = "fas fa-hourglass-half";
                    break;
                case "2":
                    Imagen[0] = "forestgreen";
                    Imagen[1] = "fas fa-check-square";
                    break;
                case "4":
                    Imagen[0] = "red";
                    Imagen[1] = "fas fa-times-circle";
                    break;
                default:
                    Imagen[0] = "red";
                    Imagen[1] = "fas fa-times-circle";
                    break;
            }

            return Imagen;
        }
        #endregion

        #region Consultas
        //Index
        public List<ModificacionesCredito> Listado()
        {
            try
            {
                return UoW.ModificacionesCredito.ObtenerListado(new ModificacionesCredito());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado");
            }

            return new List<ModificacionesCredito>();
        }

        public List<ModificacionesCredito> Listado_CI(int ID)
        {
            try
            {
                return UoW.ModificacionesCredito.ObtenerListadoCI(new ModificacionesCredito { MC_IDCreditoInicial = ID });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado");
            }

            return new List<ModificacionesCredito>();
        }

        public Principal EstatusMC(int? ID)
        {
            try
            {
                return UoW.Principal.ObetenerEstatusMC(new ModificacionesCredito { MC_IDModificacionesCredito = ID });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado");
            }

            return new Principal();
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
