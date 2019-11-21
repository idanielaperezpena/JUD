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
        public CreditoComplementarioService(ModelStateDictionary modelState) : base(modelState)
        {
        }

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
                    _temp.CC_FechaSolicitud = _cc.CC_FechaSolicitud.ToString();
                    _temp.CC_FolioSolicitud = _cc.CC_FolioSolicitud;
                    _temp.CI_FolioSolicitud = _CI.CI_FolioSolicitud;

                    var estatus = EstatusCC(_cc.CC_IDCreditoComplementario);

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
