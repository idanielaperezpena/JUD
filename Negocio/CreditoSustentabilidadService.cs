using Entidades;
using Negocio.ViewModels.CreditoSustentabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Mvc;

namespace Negocio
{
    public class CreditoSustentabilidadService:ServiceBase
    {
        public CreditoSustentabilidadService(ModelStateDictionary modelState) : base(modelState)
        {
        }

        #region ViewModels
        public CreditoSustentabilidadIndexViewModel Index()
        {
            var _viewModel = new CreditoSustentabilidadIndexViewModel();
            try
            {
                var _listaCS = Listado(); 
                foreach (CreditoSustentabilidad _cs in _listaCS)
                {

                    var _temp = new CreditoSustentabilidadIndexListadoViewModel();
                    var _CI = UoW.CreditoInicial.ObtenerEntidad(new CreditoInicial
                    {
                        CI_IDCreditoInicial = _cs.CS_IDCreditoInicial
                    });
                    var _ciudadano = UoW.Ciudadano.ObtenerEntidad(new Ciudadano
                    {
                        CIU_IDCiudadano = _CI.CI_IDCiudadano
                    });
                    _temp.CS_IDCreditoSustentabilidad = _cs.CS_IDCreditoSustentabilidad;
                    _temp.CS_IDCreditoInicial = _CI.CI_IDCreditoInicial.Value;
                    _temp.CI_CURP = _ciudadano.CIU_CURP;
                    _temp.NombreCiudadano = _ciudadano.CIU_Nombre + " " + _ciudadano.CIU_ApellidoPaterno + " " + _ciudadano.CIU_ApellidoMaterno + ".";
                    _temp.CS_FechaSolicitud = _cs.CS_FechaSolicitud.ToString();
                    _temp.CS_FolioSolicitud = _cs.CS_FolioSolicitud;
                    _temp.CI_FolioSolicitud = _CI.CI_FolioSolicitud;

                    var estatus = EstatusCS(_cs.CS_IDCreditoSustentabilidad);

                    var cadena = estatus.Resultado.Split('-');

                    _temp.ImgDS = new String[2];
                    switch (cadena[0])
                    {
                        case "0":
                            _temp.ImgDS[0] = "darkgray";
                            _temp.ImgDS[1] = "fas fa-folder-minus";
                            break;
                        case "1":
                            _temp.ImgDS[0] = "orange";
                            _temp.ImgDS[1] = "fas fa-hourglass-half";
                            break;
                        case "2":
                            _temp.ImgDS[0] = "forestgreen";
                            _temp.ImgDS[1] = "fas fa-check-square";
                            break;
                        case "4":
                            _temp.ImgDS[0] = "red";
                            _temp.ImgDS[1] = "fas fa-times-circle";
                            break;
                        default:
                            _temp.ImgDS[0] = "red";
                            _temp.ImgDS[1] = "fas fa-times-circle";
                            break;
                    }

                    _temp.ImgDT = new String[2];
                    switch (cadena[1])
                    {
                        case "0":
                            _temp.ImgDT[0] = "darkgray";
                            _temp.ImgDT[1] = "fas fa-folder-minus";
                            break;
                        case "1":
                            _temp.ImgDT[0] = "orange";
                            _temp.ImgDT[1] = "fas fa-hourglass-half";
                            break;
                        case "2":
                            _temp.ImgDT[0] = "forestgreen";
                            _temp.ImgDT[1] = "fas fa-check-square";
                            break;
                        case "4":
                            _temp.ImgDT[0] = "red";
                            _temp.ImgDT[1] = "fas fa-times-circle";
                            break;
                        default:
                            _temp.ImgDT[0] = "red";
                            _temp.ImgDT[1] = "fas fa-times-circle";
                            break;
                    }


                    _temp.ImgDJ = new String[2];
                    switch (cadena[2])
                    {
                        case "0":
                            _temp.ImgDJ[0] = "darkgray";
                            _temp.ImgDJ[1] = "fas fa-folder-minus";
                            break;
                        case "1":
                            _temp.ImgDJ[0] = "orange";
                            _temp.ImgDJ[1] = "fas fa-hourglass-half";
                            break;
                        case "2":
                            _temp.ImgDJ[0] = "forestgreen";
                            _temp.ImgDJ[1] = "fas fa-check-square";
                            break;
                        case "4":
                            _temp.ImgDJ[0] = "red";
                            _temp.ImgDJ[1] = "fas fa-times-circle";
                            break;
                        default:
                            _temp.ImgDJ[0] = "red";
                            _temp.ImgDJ[1] = "fas fa-times-circle";
                            break;
                    }

                    _temp.ImgDF = new String[2];
                    switch (cadena[3])
                    {
                        case "0":
                            _temp.ImgDF[0] = "darkgray";
                            _temp.ImgDF[1] = "fas fa-folder-minus";
                            break;
                        case "1":
                            _temp.ImgDF[0] = "orange";
                            _temp.ImgDF[1] = "fas fa-hourglass-half";
                            break;
                        case "2":
                            _temp.ImgDF[0] = "forestgreen";
                            _temp.ImgDF[1] = "fas fa-check-square";
                            break;
                        case "4":
                            _temp.ImgDF[0] = "red";
                            _temp.ImgDF[1] = "fas fa-times-circle";
                            break;
                        default:
                            _temp.ImgDF[0] = "red";
                            _temp.ImgDF[1] = "fas fa-times-circle";
                            break;
                    }


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

        public CreditoSustentabilidadInsertarViewModel Insertar(int IDCreditoInicial, int? IDCreditoSustentabilidad)
        {
            var _viewModel = new CreditoSustentabilidadInsertarViewModel();
            if (IDCreditoSustentabilidad != null)
            {
                int _id = IDCreditoSustentabilidad.GetValueOrDefault();
                try
                {
                    ObtenerCreditoSustentabilidad(_viewModel, _id);
                    return _viewModel;

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message + "Service : Insertar");
                }
            }

            _viewModel.CS_IDCreditoInicial = IDCreditoInicial;
            return _viewModel;

        }
        #endregion

        #region Consultas
        //Index
        public List<CreditoSustentabilidad> Listado()
        {
            
            try
            {
                return UoW.CreditoSustentabilidad.ObtenerListado(new CreditoSustentabilidad());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado");
            }

            return new List<CreditoSustentabilidad>();
        }

        public Principal EstatusCS(int? ID)
        {
            try
            {
                return UoW.Principal.ObetenerEstatusCS(new CreditoSustentabilidad { CS_IDCreditoSustentabilidad = ID });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado");
            }

            return new Principal();
        }

        public CreditoSustentabilidadInsertarViewModel ObtenerCreditoSustentabilidad(CreditoSustentabilidadInsertarViewModel _viewModel, int IDCreditoSustentabilidad)
        {
            try
            {
                var _entidad = UoW.CreditoSustentabilidad.ObtenerEntidad(new CreditoSustentabilidad
                {
                    CS_IDCreditoSustentabilidad = IDCreditoSustentabilidad
                });
                if (_entidad != null)
                {
                    _viewModel.CS_IDCreditoSustentabilidad = _entidad.CS_IDCreditoSustentabilidad;
                    _viewModel.CS_IDCreditoInicial = _entidad.CS_IDCreditoInicial;
                    _viewModel.CS_FolioSolicitud = _entidad.CS_FolioSolicitud;
                    _viewModel.CS_FechaCaptura = _entidad.CS_FechaCaptura;
                    _viewModel.CS_FechaSolicitud = _entidad.CS_FechaSolicitud;
                 
                }
                return _viewModel;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : ObtenerCreditoSustentabilidad");
            }
            return _viewModel;
        }
        #endregion

        #region Insertar Editar
        public void EditCreditoSustentabilidad(CreditoSustentabilidadInsertarViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.CreditoSustentabilidad.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.CreditoSustentabilidad.Alta(new CreditoSustentabilidad
                        {
                            CS_IDCreditoSustentabilidad = _viewModel.CS_IDCreditoSustentabilidad,
                            CS_IDCreditoInicial = _viewModel.CS_IDCreditoInicial,
                            CS_FolioSolicitud = _viewModel.CS_FolioSolicitud,
                            CS_FechaCaptura = _viewModel.CS_FechaCaptura,
                            CS_FechaSolicitud = _viewModel.CS_FechaSolicitud
                            

                        });
                        UoW.CreditoSustentabilidad.TxScope.Complete();
                    }

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : EditCreditoSustentabilidad");
            }
        }
        #endregion
    }
}
