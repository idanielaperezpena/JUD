using Entidades;
using Negocio.ViewModels.CreditoComplementario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Mvc;

namespace Negocio
{
    public class CreditoComplementarioService : ServiceBase
    {
        public CreditoInicialService _serviceCI;

        public CreditoComplementarioService(ModelStateDictionary modelState) : base(modelState)
        {
            _serviceCI = new CreditoInicialService(modelState, 0);
        }

        public CreditoComplementarioService(ModelStateDictionary modelState, int opc) : base(modelState){}

        #region ViewModels
        public CreditoComplementarioIndexViewModel Index()
        {
            var _viewModel = new CreditoComplementarioIndexViewModel();
            try
            {
                var _listaCC = Listado();

                foreach (CreditoComplementario _cc in _listaCC)
                {

                    var _temp = new CreditoComplementarioIndexListadoViewModel();
                    var _CI = UoW.CreditoInicial.ObtenerEntidad(new CreditoInicial
                    {
                        CI_IDCreditoInicial = _cc.CC_IDCreditoInicial
                    });
                    var _ciudadano = UoW.Ciudadano.ObtenerEntidad(new Ciudadano
                    {
                        CIU_IDCiudadano = _CI.CI_IDCiudadano
                    });
                    _temp.CC_IDCreditoComplementario = _cc.CC_IDCreditoComplementario;
                    _temp.CC_IDCreditoInicial = _CI.CI_IDCreditoInicial.Value;
                    _temp.CI_CURP = _ciudadano.CIU_CURP;
                    _temp.NombreCiudadano = _ciudadano.CIU_Nombre + " " + _ciudadano.CIU_ApellidoPaterno + " " + _ciudadano.CIU_ApellidoMaterno + ".";
                    _temp.CC_FechaSolicitud = _cc.CC_FechaSolicitud.ToShortDateString().ToString();
                    _temp.CC_FolioSolicitud = _cc.CC_FolioSolicitud;
                    _temp.CI_FolioSolicitud = _CI.CI_FolioSolicitud;

                    var estatus = EstatusCC(_cc.CC_IDCreditoComplementario);

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

                    var _temp = new CreditoComplementarioIndexCIListadoViewModel();

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

        public CreditoComplementarioInsertarViewModel Insertar(int IDCreditoInicial, int? IDCreditoComplementario)
        {
            var _viewModel = new CreditoComplementarioInsertarViewModel();
            if (IDCreditoComplementario != null)
            {
                int _id = IDCreditoComplementario.GetValueOrDefault();
                try
                {
                    ObtenerCreditoComplementario(_viewModel, _id);
                    return _viewModel;

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message + "Service : Insertar");
                }
            }

            _viewModel.CC_IDCreditoInicial = IDCreditoInicial;
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
        public List<CreditoComplementario>  Listado()
        {
            try
            {
                return UoW.CreditoComplementario.ObtenerListado(new CreditoComplementario ());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado");
            }

            return new List<CreditoComplementario>();
        }

        public List<CreditoComplementario> Listado_CI(int ID)
        {
            try
            {
                return UoW.CreditoComplementario.ObtenerListadoCI(new CreditoComplementario { CC_IDCreditoInicial = ID });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado CI");
            }

            return new List<CreditoComplementario>();
        }

        public Principal EstatusCC(int? ID)
        {
            try
            {
                return UoW.Principal.ObetenerEstatusCC(new CreditoComplementario { CC_IDCreditoComplementario = ID });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado");
            }

            return new Principal();
        }

        public CreditoComplementarioInsertarViewModel ObtenerCreditoComplementario(CreditoComplementarioInsertarViewModel _viewModel, int IDCreditoComplementario)
        {
            try
            {
                var _entidad = UoW.CreditoComplementario.ObtenerEntidad(new CreditoComplementario
                {
                    CC_IDCreditoComplementario = IDCreditoComplementario
                });
                if (_entidad != null)
                {
                    _viewModel.CC_IDCreditoComplementario   = _entidad.CC_IDCreditoComplementario;
                    _viewModel.CC_IDCreditoInicial          = _entidad.CC_IDCreditoInicial;
                    _viewModel.CC_FolioSolicitud            = _entidad.CC_FolioSolicitud;
                    _viewModel.CC_FechaCaptura              = _entidad.CC_FechaCaptura;
                    _viewModel.CC_FechaSolicitud            = _entidad.CC_FechaSolicitud;
                    _viewModel.CC_NoSesionComite            = _entidad.CC_NoSesionComite;
                    _viewModel.CC_IDMejoramiento            = _entidad.CC_IDMejoramiento;
                    _viewModel.CC_Ingreso                   = _entidad.CC_Ingreso;
                }
                return _viewModel;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : ObtenerCreditoComplementario");
            }
            return _viewModel;
        }
        #endregion

        #region Insertar Editar
        public void EditCreditoComplementario(CreditoComplementarioInsertarViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.CreditoComplementario.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.CreditoComplementario.Alta(new CreditoComplementario
                        {
                            CC_IDCreditoComplementario =    _viewModel.CC_IDCreditoComplementario,
                            CC_IDCreditoInicial        =    _viewModel.CC_IDCreditoInicial       ,
                            CC_FolioSolicitud          =    _viewModel.CC_FolioSolicitud           ,
                            CC_FechaCaptura            =    _viewModel.CC_FechaCaptura           ,
                            CC_FechaSolicitud          =    _viewModel.CC_FechaSolicitud         ,
                            CC_NoSesionComite          =    _viewModel.CC_NoSesionComite         ,
                            CC_IDMejoramiento          =    _viewModel.CC_IDMejoramiento         ,
                            CC_Ingreso                 =    _viewModel.CC_Ingreso                

                        });
                        UoW.CreditoComplementario.TxScope.Complete();
                    }

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : EditCreditoComplementario");
            }
        }
        #endregion


    }
}
