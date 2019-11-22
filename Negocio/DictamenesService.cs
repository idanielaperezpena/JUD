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
                    case "CC":
                        ObtenerCCDictamenJuridico(_viewModel,ID);
                        break;
                    case "CS":
                        ObtenerCSDictamenJuridico(_viewModel,ID);
                        break;
                    case "MC":
                        ObtenerMCDictamenJuridico(_viewModel, ID);
                        break;
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
                    case "CC":
                       ObtenerCCDictamenSocial(_viewModel,ID);
                        break;
                    case "CS":
                        ObtenerCSDictamenSocial(_viewModel,ID);
                        break;
                    case "MC":
                        ObtenerMCDictamenSocial(_viewModel,ID);
                        break;
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
                    case "CC":
                        ObtenerCCDictamenTecnico(_viewModel,ID);
                        break;
                    case "CS":
                        ObtenerCSDictamenTecnico(_viewModel,ID);
                        break;
                    case "MC":
                        ObtenerMCDictamenTecnico(_viewModel, ID);
                        break;
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
                    case "CC":
                        ObtenerCCDictamenFinanciero(_viewModel,ID);
                        break;
                    case "CS":
                        ObtenerCSDictamenFinanciero(_viewModel, ID);
                        break;
                    case "MC":
                        ObtenerMCDictamenFinanciero(_viewModel, ID);
                        break;
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
                        _viewModel.IDInsalubridad = _entidad.CIDS_IDInsalubridad ?? 0;
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
            #region CC
            public DictamenSocialViewModel ObtenerCCDictamenSocial(DictamenSocialViewModel _viewModel, int _IDCreditoComplementario)
            {
                try
                {
                    var _entidad = UoW.CcDictamenSocial.ObtenerEntidad(new CCDictamenSocial
                    {
                        CCDS_IDCreditoComplementario = _IDCreditoComplementario
                    });

                    if (_entidad != null)
                    {
                        _viewModel.TipoCredito = "CC";
                        _viewModel.IDDictamenSocial = _entidad.CCDS_IDDictamenSocial;
                        _viewModel.IDCredito = _entidad.CCDS_IDCreditoComplementario;
                        _viewModel.IDTipoPredio = _entidad.CCDS_IDTipoPredio;
                        _viewModel.IDCaracteristicaPredio = _entidad.CCDS_IDCaracteristicasPredio;
                        _viewModel.NoFamiliasLote = _entidad.CCDS_NoFamiliasLote;
                        _viewModel.NoFamiliasVivienda = _entidad.CCDS_NoFamiliasVivienda;
                        _viewModel.NoViviendasLote = _entidad.CCDS_NoViviendasLote;
                        _viewModel.NoPersonasVivienda = _entidad.CCDS_NoPersonasVivienda;
                        _viewModel.IDServicioAgua = _entidad.CCDS_IDServicioAgua;
                        _viewModel.IDServicioDrenaje = _entidad.CCDS_IDServicioDrenaje;
                        _viewModel.IDServicioElectrico = _entidad.CCDS_IDServicioElectrico;
                        _viewModel.Desdoblamiento = _entidad.CCDS_Desdoblamiento;
                        _viewModel.BanoCompartido = _entidad.CCDS_BanoCompartido;
                        _viewModel.CocinaCompartida = _entidad.CCDS_CocinaCompartido;
                        _viewModel.IDHacinamiento = _entidad.CCDS_IDHacinamiento;
                        _viewModel.IDInsalubridad = _entidad.CCDS_IDInsalubridad ?? 0;
                        _viewModel.OtroInsalubridad = _entidad.CCDS_OtroInsalubridad;
                        _viewModel.FechaVisita = _entidad.CCDS_FechaVisita;
                        _viewModel.Observaciones = _entidad.CCDS_Observaciones;
                        _viewModel.NoEmpleadoVisita = _entidad.CCDS_NoEmpleadoVisita;
                        _viewModel.Procedencia = _entidad.CCDS_Procedencia;
                        _viewModel.IDVulnerabilidad = _entidad.CCDS_IDVulnerabilidad;
                        _viewModel.MotivosProcedencia = _entidad.CCDS_MotivosProcedencia;
                        _viewModel.FechaDictaminacion = _entidad.CCDS_FechaDictaminacion;
                        _viewModel.UsuarioDominio = _entidad.CCDS_UsuarioDominio;
                        return _viewModel;
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return _viewModel;

            }
            public DictamenTecnicoViewModel ObtenerCCDictamenTecnico(DictamenTecnicoViewModel _viewModel, int _IDCreditoComplementario)
            {
                try
                {
                    var _entidad = UoW.CcDictamenTecnico.ObtenerEntidad(new CCDictamenTecnico
                    {
                        CCDT_IDCreditoComplementario = _IDCreditoComplementario
                    });

                    if (_entidad != null)
                    {
                        _viewModel.TipoCredito = "CC";
                        _viewModel.IDDictamenTecnico = _entidad.CCDT_IDDictamenTecnico;
                        _viewModel.IDCredito = _entidad.CCDT_IDCreditoComplementario;
                        _viewModel.IDProcedencia = _entidad.CCDT_Procedencia;
                        _viewModel.MotivosProcedencia = _entidad.CCDT_MotivosProcedencia;
                        _viewModel.MontoSugerido = _entidad.CCDT_MontoSugerido;
                        _viewModel.FechaDictaminacion = _entidad.CCDT_FechaDictaminacion;
                        _viewModel.NoAsesorTecnico = _entidad.CCDT_NoAsesorTecnico;
                        _viewModel.UsuarioDominio = _entidad.CCDT_UsuarioDominio;
                        return _viewModel;
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return _viewModel;

            }
            public DictamenJuridicoViewModel ObtenerCCDictamenJuridico(DictamenJuridicoViewModel _viewModel, int _IDCreditoComplementario)
            {
                try
                {
                    var _entidad = UoW.CcDictamenJuridico.ObtenerEntidad(new CCDictamenJuridico
                    {
                        CCDJ_IDCreditoComplementario = _IDCreditoComplementario
                    });

                    if (_entidad != null)
                    {
                        _viewModel.TipoCredito = "CC";
                        _viewModel.IDDictamenJuridico = _entidad.CCDJ_IDDictamenJuridico;
                        _viewModel.IDCredito = _entidad.CCDJ_IDCreditoComplementario;
                        _viewModel.IDPropiedad = _entidad.CCDJ_IDPropiedad;
                        _viewModel.IDPosesion = _entidad.CCDJ_IDPosesion;
                        _viewModel.NoDocumentoPropiedad = _entidad.CCDJ_NoDocumentoPropiedad;
                        _viewModel.FechaDocumento = _entidad.CCDJ_FechaDocumento;
                        _viewModel.Anuencia = _entidad.CCDJ_Anuencia;
                        _viewModel.SuperficieLote = _entidad.CCDJ_SuperficieLote;
                        _viewModel.DatosLibro = _entidad.CCDJ_DatosLibro;
                        _viewModel.FolioDocumento = _entidad.CCDJ_FolioDocumento;
                        _viewModel.Observaciones = _entidad.CCDJ_Observaciones;
                        _viewModel.Procedencia = _entidad.CCDJ_Procedencia;
                        _viewModel.MotivosProcedencia = _entidad.CCDJ_MotivosProcedencia;
                        _viewModel.FechaDictaminacion = _entidad.CCDJ_FechaDictaminacion;
                        _viewModel.UsuarioDominio = _entidad.CCDJ_UsuarioDominio;
                        return _viewModel;
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return _viewModel;
            }
            public DictamenFinancieroViewModel ObtenerCCDictamenFinanciero(DictamenFinancieroViewModel _viewModel, int _IDCreditoComplementario)
            {
                try
                {
                    var _entidad = UoW.CcDictamenFinanciero.ObtenerEntidad(new CCDictamenFinanciero
                    {
                        CCDF_IDCreditoComplementario = _IDCreditoComplementario
                    });

                    if (_entidad != null)
                    {
                        _viewModel.TipoCredito = "CC";
                        _viewModel.IDDictamenFinanciero = _entidad.CCDF_IDDictamenFinanciero;
                        _viewModel.IDCredito = _entidad.CCDF_IDCreditoComplementario;
                        _viewModel.Procedencia = _entidad.CCDF_Procedencia;
                        _viewModel.MotivosProcedencia = _entidad.CCDF_MotivosProcedencia;
                        _viewModel.IDUMA = _entidad.CCDF_IDUMA;
                        _viewModel.NoMontoCredito = _entidad.CCDF_NoMontoCreditoUMA;
                        _viewModel.NoMesesAmortizacion = _entidad.CCDF_NoMesesAmortizacion;
                        _viewModel.NoPagoUMA = _entidad.CCDF_NoPagoUMA;
                        _viewModel.FechaDictaminacion = _entidad.CCDF_FechaDictaminacion;
                        _viewModel.UsuarioDominio = _entidad.CCDF_UsuarioDominio;
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

        #region Crédito sustentabilidad
        public DictamenSocialViewModel ObtenerCSDictamenSocial(DictamenSocialViewModel _viewModel, int _IDCreditoSustentabilidad)
        {
            try
            {
                var _entidad = UoW.CsDictamenSocial.ObtenerEntidad(new CSDictamenSocial
                {
                    CSDS_IDCreditoSustentabilidad = _IDCreditoSustentabilidad
                });

                if (_entidad != null)
                {
                    _viewModel.TipoCredito = "CS";
                    _viewModel.IDDictamenSocial = _entidad.CSDS_IDDictamenSocial;
                    _viewModel.IDCredito = _entidad.CSDS_IDCreditoSustentabilidad;
                    _viewModel.IDTipoPredio = _entidad.CSDS_IDTipoPredio;
                    _viewModel.IDCaracteristicaPredio = _entidad.CSDS_IDCaracteristicasPredio;
                    _viewModel.NoFamiliasLote = _entidad.CSDS_NoFamiliasLote;
                    _viewModel.NoFamiliasVivienda = _entidad.CSDS_NoFamiliasVivienda;
                    _viewModel.NoViviendasLote = _entidad.CSDS_NoViviendasLote;
                    _viewModel.NoPersonasVivienda = _entidad.CSDS_NoPersonasVivienda;
                    _viewModel.IDServicioAgua = _entidad.CSDS_IDServicioAgua;
                    _viewModel.IDServicioDrenaje = _entidad.CSDS_IDServicioDrenaje;
                    _viewModel.IDServicioElectrico = _entidad.CSDS_IDServicioElectrico;
                    _viewModel.Desdoblamiento = _entidad.CSDS_Desdoblamiento;
                    _viewModel.BanoCompartido = _entidad.CSDS_BanoCompartido;
                    _viewModel.CocinaCompartida = _entidad.CSDS_CocinaCompartido;
                    _viewModel.IDHacinamiento = _entidad.CSDS_IDHacinamiento;
                    _viewModel.IDInsalubridad = _entidad.CSDS_IDInsalubridad ?? 0;
                    _viewModel.OtroInsalubridad = _entidad.CSDS_OtroInsalubridad;
                    _viewModel.FechaVisita = _entidad.CSDS_FechaVisita;
                    _viewModel.Observaciones = _entidad.CSDS_Observaciones;
                    _viewModel.NoEmpleadoVisita = _entidad.CSDS_NoEmpleadoVisita;
                    _viewModel.Procedencia = _entidad.CSDS_Procedencia;
                    _viewModel.IDVulnerabilidad = _entidad.CSDS_IDVulnerabilidad;
                    _viewModel.MotivosProcedencia = _entidad.CSDS_MotivosProcedencia;
                    _viewModel.FechaDictaminacion = _entidad.CSDS_FechaDictaminacion;
                    _viewModel.UsuarioDominio = _entidad.CSDS_UsuarioDominio;
                    return _viewModel;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return _viewModel;

        }
        public DictamenTecnicoViewModel ObtenerCSDictamenTecnico(DictamenTecnicoViewModel _viewModel, int _IDCreditoSustentabilidad)
        {
            try
            {
                var _entidad = UoW.CsDictamenTecnico.ObtenerEntidad(new CSDictamenTecnico
                {
                    CSDT_IDCreditoSustentabilidad = _IDCreditoSustentabilidad
                });

                if (_entidad != null)
                {
                    _viewModel.TipoCredito = "CS";
                    _viewModel.IDDictamenTecnico = _entidad.CSDT_IDDictamenTecnico;
                    _viewModel.IDCredito = _entidad.CSDT_IDCreditoSustentabilidad;
                    _viewModel.IDProcedencia = _entidad.CSDT_Procedencia;
                    _viewModel.MotivosProcedencia = _entidad.CSDT_MotivosProcedencia;
                    _viewModel.MontoSugerido = _entidad.CSDT_MontoSugerido;
                    _viewModel.FechaDictaminacion = _entidad.CSDT_FechaDictaminacion;
                    _viewModel.NoAsesorTecnico = _entidad.CSDT_NoAsesorTecnico;
                    _viewModel.UsuarioDominio = _entidad.CSDT_UsuarioDominio;
                    return _viewModel;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return _viewModel;

        }
        public DictamenJuridicoViewModel ObtenerCSDictamenJuridico(DictamenJuridicoViewModel _viewModel, int _IDCreditoSustentabilidad)
        {
            try
            {
                var _entidad = UoW.CsDictamenJuridico.ObtenerEntidad(new CSDictamenJuridico
                {
                    CSDJ_IDCreditoSustentabilidad = _IDCreditoSustentabilidad
                });

                if (_entidad != null)
                {
                    _viewModel.TipoCredito = "CS";
                    _viewModel.IDDictamenJuridico = _entidad.CSDJ_IDDictamenJuridico;
                    _viewModel.IDCredito = _entidad.CSDJ_IDCreditoSustentabilidad;
                    _viewModel.IDPropiedad = _entidad.CSDJ_IDPropiedad;
                    _viewModel.IDPosesion = _entidad.CSDJ_IDPosesion;
                    _viewModel.NoDocumentoPropiedad = _entidad.CSDJ_NoDocumentoPropiedad;
                    _viewModel.FechaDocumento = _entidad.CSDJ_FechaDocumento;
                    _viewModel.Anuencia = _entidad.CSDJ_Anuencia;
                    _viewModel.SuperficieLote = _entidad.CSDJ_SuperficieLote;
                    _viewModel.DatosLibro = _entidad.CSDJ_DatosLibro;
                    _viewModel.FolioDocumento = _entidad.CSDJ_FolioDocumento;
                    _viewModel.Observaciones = _entidad.CSDJ_Observaciones;
                    _viewModel.Procedencia = _entidad.CSDJ_Procedencia;
                    _viewModel.MotivosProcedencia = _entidad.CSDJ_MotivosProcedencia;
                    _viewModel.FechaDictaminacion = _entidad.CSDJ_FechaDictaminacion;
                    _viewModel.UsuarioDominio = _entidad.CSDJ_UsuarioDominio;
                    return _viewModel;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return _viewModel;
        }
        public DictamenFinancieroViewModel ObtenerCSDictamenFinanciero(DictamenFinancieroViewModel _viewModel, int _IDCreditoSustentabilidad)
        {
            try
            {
                var _entidad = UoW.CsDictamenFinanciero.ObtenerEntidad(new CSDictamenFinanciero
                {
                    CSDF_IDCreditoSustentabilidad = _IDCreditoSustentabilidad
                });

                if (_entidad != null)
                {
                    _viewModel.TipoCredito = "CS";
                    _viewModel.IDDictamenFinanciero = _entidad.CSDF_IDDictamenFinanciero;
                    _viewModel.IDCredito = _entidad.CSDF_IDCreditoSustentabilidad;
                    _viewModel.Procedencia = _entidad.CSDF_Procedencia;
                    _viewModel.MotivosProcedencia = _entidad.CSDF_MotivosProcedencia;
                    _viewModel.IDUMA = _entidad.CSDF_IDUMA;
                    _viewModel.NoMontoCredito = _entidad.CSDF_NoMontoCreditoUMA;
                    _viewModel.NoMesesAmortizacion = _entidad.CSDF_NoMesesAmortizacion;
                    _viewModel.NoPagoUMA = _entidad.CSDF_NoPagoUMA;
                    _viewModel.FechaDictaminacion = _entidad.CSDF_FechaDictaminacion;
                    _viewModel.UsuarioDominio = _entidad.CSDF_UsuarioDominio;
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

        #region Modificaciones Crédito
        public DictamenSocialViewModel ObtenerMCDictamenSocial(DictamenSocialViewModel _viewModel, int _IDModificacionesCredito)
        {
            try
            {
                var _entidad = UoW.McDictamenSocial.ObtenerEntidad(new MCDictamenSocial
                {
                    MCDS_IDModificacionesCredito = _IDModificacionesCredito
                });

                if (_entidad != null)
                {
                    _viewModel.TipoCredito = "MC";
                    _viewModel.IDDictamenSocial = _entidad.MCDS_IDDictamenSocial;
                    _viewModel.IDCredito = _entidad.MCDS_IDModificacionesCredito;
                    _viewModel.IDTipoPredio = _entidad.MCDS_IDTipoPredio;
                    _viewModel.IDCaracteristicaPredio = _entidad.MCDS_IDCaracteristicasPredio;
                    _viewModel.NoFamiliasLote = _entidad.MCDS_NoFamiliasLote;
                    _viewModel.NoFamiliasVivienda = _entidad.MCDS_NoFamiliasVivienda;
                    _viewModel.NoViviendasLote = _entidad.MCDS_NoViviendasLote;
                    _viewModel.NoPersonasVivienda = _entidad.MCDS_NoPersonasVivienda;
                    _viewModel.IDServicioAgua = _entidad.MCDS_IDServicioAgua;
                    _viewModel.IDServicioDrenaje = _entidad.MCDS_IDServicioDrenaje;
                    _viewModel.IDServicioElectrico = _entidad.MCDS_IDServicioElectrico;
                    _viewModel.Desdoblamiento = _entidad.MCDS_Desdoblamiento;
                    _viewModel.BanoCompartido = _entidad.MCDS_BanoCompartido;
                    _viewModel.CocinaCompartida = _entidad.MCDS_CocinaCompartido;
                    _viewModel.IDHacinamiento = _entidad.MCDS_IDHacinamiento;
                    _viewModel.IDInsalubridad = _entidad.MCDS_IDInsalubridad ?? 0;
                    _viewModel.OtroInsalubridad = _entidad.MCDS_OtroInsalubridad;
                    _viewModel.FechaVisita = _entidad.MCDS_FechaVisita;
                    _viewModel.Observaciones = _entidad.MCDS_Observaciones;
                    _viewModel.NoEmpleadoVisita = _entidad.MCDS_NoEmpleadoVisita;
                    _viewModel.Procedencia = _entidad.MCDS_Procedencia;
                    _viewModel.IDVulnerabilidad = _entidad.MCDS_IDVulnerabilidad;
                    _viewModel.MotivosProcedencia = _entidad.MCDS_MotivosProcedencia;
                    _viewModel.FechaDictaminacion = _entidad.MCDS_FechaDictaminacion;
                    _viewModel.UsuarioDominio = _entidad.MCDS_UsuarioDominio;
                    return _viewModel;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return _viewModel;

        }
        public DictamenTecnicoViewModel ObtenerMCDictamenTecnico(DictamenTecnicoViewModel _viewModel, int _IDModificacionesCredito)
        {
            try
            {
                var _entidad = UoW.McDictamenTecnico.ObtenerEntidad(new MCDictamenTecnico
                {
                    MCDT_IDModificacionesCredito = _IDModificacionesCredito
                });

                if (_entidad != null)
                {
                    _viewModel.TipoCredito = "MC";
                    _viewModel.IDDictamenTecnico = _entidad.MCDT_IDDictamenTecnico;
                    _viewModel.IDCredito = _entidad.MCDT_IDModificacionesCredito;
                    _viewModel.IDProcedencia = _entidad.MCDT_Procedencia;
                    _viewModel.MotivosProcedencia = _entidad.MCDT_MotivosProcedencia;
                    _viewModel.MontoSugerido = _entidad.MCDT_MontoSugerido;
                    _viewModel.FechaDictaminacion = _entidad.MCDT_FechaDictaminacion;
                    _viewModel.NoAsesorTecnico = _entidad.MCDT_NoAsesorTecnico;
                    _viewModel.UsuarioDominio = _entidad.MCDT_UsuarioDominio;
                    return _viewModel;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return _viewModel;

        }
        public DictamenJuridicoViewModel ObtenerMCDictamenJuridico(DictamenJuridicoViewModel _viewModel, int _IDModificacionesCredito)
        {
            try
            {
                var _entidad = UoW.McDictamenJuridico.ObtenerEntidad(new MCDictamenJuridico
                {
                    MCDJ_IDModificacionesCredito = _IDModificacionesCredito
                });

                if (_entidad != null)
                {
                    _viewModel.TipoCredito = "MC";
                    _viewModel.IDDictamenJuridico = _entidad.MCDJ_IDDictamenJuridico;
                    _viewModel.IDCredito = _entidad.MCDJ_IDModificacionesCredito;
                    _viewModel.IDPropiedad = _entidad.MCDJ_IDPropiedad;
                    _viewModel.IDPosesion = _entidad.MCDJ_IDPosesion;
                    _viewModel.NoDocumentoPropiedad = _entidad.MCDJ_NoDocumentoPropiedad;
                    _viewModel.FechaDocumento = _entidad.MCDJ_FechaDocumento;
                    _viewModel.Anuencia = _entidad.MCDJ_Anuencia;
                    _viewModel.SuperficieLote = _entidad.MCDJ_SuperficieLote;
                    _viewModel.DatosLibro = _entidad.MCDJ_DatosLibro;
                    _viewModel.FolioDocumento = _entidad.MCDJ_FolioDocumento;
                    _viewModel.Observaciones = _entidad.MCDJ_Observaciones;
                    _viewModel.Procedencia = _entidad.MCDJ_Procedencia;
                    _viewModel.MotivosProcedencia = _entidad.MCDJ_MotivosProcedencia;
                    _viewModel.FechaDictaminacion = _entidad.MCDJ_FechaDictaminacion;
                    _viewModel.UsuarioDominio = _entidad.MCDJ_UsuarioDominio;
                    return _viewModel;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return _viewModel;
        }
        public DictamenFinancieroViewModel ObtenerMCDictamenFinanciero(DictamenFinancieroViewModel _viewModel, int _IDModificacionesCredito)
        {
            try
            {
                var _entidad = UoW.McDictamenFinanciero.ObtenerEntidad(new MCDictamenFinanciero
                {
                    MCDF_IDModificacionesCredito = _IDModificacionesCredito
                });

                if (_entidad != null)
                {
                    _viewModel.TipoCredito = "MC";
                    _viewModel.IDDictamenFinanciero = _entidad.MCDF_IDDictamenFinanciero;
                    _viewModel.IDCredito = _entidad.MCDF_IDModificacionesCredito;
                    _viewModel.Procedencia = _entidad.MCDF_Procedencia;
                    _viewModel.MotivosProcedencia = _entidad.MCDF_MotivosProcedencia;
                    _viewModel.IDUMA = _entidad.MCDF_IDUMA;
                    _viewModel.NoMontoCredito = _entidad.MCDF_NoMontoCreditoUMA;
                    _viewModel.NoMesesAmortizacion = _entidad.MCDF_NoMesesAmortizacion;
                    _viewModel.NoPagoUMA = _entidad.MCDF_NoPagoUMA;
                    _viewModel.FechaDictaminacion = _entidad.MCDF_FechaDictaminacion;
                    _viewModel.UsuarioDominio = _entidad.MCDF_UsuarioDominio;
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
                case "CC":
                    EditCCDictamenJuridico(_viewModel);
                    break;
                case "CS":
                    EditCSDictamenJuridico(_viewModel);
                    break;
                case "MC":
                    EditMCDictamenJuridico(_viewModel);
                    break;
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
                case "CC":
                    EditCCDictamenSocial(_viewModel);
                    break;
                case "CS":
                    EditCSDictamenSocial(_viewModel);
                    break;
                case "MC":
                    EditMCDictamenSocial(_viewModel);
                    break;
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
                case "CC":
                    EditCCDictamenTecnico(_viewModel);
                    break;
                case "CS":
                   EditCSDictamenTecnico(_viewModel);
                    break;
                case "MC":
                    EditMCDictamenTecnico(_viewModel);
                    break;
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
                case "CC":
                    EditCCDictamenFinanciero(_viewModel);
                    break;
                case "CS":
                    EditCSDictamenFinanciero(_viewModel);
                    break;
                case "MC":
                    EditMCDictamenFinanciero(_viewModel);
                    break;
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

                            CIDS_IDDictamenSocial = _viewModel.IDDictamenSocial,
                            CIDS_IDCreditoInicial = _viewModel.IDCredito,
                            CIDS_IDTipoPredio = _viewModel.IDTipoPredio,
                            CIDS_IDCaracteristicasPredio = _viewModel.IDCaracteristicaPredio,
                            CIDS_NoFamiliasLote = _viewModel.NoFamiliasLote,
                            CIDS_NoFamiliasVivienda = _viewModel.NoFamiliasVivienda,
                            CIDS_NoViviendasLote = _viewModel.NoViviendasLote,
                            CIDS_NoPersonasVivienda = _viewModel.NoPersonasVivienda,
                            CIDS_IDServicioAgua = _viewModel.IDServicioAgua,
                            CIDS_IDServicioDrenaje = _viewModel.IDServicioDrenaje,
                            CIDS_IDServicioElectrico = _viewModel.IDServicioElectrico,
                            CIDS_Desdoblamiento = _viewModel.Desdoblamiento,
                            CIDS_BanoCompartido = _viewModel.BanoCompartido,
                            CIDS_CocinaCompartido = _viewModel.CocinaCompartida,
                            CIDS_IDHacinamiento = _viewModel.IDHacinamiento,
                            CIDS_IDInsalubridad = _viewModel.IDInsalubridad,
                            CIDS_OtroInsalubridad = _viewModel.OtroInsalubridad,
                            CIDS_FechaVisita = _viewModel.FechaVisita,
                            CIDS_Observaciones = _viewModel.Observaciones,
                            CIDS_NoEmpleadoVisita = _viewModel.NoEmpleadoVisita,
                            CIDS_Procedencia = _viewModel.Procedencia,
                            CIDS_IDVulnerabilidad = _viewModel.IDVulnerabilidad,
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


        #region Credito Complementario
        private void EditCCDictamenJuridico(DictamenJuridicoViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.CcDictamenJuridico.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.CcDictamenJuridico.Alta(new CCDictamenJuridico
                        {

                            CCDJ_IDDictamenJuridico = _viewModel.IDDictamenJuridico,
                            CCDJ_IDCreditoComplementario = _viewModel.IDCredito,
                            CCDJ_IDPropiedad = _viewModel.IDPropiedad,
                            CCDJ_IDPosesion = _viewModel.IDPosesion,
                            CCDJ_NoDocumentoPropiedad = _viewModel.NoDocumentoPropiedad,
                            CCDJ_FechaDocumento = _viewModel.FechaDocumento,
                            CCDJ_Anuencia = _viewModel.Anuencia,
                            CCDJ_SuperficieLote = _viewModel.SuperficieLote,
                            CCDJ_DatosLibro = _viewModel.DatosLibro,
                            CCDJ_FolioDocumento = _viewModel.FolioDocumento,
                            CCDJ_Observaciones = _viewModel.Observaciones,
                            CCDJ_Procedencia = _viewModel.Procedencia,
                            CCDJ_MotivosProcedencia = _viewModel.MotivosProcedencia,
                            CCDJ_FechaDictaminacion = _viewModel.FechaDictaminacion,
                            CCDJ_UsuarioDominio = "Usuario",
                        });
                        UoW.CcDictamenJuridico.TxScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        private void EditCCDictamenSocial(DictamenSocialViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.CcDictamenSocial.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.CcDictamenSocial.Alta(new CCDictamenSocial
                        {

                            CCDS_IDDictamenSocial = _viewModel.IDDictamenSocial,
                            CCDS_IDCreditoComplementario = _viewModel.IDCredito,
                            CCDS_IDTipoPredio = _viewModel.IDTipoPredio,
                            CCDS_IDCaracteristicasPredio = _viewModel.IDCaracteristicaPredio,
                            CCDS_NoFamiliasLote = _viewModel.NoFamiliasLote,
                            CCDS_NoFamiliasVivienda = _viewModel.NoFamiliasVivienda,
                            CCDS_NoViviendasLote = _viewModel.NoViviendasLote,
                            CCDS_NoPersonasVivienda = _viewModel.NoPersonasVivienda,
                            CCDS_IDServicioAgua = _viewModel.IDServicioAgua,
                            CCDS_IDServicioDrenaje = _viewModel.IDServicioDrenaje,
                            CCDS_IDServicioElectrico = _viewModel.IDServicioElectrico,
                            CCDS_Desdoblamiento = _viewModel.Desdoblamiento,
                            CCDS_BanoCompartido = _viewModel.BanoCompartido,
                            CCDS_CocinaCompartido = _viewModel.CocinaCompartida,
                            CCDS_IDHacinamiento = _viewModel.IDHacinamiento,
                            CCDS_IDInsalubridad = _viewModel.IDInsalubridad,
                            CCDS_OtroInsalubridad = _viewModel.OtroInsalubridad,
                            CCDS_FechaVisita = _viewModel.FechaVisita,
                            CCDS_Observaciones = _viewModel.Observaciones,
                            CCDS_NoEmpleadoVisita = _viewModel.NoEmpleadoVisita,
                            CCDS_Procedencia = _viewModel.Procedencia,
                            CCDS_IDVulnerabilidad = _viewModel.IDVulnerabilidad,
                            CCDS_MotivosProcedencia = _viewModel.MotivosProcedencia,
                            CCDS_FechaDictaminacion = _viewModel.FechaDictaminacion,
                            CCDS_UsuarioDominio = "Usuario"

                        });
                        UoW.CcDictamenSocial.TxScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        private void EditCCDictamenTecnico(DictamenTecnicoViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.CcDictamenTecnico.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.CcDictamenTecnico.Alta(new CCDictamenTecnico
                        {

                            CCDT_IDDictamenTecnico = _viewModel.IDDictamenTecnico,
                            CCDT_IDCreditoComplementario = _viewModel.IDCredito,
                            CCDT_Procedencia = _viewModel.IDProcedencia,
                            CCDT_MotivosProcedencia = _viewModel.MotivosProcedencia,
                            CCDT_MontoSugerido = _viewModel.MontoSugerido,
                            CCDT_FechaDictaminacion = _viewModel.FechaDictaminacion,
                            CCDT_NoAsesorTecnico = _viewModel.NoAsesorTecnico,
                            CCDT_UsuarioDominio = "Usuario"

                        });
                        UoW.CcDictamenTecnico.TxScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        private void EditCCDictamenFinanciero(DictamenFinancieroViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.CcDictamenFinanciero.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.CcDictamenFinanciero.Alta(new CCDictamenFinanciero
                        {

                            CCDF_IDDictamenFinanciero = _viewModel.IDDictamenFinanciero,
                            CCDF_IDCreditoComplementario = _viewModel.IDCredito,
                            CCDF_Procedencia = _viewModel.Procedencia,
                            CCDF_MotivosProcedencia = _viewModel.MotivosProcedencia,
                            CCDF_IDUMA = _viewModel.IDUMA,
                            CCDF_NoMontoCreditoUMA = _viewModel.NoMontoCredito,
                            CCDF_NoMesesAmortizacion = _viewModel.NoMesesAmortizacion,
                            CCDF_NoPagoUMA = _viewModel.NoPagoUMA,
                            CCDF_FechaDictaminacion = _viewModel.FechaDictaminacion,
                            CCDF_UsuarioDominio = "Usuario"


                        });
                        UoW.CcDictamenFinanciero.TxScope.Complete();
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

        #region Credito Sustentailidad
        private void EditCSDictamenJuridico(DictamenJuridicoViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.CsDictamenJuridico.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.CsDictamenJuridico.Alta(new CSDictamenJuridico
                        {

                            CSDJ_IDDictamenJuridico = _viewModel.IDDictamenJuridico,
                            CSDJ_IDCreditoSustentabilidad = _viewModel.IDCredito,
                            CSDJ_IDPropiedad = _viewModel.IDPropiedad,
                            CSDJ_IDPosesion = _viewModel.IDPosesion,
                            CSDJ_NoDocumentoPropiedad = _viewModel.NoDocumentoPropiedad,
                            CSDJ_FechaDocumento = _viewModel.FechaDocumento,
                            CSDJ_Anuencia = _viewModel.Anuencia,
                            CSDJ_SuperficieLote = _viewModel.SuperficieLote,
                            CSDJ_DatosLibro = _viewModel.DatosLibro,
                            CSDJ_FolioDocumento = _viewModel.FolioDocumento,
                            CSDJ_Observaciones = _viewModel.Observaciones,
                            CSDJ_Procedencia = _viewModel.Procedencia,
                            CSDJ_MotivosProcedencia = _viewModel.MotivosProcedencia,
                            CSDJ_FechaDictaminacion = _viewModel.FechaDictaminacion,
                            CSDJ_UsuarioDominio = "Usuario",
                        });
                        UoW.CsDictamenJuridico.TxScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        private void EditCSDictamenSocial(DictamenSocialViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.CsDictamenSocial.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.CsDictamenSocial.Alta(new CSDictamenSocial
                        {

                            CSDS_IDDictamenSocial = _viewModel.IDDictamenSocial,
                            CSDS_IDCreditoSustentabilidad = _viewModel.IDCredito,
                            CSDS_IDTipoPredio = _viewModel.IDTipoPredio,
                            CSDS_IDCaracteristicasPredio = _viewModel.IDCaracteristicaPredio,
                            CSDS_NoFamiliasLote = _viewModel.NoFamiliasLote,
                            CSDS_NoFamiliasVivienda = _viewModel.NoFamiliasVivienda,
                            CSDS_NoViviendasLote = _viewModel.NoViviendasLote,
                            CSDS_NoPersonasVivienda = _viewModel.NoPersonasVivienda,
                            CSDS_IDServicioAgua = _viewModel.IDServicioAgua,
                            CSDS_IDServicioDrenaje = _viewModel.IDServicioDrenaje,
                            CSDS_IDServicioElectrico = _viewModel.IDServicioElectrico,
                            CSDS_Desdoblamiento = _viewModel.Desdoblamiento,
                            CSDS_BanoCompartido = _viewModel.BanoCompartido,
                            CSDS_CocinaCompartido = _viewModel.CocinaCompartida,
                            CSDS_IDHacinamiento = _viewModel.IDHacinamiento,
                            CSDS_IDInsalubridad = _viewModel.IDInsalubridad,
                            CSDS_OtroInsalubridad = _viewModel.OtroInsalubridad,
                            CSDS_FechaVisita = _viewModel.FechaVisita,
                            CSDS_Observaciones = _viewModel.Observaciones,
                            CSDS_NoEmpleadoVisita = _viewModel.NoEmpleadoVisita,
                            CSDS_Procedencia = _viewModel.Procedencia,
                            CSDS_IDVulnerabilidad = _viewModel.IDVulnerabilidad,
                            CSDS_MotivosProcedencia = _viewModel.MotivosProcedencia,
                            CSDS_FechaDictaminacion = _viewModel.FechaDictaminacion,
                            CSDS_UsuarioDominio = "Usuario"

                        });
                        UoW.CsDictamenSocial.TxScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        private void EditCSDictamenTecnico(DictamenTecnicoViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.CsDictamenTecnico.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.CsDictamenTecnico.Alta(new CSDictamenTecnico
                        {

                            CSDT_IDDictamenTecnico = _viewModel.IDDictamenTecnico,
                            CSDT_IDCreditoSustentabilidad = _viewModel.IDCredito,
                            CSDT_Procedencia = _viewModel.IDProcedencia,
                            CSDT_MotivosProcedencia = _viewModel.MotivosProcedencia,
                            CSDT_MontoSugerido = _viewModel.MontoSugerido,
                            CSDT_FechaDictaminacion = _viewModel.FechaDictaminacion,
                            CSDT_NoAsesorTecnico = _viewModel.NoAsesorTecnico,
                            CSDT_UsuarioDominio = "Usuario"

                        });
                        UoW.CsDictamenTecnico.TxScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        private void EditCSDictamenFinanciero(DictamenFinancieroViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.CsDictamenFinanciero.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.CsDictamenFinanciero.Alta(new CSDictamenFinanciero
                        {

                            CSDF_IDDictamenFinanciero = _viewModel.IDDictamenFinanciero,
                            CSDF_IDCreditoSustentabilidad = _viewModel.IDCredito,
                            CSDF_Procedencia = _viewModel.Procedencia,
                            CSDF_MotivosProcedencia = _viewModel.MotivosProcedencia,
                            CSDF_IDUMA = _viewModel.IDUMA,
                            CSDF_NoMontoCreditoUMA = _viewModel.NoMontoCredito,
                            CSDF_NoMesesAmortizacion = _viewModel.NoMesesAmortizacion,
                            CSDF_NoPagoUMA = _viewModel.NoPagoUMA,
                            CSDF_FechaDictaminacion = _viewModel.FechaDictaminacion,
                            CSDF_UsuarioDominio = "Usuario"

                        });
                        UoW.CsDictamenFinanciero.TxScope.Complete();
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

        #region Modificaciones Credito
        private void EditMCDictamenJuridico(DictamenJuridicoViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.McDictamenJuridico.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.McDictamenJuridico.Alta(new MCDictamenJuridico
                        {

                            MCDJ_IDDictamenJuridico = _viewModel.IDDictamenJuridico,
                            MCDJ_IDModificacionesCredito = _viewModel.IDCredito,
                            MCDJ_IDPropiedad = _viewModel.IDPropiedad,
                            MCDJ_IDPosesion = _viewModel.IDPosesion,
                            MCDJ_NoDocumentoPropiedad = _viewModel.NoDocumentoPropiedad,
                            MCDJ_FechaDocumento = _viewModel.FechaDocumento,
                            MCDJ_Anuencia = _viewModel.Anuencia,
                            MCDJ_SuperficieLote = _viewModel.SuperficieLote,
                            MCDJ_DatosLibro = _viewModel.DatosLibro,
                            MCDJ_FolioDocumento = _viewModel.FolioDocumento,
                            MCDJ_Observaciones = _viewModel.Observaciones,
                            MCDJ_Procedencia = _viewModel.Procedencia,
                            MCDJ_MotivosProcedencia = _viewModel.MotivosProcedencia,
                            MCDJ_FechaDictaminacion = _viewModel.FechaDictaminacion,
                            MCDJ_UsuarioDominio = "Usuario",
                        });
                        UoW.McDictamenJuridico.TxScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        private void EditMCDictamenSocial(DictamenSocialViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.McDictamenSocial.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.McDictamenSocial.Alta(new MCDictamenSocial
                        {

                            MCDS_IDDictamenSocial = _viewModel.IDDictamenSocial,
                            MCDS_IDModificacionesCredito = _viewModel.IDCredito,
                            MCDS_IDTipoPredio = _viewModel.IDTipoPredio,
                            MCDS_IDCaracteristicasPredio = _viewModel.IDCaracteristicaPredio,
                            MCDS_NoFamiliasLote = _viewModel.NoFamiliasLote,
                            MCDS_NoFamiliasVivienda = _viewModel.NoFamiliasVivienda,
                            MCDS_NoViviendasLote = _viewModel.NoViviendasLote,
                            MCDS_NoPersonasVivienda = _viewModel.NoPersonasVivienda,
                            MCDS_IDServicioAgua = _viewModel.IDServicioAgua,
                            MCDS_IDServicioDrenaje = _viewModel.IDServicioDrenaje,
                            MCDS_IDServicioElectrico = _viewModel.IDServicioElectrico,
                            MCDS_Desdoblamiento = _viewModel.Desdoblamiento,
                            MCDS_BanoCompartido = _viewModel.BanoCompartido,
                            MCDS_CocinaCompartido = _viewModel.CocinaCompartida,
                            MCDS_IDHacinamiento = _viewModel.IDHacinamiento,
                            MCDS_IDInsalubridad = _viewModel.IDInsalubridad,
                            MCDS_OtroInsalubridad = _viewModel.OtroInsalubridad,
                            MCDS_FechaVisita = _viewModel.FechaVisita,
                            MCDS_Observaciones = _viewModel.Observaciones,
                            MCDS_NoEmpleadoVisita = _viewModel.NoEmpleadoVisita,
                            MCDS_Procedencia = _viewModel.Procedencia,
                            MCDS_IDVulnerabilidad = _viewModel.IDVulnerabilidad,
                            MCDS_MotivosProcedencia = _viewModel.MotivosProcedencia,
                            MCDS_FechaDictaminacion = _viewModel.FechaDictaminacion,
                            MCDS_UsuarioDominio = "Usuario"

                        });
                        UoW.McDictamenSocial.TxScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        private void EditMCDictamenTecnico(DictamenTecnicoViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.McDictamenTecnico.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.McDictamenTecnico.Alta(new MCDictamenTecnico
                        {

                            MCDT_IDDictamenTecnico = _viewModel.IDDictamenTecnico,
                            MCDT_IDModificacionesCredito = _viewModel.IDCredito,
                            MCDT_Procedencia = _viewModel.IDProcedencia,
                            MCDT_MotivosProcedencia = _viewModel.MotivosProcedencia,
                            MCDT_MontoSugerido = _viewModel.MontoSugerido,
                            MCDT_FechaDictaminacion = _viewModel.FechaDictaminacion,
                            MCDT_NoAsesorTecnico = _viewModel.NoAsesorTecnico,
                            MCDT_UsuarioDominio = "Usuario"

                        });
                        UoW.McDictamenTecnico.TxScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        private void EditMCDictamenFinanciero(DictamenFinancieroViewModel _viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.McDictamenFinanciero.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.McDictamenFinanciero.Alta(new MCDictamenFinanciero
                        {

                            MCDF_IDDictamenFinanciero = _viewModel.IDDictamenFinanciero,
                            MCDF_IDModificacionesCredito = _viewModel.IDCredito,
                            MCDF_Procedencia = _viewModel.Procedencia,
                            MCDF_MotivosProcedencia = _viewModel.MotivosProcedencia,
                            MCDF_IDUMA = _viewModel.IDUMA,
                            MCDF_NoMontoCreditoUMA = _viewModel.NoMontoCredito,
                            MCDF_NoMesesAmortizacion = _viewModel.NoMesesAmortizacion,
                            MCDF_NoPagoUMA = _viewModel.NoPagoUMA,
                            MCDF_FechaDictaminacion = _viewModel.FechaDictaminacion,
                            MCDF_UsuarioDominio = "Usuario"

                        });
                        UoW.McDictamenFinanciero.TxScope.Complete();
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
