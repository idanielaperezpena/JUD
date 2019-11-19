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
           

            return Listado();
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
        public CreditoComplementarioIndexViewModel Listado()
        {
            var _viewModel= new CreditoComplementarioIndexViewModel();
            try
            {
                var _listaCC=UoW.CreditoComplementario.ObtenerListado(new CreditoComplementario());
                foreach (CreditoComplementario _cc in _listaCC)
                {
                    var _temp = new CreditoComplementarioIndexListadoViewModel();
                    var _CI = UoW.CreditoInicial.ObtenerEntidad(new CreditoInicial {
                        CI_IDCreditoInicial =_cc.CC_IDCreditoInicial
                    });
                    var _ciudadano = UoW.Ciudadano.ObtenerEntidad(new Ciudadano {
                        CIU_IDCiudadano = _CI.CI_IDCiudadano
                    });
                    _temp.CC_IDCreditoComplementario = _cc.CC_IDCreditoComplementario;
                    _temp.CC_IDCreditoInicial = _CI.CI_IDCreditoInicial.Value;
                    _temp.CI_CURP = _ciudadano.CIU_CURP;
                    _temp.NombreCiudadano=_ciudadano.CIU_Nombre+" "+_ciudadano.CIU_ApellidoPaterno+" "+_ciudadano.CIU_ApellidoMaterno+".";
                    _temp.CC_FechaSolicitud = _cc.CC_FechaSolicitud.ToShortDateString();
                    _temp.CC_FolioSolicitud = _cc.CC_FolioSolicitud;
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
