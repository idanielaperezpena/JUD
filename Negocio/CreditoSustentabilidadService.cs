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
        public CreditoInicialService _serviceCI;
        public CreditoSustentabilidadService(ModelStateDictionary modelState) : base(modelState)
        {
            _serviceCI = new CreditoInicialService(modelState, 0);
        }

        public CreditoSustentabilidadService(ModelStateDictionary modelState,int OPC) : base(modelState)
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
                    _temp.CS_FechaSolicitud = _cs.CS_FechaSolicitud.ToShortDateString();
                    _temp.CS_FolioSolicitud = _cs.CS_FolioSolicitud;
                    _temp.CI_FolioSolicitud = _CI.CI_FolioSolicitud;

                    var estatus = EstatusCS(_cs.CS_IDCreditoSustentabilidad);

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

                    var _temp = new CreditoSustentabilidadIndexCIListadoViewModel();

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

        public List<CreditoSustentabilidad> Listado_CI(int ID)
        {
            try
            {
                return UoW.CreditoSustentabilidad.ObtenerListadoCI(new CreditoSustentabilidad { CS_IDCreditoInicial = ID });
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
