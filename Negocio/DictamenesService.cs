using Entidades;
using Negocio.ViewModels.DictamenFinanciero;
using Negocio.ViewModels.DictamenJuridico;
using Negocio.ViewModels.DictamenSocial;
using Negocio.ViewModels.DictamenTecnico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Mvc;

namespace Negocio
{
    public class DictamenesService : ServiceBase
    {
        public DictamenesService(ModelStateDictionary modelState) : base(modelState){}

        #region ViewModels
        public DictamenJuridicoViewModel InsertarDictamenJuridico(string TipoCredito, int ID)
        {

            var _viewModel = new DictamenJuridicoViewModel();
            _viewModel.IDCredito = ID;
            //Listas
            _viewModel.TipoPropiedad = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_TipoPropiedad", ID = 0 }).SelectListado();
            _viewModel.TipoPosesion = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_Posesion", ID = 0 }).SelectListado();
            _viewModel.Dictaminacion = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_54_Dictaminacion", ID = 0 }).SelectListado();
           
           
              
                switch (TipoCredito)
                {
                    case "CI":
                        ObtenerCIDictamenJuridico(_viewModel,ID);
                        break;
                        //case "CC":
                        //    ObtenerCCDictamenJuridico(_viewModel);
                        //    break;
                        //case "CS":
                        //    ObtenerCSDictamenJuridico(_viewModel);
                        //    break;
                        //case "MC":
                        //    ObtenerMCDictamenJuridico(_viewModel);
                        //    break;
                }
            
           
            return _viewModel;
        }

        public DictamenSocialViewModel InsertarDictamenSocial(string TipoCredito,int ID )
        {
            var _viewModel = new DictamenSocialViewModel();
            _viewModel.IDCredito = ID;
            //Listas
            
            _viewModel.TipoPredio = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_26_TipoPredio", ID = 0 }).SelectListado();
            _viewModel.CaracteristicasPredio = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_27_CaracteristicaPredio", ID = 0 }).SelectListado();
            _viewModel.ServicioAgua = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_21_ServicioAgua", ID = 0 }).SelectListado();
            _viewModel.ServicioDrenaje = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_22_Drenaje", ID = 0 }).SelectListado();
            _viewModel.ServicioElectrico = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_23_EnergiaElectrica", ID = 0 }).SelectListado();
            _viewModel.Hacinamiento = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_24_Hacinamiento", ID = 0 }).SelectListado();
            _viewModel.Insalubridad = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_25_Insalubridad", ID = 0 }).SelectListado();
            _viewModel.Vulnerabilidad = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_63_GruposVulnerables", ID = 0 }).SelectListado();
            _viewModel.Dictaminacion = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_54_Dictaminacion", ID = 0 }).SelectListado();

            
                
                switch (TipoCredito)
                {
                    case "CI":
                        ObtenerCIDictamenSocial(_viewModel,ID);
                        break;
                        //case "CC":
                        //    ObtenerCCDictamenJuridico(_viewModel);
                        //    break;
                        //case "CS":
                        //    ObtenerCSDictamenJuridico(_viewModel);
                        //    break;
                        //case "MC":
                        //    ObtenerMCDictamenJuridico(_viewModel);
                        //    break;
                }
            
            return _viewModel;
         
    }

        public DictamenTecnicoViewModel InsertarDictamenTecnico(string TipoCredito,int ID )
        {
            var _viewModel = new DictamenTecnicoViewModel();
            _viewModel.IDCredito = ID;
            //Listas
            _viewModel.AsesoriaTecnica = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_46_AsesoriaTecnica", ID = 0 }).SelectListado();
            _viewModel.Dictaminacion = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_54_Dictaminacion", ID = 0 }).SelectListado();
           
                switch (TipoCredito)
                {
                    case "CI":
                        ObtenerCIDictamenTecnico(_viewModel, ID);
                        break;
                        //case "CC":
                        //    ObtenerCCDictamenJuridico(_viewModel);
                        //    break;
                        //case "CS":
                        //    ObtenerCSDictamenJuridico(_viewModel);
                        //    break;
                        //case "MC":
                        //    ObtenerMCDictamenJuridico(_viewModel);
                        //    break;
                }
            
            return _viewModel;
        }

        public DictamenFinancieroViewModel InsertarDictamenFinanciero(string TipoCredito,int ID )
        {
            var _viewModel = new DictamenFinancieroViewModel();
            _viewModel.IDCredito = ID;
            //Listas
            _viewModel.Dictaminacion = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_54_Dictaminacion", ID = 0 }).SelectListado();
           
                switch (TipoCredito)
                {
                    case "CI":
                        ObtenerCIDictamenFinanciero(_viewModel, ID);
                        break;
                        //case "CC":
                        //    ObtenerCCDictamenJuridico(_viewModel);
                        //    break;
                        //case "CS":
                        //    ObtenerCSDictamenJuridico(_viewModel);
                        //    break;
                        //case "MC":
                        //    ObtenerMCDictamenJuridico(_viewModel);
                        //    break;
                }
            
            return _viewModel;
        }
        #endregion
        #region Consultas
            #region Credito Inicial
            public DictamenJuridicoViewModel ObtenerCIDictamenJuridico(DictamenJuridicoViewModel _viewModel, int _IDCreditoInicial )
            {
                try
                {
                    var _entidad = UoW.CiDictamenJuridico.ObtenerEntidad(new CIDictamenJuridico
                    {
                        CIDJ_IDCreditoInicial = _IDCreditoInicial
                    });

                    if (_entidad != null)
                    {
                        _viewModel.TipoCredito = "CI";
                        _viewModel.IDDictamenJuridico = _entidad.CIDJ_IDDictamenJuridico;
                        _viewModel.IDCredito = _entidad.CIDJ_IDCreditoInicial;
                        _viewModel.IDPropiedad = _entidad.CIDJ_IDPropiedad;
                        _viewModel.IDPosesion = _entidad.CIDJ_IDPosesion;
                        _viewModel.NoDocumentoPropiedad = _entidad.CIDJ_NoDocumentoPropiedad;
                        _viewModel.FechaDocumento = _entidad.CIDJ_FechaDocumento;
                        _viewModel.Anuencia = _entidad.CIDJ_Anuencia;
                        _viewModel.SuperficieLote = _entidad.CIDJ_SuperficieLote;
                        _viewModel.DatosLibro = _entidad.CIDJ_DatosLibro;
                        _viewModel.FolioDocumento = _entidad.CIDJ_FolioDocumento;
                        _viewModel.Observaciones = _entidad.CIDJ_Observaciones;
                        _viewModel.Procedencia = _entidad.CIDJ_Procedencia;
                        _viewModel.MotivosProcedencia = _entidad.CIDJ_MotivosProcedencia;
                        _viewModel.FechaDictaminacion = _entidad.CIDJ_FechaDictaminacion;
                        _viewModel.UsuarioDominio = _entidad.CIDJ_UsuarioDominio;
                        return _viewModel;
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return _viewModel;
            }

            public DictamenSocialViewModel ObtenerCIDictamenSocial(DictamenSocialViewModel _viewModel, int _IDCreditoInicial)
            {
                try
                {
                    var _entidad = UoW.CiDictamenSocial.ObtenerEntidad(new CIDictamenSocial
                    {
                        CIDS_IDCreditoInicial = _IDCreditoInicial
                    });

                    if (_entidad != null)
                    {
                        _viewModel.TipoCredito = "CI";
                        _viewModel.IDDictamenSocial = _entidad.CIDS_IDDictamenSocial;
                        _viewModel.IDCredito = _entidad.CIDS_IDCreditoInicial;
                        _viewModel.IDTipoPredio = _entidad.CIDS_IDTipoPredio;
                        _viewModel.IDCaracteristicaPredio = _entidad.CIDS_IDCaracteristicasPredio;
                        _viewModel.NoFamiliasLote = _entidad.CIDS_NoFamiliasLote;
                        _viewModel.NoFamiliasVivienda = _entidad.CIDS_NoFamiliasVivienda;
                        _viewModel.NoViviendasLote = _entidad.CIDS_NoViviendasLote;
                        _viewModel.NoPersonasVivienda = _entidad.CIDS_NoPersonasVivienda;
                        _viewModel.IDServicioAgua = _entidad.CIDS_IDServicioAgua;
                        _viewModel.IDServicioDrenaje = _entidad.CIDS_IDServicioDrenaje;
                        _viewModel.IDServicioElectrico = _entidad.CIDS_IDServicioElectrico;
                        _viewModel.Desdoblamiento = _entidad.CIDS_Desdoblamiento;
                        _viewModel.BanoCompartido = _entidad.CIDS_BanoCompartido;
                        _viewModel.CocinaCompartida = _entidad.CIDS_CocinaCompartido;
                        _viewModel.IDHacinamiento = _entidad.CIDS_IDHacinamiento;
                        _viewModel.IDInsalubridad = _entidad.CIDS_IDInsalubridad;
                        _viewModel.OtroInsalubridad = _entidad.CIDS_OtroInsalubridad;
                        _viewModel.FechaVisita = _entidad.CIDS_FechaVisita;
                        _viewModel.Observaciones = _entidad.CIDS_Observaciones;
                        _viewModel.NoEmpleadoVisita = _entidad.CIDS_NoEmpleadoVisita;
                        _viewModel.Procedencia = _entidad.CIDS_Procedencia;
                        _viewModel.IDVulnerabilidad = _entidad.CIDS_IDVulnerabilidad;
                        _viewModel.MotivosProcedencia = _entidad.CIDS_MotivosProcedencia;
                        _viewModel.FechaDictaminacion = _entidad.CIDS_FechaDictaminacion;
                        _viewModel.UsuarioDominio = _entidad.CIDS_UsuarioDominio;
                        return _viewModel;
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return _viewModel;

            }

            public DictamenTecnicoViewModel ObtenerCIDictamenTecnico(DictamenTecnicoViewModel _viewModel, int _IDCreditoInicial)
            {
                try
                {
                    var _entidad = UoW.CiDictamenTecnico.ObtenerEntidad(new CIDictamenTecnico
                    {
                        CIDT_IDCreditoInicial = _IDCreditoInicial
                    });

                    if (_entidad != null)
                    {
                        _viewModel.TipoCredito = "CI";
                        _viewModel.IDDictamenTecnico = _entidad.CIDT_IDDictamenTecnico;
                        _viewModel.IDCredito = _entidad.CIDT_IDCreditoInicial;
                        _viewModel.IDProcedencia = _entidad.CIDT_Procedencia;
                        _viewModel.MotivosProcedencia = _entidad.CIDT_MotivosProcedencia;
                        _viewModel.MontoSugerido = _entidad.CIDT_MontoSugerido;
                        _viewModel.FechaDictaminacion = _entidad.CIDT_FechaDictaminacion;
                        _viewModel.NoAsesorTecnico = _entidad.CIDT_NoAsesorTecnico;
                        _viewModel.UsuarioDominio = _entidad.CIDT_UsuarioDominio;
                        return _viewModel;
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return _viewModel;

            }

            public DictamenFinancieroViewModel ObtenerCIDictamenFinanciero(DictamenFinancieroViewModel _viewModel, int _IDCreditoInicial)
            {
                try
                {
                    var _entidad = UoW.CiDictamenFinanciero.ObtenerEntidad(new CIDictamenFinanciero
                    {
                        CIDF_IDCreditoInicial = _IDCreditoInicial
                    });

                    if (_entidad != null)
                    {
                        _viewModel.TipoCredito = "CI";
                        _viewModel.IDDictamenFinanciero = _entidad.CIDF_IDDictamenFinanciero;
                        _viewModel.IDCredito = _entidad.CIDF_IDCreditoInicial;
                        _viewModel.Procedencia = _entidad.CIDF_Procedencia;
                        _viewModel.MotivosProcedencia = _entidad.CIDF_MotivosProcedencia;
                        _viewModel.IDUMA = _entidad.CIDF_IDUMA;
                        _viewModel.NoMontoCredito = _entidad.CIDF_NoMontoCreditoUMA;
                        _viewModel.NoMesesAmortizacion = _entidad.CIDF_NoMesesAmortizacion;
                        _viewModel.NoPagoUMA = _entidad.CIDF_NoPagoUMA;
                        _viewModel.FechaDictaminacion = _entidad.CIDF_FechaDictaminacion;
                        _viewModel.UsuarioDominio = _entidad.CIDF_UsuarioDominio;
                        return _viewModel;
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return _viewModel;

            }
        #endregion
        #endregion
        #region Insertar Editar
        
        public void EditDitamenJuridico(DictamenJuridicoViewModel _viewModel)
        {
            string _TipoCredito = _viewModel.TipoCredito;
            switch (_TipoCredito)
            {
                case "CI":
                    EditCIDictamenJuridico(_viewModel);
                    break;
                    //case "CC":
                    //    ObtenerCCDictamenJuridico(_viewModel);
                    //    break;
                    //case "CS":
                    //    ObtenerCSDictamenJuridico(_viewModel);
                    //    break;
                    //case "MC":
                    //    ObtenerMCDictamenJuridico(_viewModel);
                    //    break;
            }

        }
        
        public void EditDitamenSocial(DictamenSocialViewModel _viewModel)
        {
            string _TipoCredito = _viewModel.TipoCredito;
            switch (_TipoCredito)
            {
                case "CI":
                    EditCIDictamenSocial(_viewModel);
                    break;
                    //case "CC":
                    //    ObtenerCCDictamenJuridico(_viewModel);
                    //    break;
                    //case "CS":
                    //    ObtenerCSDictamenJuridico(_viewModel);
                    //    break;
                    //case "MC":
                    //    ObtenerMCDictamenJuridico(_viewModel);
                    //    break;
            }
        }

        public void EditDitamenTecnico(DictamenTecnicoViewModel _viewModel)
        {
            string _TipoCredito = _viewModel.TipoCredito;
            switch (_TipoCredito)
            {
                case "CI":
                    EditCIDictamenTecnico(_viewModel);
                    break;
                    //case "CC":
                    //    ObtenerCCDictamenJuridico(_viewModel);
                    //    break;
                    //case "CS":
                    //    ObtenerCSDictamenJuridico(_viewModel);
                    //    break;
                    //case "MC":
                    //    ObtenerMCDictamenJuridico(_viewModel);
                    //    break;
            }
        }
        
        public void EditDitamenFinanciero(DictamenFinancieroViewModel _viewModel)
        {
            string _TipoCredito = _viewModel.TipoCredito;
            switch (_TipoCredito)
            {
                case "CI":
                    EditCIDictamenFinanciero(_viewModel);
                    break;
                    //case "CC":
                    //    ObtenerCCDictamenJuridico(_viewModel);
                    //    break;
                    //case "CS":
                    //    ObtenerCSDictamenJuridico(_viewModel);
                    //    break;
                    //case "MC":
                    //    ObtenerMCDictamenJuridico(_viewModel);
                    //    break;
            }
        }

       
        #region Credito Inicial
        private void EditCIDictamenJuridico(DictamenJuridicoViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.CiDictamenJuridico.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.CiDictamenJuridico.Alta(new CIDictamenJuridico
                        {
                            
                            CIDJ_IDDictamenJuridico = _viewModel.IDDictamenJuridico,
                            CIDJ_IDCreditoInicial=_viewModel.IDCredito,
                            CIDJ_IDPropiedad= _viewModel.IDPropiedad,
                            CIDJ_IDPosesion=_viewModel.IDPosesion,
                            CIDJ_NoDocumentoPropiedad = _viewModel.NoDocumentoPropiedad,
                            CIDJ_FechaDocumento= _viewModel.FechaDocumento,
                            CIDJ_Anuencia= _viewModel.Anuencia,
                            CIDJ_SuperficieLote=_viewModel.SuperficieLote,
                            CIDJ_DatosLibro=_viewModel.DatosLibro,
                            CIDJ_FolioDocumento = _viewModel.FolioDocumento,
                            CIDJ_Observaciones=_viewModel.Observaciones,
                            CIDJ_Procedencia=_viewModel.Procedencia,
                            CIDJ_MotivosProcedencia= _viewModel.MotivosProcedencia,
                            CIDJ_FechaDictaminacion=_viewModel.FechaDictaminacion,
                            CIDJ_UsuarioDominio="Usuario",
                         });
                        UoW.CiDictamenJuridico.TxScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        private void EditCIDictamenSocial(DictamenSocialViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.CiDictamenSocial.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.CiDictamenSocial.Alta(new CIDictamenSocial
                        {

                            CIDS_IDDictamenSocial=_viewModel.IDDictamenSocial,
                            CIDS_IDCreditoInicial=_viewModel.IDCredito,
                            CIDS_IDTipoPredio=_viewModel.IDTipoPredio ,
                            CIDS_IDCaracteristicasPredio=_viewModel.IDCaracteristicaPredio,
                            CIDS_NoFamiliasLote= _viewModel.NoFamiliasLote ,
                            CIDS_NoFamiliasVivienda=_viewModel.NoFamiliasVivienda ,
                            CIDS_NoViviendasLote= _viewModel.NoViviendasLote  ,
                            CIDS_NoPersonasVivienda= _viewModel.NoPersonasVivienda  ,
                            CIDS_IDServicioAgua=_viewModel.IDServicioAgua  ,
                            CIDS_IDServicioDrenaje=_viewModel.IDServicioDrenaje  ,
                            CIDS_IDServicioElectrico=_viewModel.IDServicioElectrico ,
                            CIDS_Desdoblamiento=_viewModel.Desdoblamiento  ,
                            CIDS_BanoCompartido= _viewModel.BanoCompartido ,
                            CIDS_CocinaCompartido=  _viewModel.CocinaCompartida,
                            CIDS_IDHacinamiento=_viewModel.IDHacinamiento ,
                            CIDS_IDInsalubridad=_viewModel.IDInsalubridad ,
                            CIDS_OtroInsalubridad= _viewModel.OtroInsalubridad ,
                            CIDS_FechaVisita=_viewModel.FechaVisita  ,
                            CIDS_Observaciones=_viewModel.Observaciones  ,
                            CIDS_NoEmpleadoVisita= _viewModel.NoEmpleadoVisita ,
                            CIDS_Procedencia= _viewModel.Procedencia ,
                            CIDS_IDVulnerabilidad = _viewModel.IDVulnerabilidad  ,
                            CIDS_MotivosProcedencia = _viewModel.MotivosProcedencia,
                            CIDS_FechaDictaminacion = _viewModel.FechaDictaminacion,
                            CIDS_UsuarioDominio = "Usuario"

                        });
                        UoW.CiDictamenSocial.TxScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        private void EditCIDictamenTecnico(DictamenTecnicoViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.CiDictamenTecnico.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.CiDictamenTecnico.Alta(new CIDictamenTecnico
                        {
                            
                        CIDT_IDDictamenTecnico  = _viewModel.IDDictamenTecnico,  
                        CIDT_IDCreditoInicial   = _viewModel.IDCredito,          
                        CIDT_Procedencia        = _viewModel.IDProcedencia,      
                        CIDT_MotivosProcedencia = _viewModel.MotivosProcedencia, 
                        CIDT_MontoSugerido      = _viewModel.MontoSugerido,    
                        CIDT_FechaDictaminacion = _viewModel.FechaDictaminacion, 
                        CIDT_NoAsesorTecnico    = _viewModel.NoAsesorTecnico,  
                        CIDT_UsuarioDominio     = "Usuario"

                        });
                        UoW.CiDictamenTecnico.TxScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        private void EditCIDictamenFinanciero(DictamenFinancieroViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.CiDictamenFinanciero.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.CiDictamenFinanciero.Alta(new CIDictamenFinanciero
                        {

                           CIDF_IDDictamenFinanciero= _viewModel.IDDictamenFinanciero,
                           CIDF_IDCreditoInicial= _viewModel.IDCredito               ,
                           CIDF_Procedencia= _viewModel.Procedencia                  ,
                           CIDF_MotivosProcedencia= _viewModel.MotivosProcedencia    ,
                           CIDF_IDUMA= _viewModel.IDUMA                              ,
                           CIDF_NoMontoCreditoUMA= _viewModel.NoMontoCredito         ,
                           CIDF_NoMesesAmortizacion= _viewModel.NoMesesAmortizacion  ,
                           CIDF_NoPagoUMA= _viewModel.NoPagoUMA                      ,
                           CIDF_FechaDictaminacion= _viewModel.FechaDictaminacion    ,
                           CIDF_UsuarioDominio= "Usuario"


                        });
                        UoW.CiDictamenFinanciero.TxScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        #endregion
        #endregion
    }
}
